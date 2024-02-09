using IbsRestApi.Application.Kyc;

namespace IbsRestApi.Domain.Interfaces;

public interface IKycService
{
    IQueryable<PeopleKycCheckList> PeopleKycCheckListsQueryable(int ucid, string ID_CustomerType = "IND");
    Task SaveIbsPeopleKyc(int UCID, decimal Amount, string ID_CustomerType = "IND");
    Task<bool> UpdateIbsPeopleKyc(int UCID, int kycId, byte[] docImage, string fileExtension);
}
