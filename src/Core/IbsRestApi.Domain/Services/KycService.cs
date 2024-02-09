using IbsRestApi.Application.Kyc;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IbsRestApi.Domain.Services;

public class KycService : IKycService
{
    private readonly DmsMoneyBookContext _context;
    private readonly MdmContext _mdmContext;

    public KycService(DmsMoneyBookContext context, MdmContext mdmContext)
    {
        _context = context;
        _mdmContext = mdmContext;
    }

    public IQueryable<PeopleKycCheckList> PeopleKycCheckListsQueryable(int ucid, string ID_CustomerType = "IND")
    {
        return from k in _context.KycChecklists.AsNoTracking()
               join y in _context.IbsPeopleKycs.AsNoTracking() on k.IdKycCheckList equals y.IdKycCheckList
               where y.Ucid == ucid && (k.CustomerTypeList == ID_CustomerType || k.RequestForAll == true)

               select new PeopleKycCheckList
               {
                   ID_KycCheckList = k.IdKycCheckList,
                   description = k.CheckList,
                   verified = y.Verified.HasValue ? y.Verified.Value : false,
                   verifiedText = y.Verified.Value == true ? "Yes" : "No",
                   FileExtension = y.FileExtension,
                   Submitted = y.Submitted.Value == true ? "Yes" : "No",
                   ucid = y.Ucid.HasValue ? y.Ucid.Value : ucid
               };
    }
    
    public async Task SaveIbsPeopleKyc(int UCID, decimal Amount, string ID_CustomerType = "IND")
    {
        await _context.Database.ExecuteSqlRawAsync("OnBoarding_sp_Create_KYC_Required @UCID," +
        "@ID_CustomerType,@Amount", new SqlParameter("@UCID", UCID),
        new SqlParameter("@ID_CustomerType", ID_CustomerType),
        new SqlParameter("@Amount", Amount));
    }

    public async Task<bool> UpdateIbsPeopleKyc(int UCID, int kycId, byte[] docImage, string fileExtension)
    {
        var isUpdated = false;

        var person = _mdmContext.IbsPeople.AsNoTracking().FirstOrDefault(c => c.Ucid == UCID);
        var lastname = person != null ? person.LastName : "";
        var waived = false;
        var summitted = true;
        var verifiedBy = string.Empty;
        DateTime? verifiedDate = DateTime.Now.Date;
        DateTime today = DateTime.Now.Date;
        if (fileExtension.Length > 4)
        {
            fileExtension = fileExtension.Substring(fileExtension.Length - 4);
        }
        //update IbsPeopleKyc where ucid equals ucid and kycid equals kycid
        var ibsPeopleKyc = _context.IbsPeopleKycs.Where(c => c.Ucid == UCID && c.IdKycCheckList == kycId).FirstOrDefault();
        if (ibsPeopleKyc != null)
        {
            ibsPeopleKyc.Submitted = summitted;
            ibsPeopleKyc.Waived = waived;
            ibsPeopleKyc.ActionDate = today;
            ibsPeopleKyc.ActionBy = lastname;
            ibsPeopleKyc.Verified = waived;
            ibsPeopleKyc.VerifiedBy = verifiedBy;
            ibsPeopleKyc.VerifiedDate = verifiedDate;
            ibsPeopleKyc.DocImage = docImage;
            ibsPeopleKyc.FileExtension = fileExtension;
            await _context.SaveChangesAsync();
        }
        await _context.Database.ExecuteSqlRawAsync("OnBoarding_sp_Update_KYC_Status @UCID", new SqlParameter("@UCID", UCID));
        isUpdated = true;
        return isUpdated;
    }
}
