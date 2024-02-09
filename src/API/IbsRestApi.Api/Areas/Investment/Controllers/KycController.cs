using IbsRestApi.Api.Contracts;
using IbsRestApi.Api.Controllers;
using IbsRestApi.Application.Contracts;
using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Application.Kyc;
using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IbsRestApi.Api.Areas.Investment.Controllers;

[ApiVersion("1.0")]
[Route("api/core/v{v:apiversion}/kyc")]
[ApiController]
public class KycController : BaseController
{
    private readonly IAppService _service;

    public KycController(IAppService service)
    {
        _service = service;
    }

    [HttpGet(ApiRoutes.KycRoutes.FetchCustomerKyc)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<List<PeopleKycCheckList>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> FetchCustormerKyc(int ucid)
    {
        if (ucid == 0) return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<PeopleKycCheckList>>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "User not found",
            hasError = true
        });
        var customerType = _service.MdmService.FetchCustomerType(ucid);
        await _service.KycService.SaveIbsPeopleKyc(ucid, 5000, customerType);
        var pendingKyc = _service.KycService.PeopleKycCheckListsQueryable(ucid,customerType).ToList();

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<List<PeopleKycCheckList>>
        {
            statusCode = StatusCodes.Status200OK,
            message = "User KYC list",
            hasError = false,
            data = pendingKyc
        });
    }

    [HttpPost(ApiRoutes.KycRoutes.AddOrUpdateCustomerKyc)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOrUpdateClientKyc()
    {
        var request = await HttpContext.Request.ReadFormAsync();

        if (!request.Files.Any()) return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "No image sent",
            hasError = true
        });

        var file = request.Files[0];

        var rawUcid = request["ucid"].FirstOrDefault();
        var rawKycId = request["kycId"].FirstOrDefault();
        var fileExtension = CommonHelper.GetFileExtension(file.FileName);
        var fileByte = CommonHelper.GetBytes(file);

        if (string.IsNullOrEmpty(rawUcid)) return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "No ucid sent",
            hasError = true
        });

        if (!int.TryParse(rawUcid, out int ucid)) return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Invalid ucid sent",
            hasError = true
        });

        if (!int.TryParse(rawKycId, out int kycId)) return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "Invalid ucid sent",
            hasError = true
        });

        var customerType = _service.MdmService.FetchCustomerType(ucid);
        var alreadyVerified = _service.KycService.PeopleKycCheckListsQueryable(ucid,customerType).FirstOrDefault(x => x.ID_KycCheckList == kycId && x.verified == true);

        if (alreadyVerified != null) return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            hasError = true,
            message = $"{alreadyVerified.description} ,has been Verified,you cannot re-upload"
        });
        var isSaved = await _service.KycService.UpdateIbsPeopleKyc(ucid, kycId, fileByte, fileExtension);

        if (isSaved) return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status200OK,
            message = "User details updated",
            hasError = false,
        });

        return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
        {
            statusCode = StatusCodes.Status400BadRequest,
            message = "No change made to the user details",
            hasError = true
        });
    }
}
