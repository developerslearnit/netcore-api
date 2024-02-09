using IbsRestApi.Application.AuthModels;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Entities.IbsMdm;

namespace IbsRestApi.Domain.Interfaces;

public interface IMdmService
{
    Task<int> AddNextOfKin(IbsPeopleNextOfKinModel model);
    Task<PeopleViewModel> AddPerson(PeopleViewModel model);
    Task<int> AddPersonBankAccount(IbsPeopleBankAccountModel model);
    Task<int> AddPersonMinor(IbsPeopleMinorUpdateModel model);
    Task<bool> ChangeuserPasswordAsync(ChangePasswordViewModel model);
    bool CreateUserAccount(OnlineUserAccount model);
    Task<bool> DeletePersonBankAccount(int id,int ucid);
    CurrencyAccountMapping FetchBankByCurrency(string currencyId);
    Task<PersonBasicInfoViewModel> FetchCustomerByUCID(int ucid);
    IQueryable<IbsPeopleMinorModel> FetchCustomersMinior(int ucid);
    string FetchCustomerType(int ucid);
    Task<PeopleViewModel> FetchPeopleByEmail(string email);
    IQueryable<IbsPeopleNextOfKinModel> FetchPersonNOK(int ucid);
    string FetchPersonProfilePicturePath(int ucid);
    string GeneratePasswordResetLink(string email, bool isMobile = false);
    IQueryable<IbsCountry> GetCountries();
    IQueryable<IbsOccupation> GetOccupations();
    Task<string> GetPasswordRequest(string token);
    IQueryable<IbsPeopleBankAccountModel> GetPersonBankAccounts(int ucid);
    Task<PeopleViewModel> GetPersonByUCID(int ucid);
    IQueryable<RelationShip> GetRelationShips();
    IQueryable<SourceOfFund> GetSourceOfFund();
    IQueryable<IbsState> GetStates();
    IQueryable<IbsTitle> GetTitles();
    Task<bool> IsPasswordResetTokenExpires(string token);
    IQueryable<BankViewModel> ListAllBanks();
    Task<bool> LogWebHookRequest(WebHookModel req);
    Task<bool> ResetPassword(PasswordResetModel model);
    Task<bool> SavePersonProfilePicturePath(string path, int ucid);
    Task<bool> UpdateNextOfKin(IbsPeopleNextOfKinModel model, int id);
    Task<PeopleViewModel> UpdatePerson(PeopleViewModel model, int ucid);
    Task UpdatePerson(OnlineUserAccount model);
    Task<bool> UpdatePersonBankAccount(IbsPeopleBankAccountModel model, int id);
    Task<bool> UpdatePersonMinor(IbsPeopleMinorUpdateModel model, int ucid);
    void UpdateToken(string email);
}
