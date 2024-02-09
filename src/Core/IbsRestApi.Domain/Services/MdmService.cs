using IbsRestApi.Application.AuthModels;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Entities.IbsMdm;
//using IbsRestApi.Entities.iMoneytor;
using IbsRestApi.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace IbsRestApi.Domain.Services;

public class MdmService : IMdmService
{
    private readonly MdmContext _context;

    public MdmService(MdmContext context)
    {
        _context = context;
    }

    public async Task<PeopleViewModel> GetPersonByUCID(int ucid)
    {
        return await _context.IbsPeople.AsNoTracking().Where(p => p.Ucid == ucid).Select(x => new PeopleViewModel()
        {
            ucid = x.Ucid,
            pccNumber = x.PccNo,
            firstName = x.FirstName,
            lastName = x.LastName,
            otherName = x.OtherNames,
            email = x.Email,
            addressLine1 = x.Address01,
            addressLine2 = x.Address02,
            Bvn = x.Bvn,
            phoneNumber = x.MobilePhone,
        }).FirstOrDefaultAsync();
    }

    public async Task<PeopleViewModel> FetchPeopleByEmail(string email)
    {
        return await _context.IbsPeople.AsNoTracking().Where(p => p.Email == email.Trim()).Select(x => new PeopleViewModel()
        {
            ucid = x.Ucid,
            pccNumber = x.PccNo,
            firstName = x.FirstName,
            lastName = x.LastName,
            email = x.Email,
            addressLine1 = x.Address01,
            addressLine2 = x.Address02,
            Bvn = x.Bvn,
            phoneNumber = x.MobilePhone,
            dateOfBirth = x.Dob
        }).FirstOrDefaultAsync();
    }

    public async Task<PeopleViewModel> UpdatePerson(PeopleViewModel model, int ucid)
    {
        var person = _context.IbsPeople.FirstOrDefault(x => x.Ucid == ucid);
        if (person != null)
        {
            person.FirstName = model.firstName;
            person.LastName = model.lastName;
            //person.Email = model.email;
            person.OtherNames = model.otherName;
            person.Bvn = model.Bvn;
            person.MobilePhone = model.phoneNumber;
            person.Dob = model.dateOfBirth;
            person.Address01 = model.addressLine1;
            person.IdOccupation = model.occupationId;
            person.IdState = model.idState;
            person.IdCountry = model.idCountry;
            person.Title = model.title;
            person.Gender = model.gender;
            person.Comments += "Updated by " + ucid + " on " + DateTime.Now + " | ";
            person.IdSourceOfFunds = model.sourceOfFund;
            person.MaritalStatus = model.maritalStatus;


            var savePerson = await _context.SaveChangesAsync();

            return _context.IbsPeople.AsNoTracking().Where(p => p.Ucid == ucid).Select(x => new PeopleViewModel()
            {
                ucid = x.Ucid,
                pccNumber = x.PccNo,
                firstName = x.FirstName,
                lastName = x.LastName,
                email = x.Email,
                addressLine1 = x.Address01,
                addressLine2 = x.Address02,
                Bvn = x.Bvn,
                phoneNumber = x.MobilePhone,
            }).FirstOrDefault();
        }
        else
        {
            return null;
        }
    }

    public async Task<bool> SavePersonProfilePicturePath(string path, int ucid)
    {
        var person = _context.IbsPeople.FirstOrDefault(x => x.Ucid == ucid);
        if (person != null)
        {
            person.ProfilePictureUrl = path;
        }
        return await _context.SaveChangesAsync() > 0;
    }

    public string FetchPersonProfilePicturePath(int ucid)
    {
        var person = _context.IbsPeople.AsNoTracking().FirstOrDefault(x => x.Ucid == ucid);
        var path = "";
        if (person != null)
        {
            path = string.IsNullOrEmpty(person.ProfilePictureUrl) ? "" : person.ProfilePictureUrl;
        }
        return path;
    }

    public async Task UpdatePerson(OnlineUserAccount model)
    {
        var person = _context.OnlineUserAccounts.FirstOrDefault(x => x.Ucid == model.Ucid);
        if (person != null)
        {
            person.Email = model.Email;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<PeopleViewModel> AddPerson(PeopleViewModel model)
    {
        var pccNumber = await GeneratePccNumber(DateTime.Now, string.Empty);
        var person = new IbsPerson()
        {
            PccNo = pccNumber,
            Address01 = model.addressLine1,
            Address02 = model.addressLine2,
            Bvn = model.Bvn,
            CreationDate = DateTime.Now,
            Status = "P",
            FirstName = model.firstName,
            LastName = model.lastName,
            IdCustomerType = "IND",
            Customer = true,
            Comments = $"People created with API on {DateTime.Now};",
            DatabaseName = "",
            Email = model.email,
            KycComplete = false,
            MobilePhone = model.phoneNumber,
            Dob = model.dateOfBirth,
            IdApplication = "API",
            IdOccupation = model.occupationId,
            IdState = model.idState,
            IdCountry = model.idCountry,
            Title = model.title,
            Gender = model.gender,
            IdSourceOfFunds = model.sourceOfFund,
            MaritalStatus = model.maritalStatus
        };

        _context.IbsPeople.Add(person);

        var savePerson = await _context.SaveChangesAsync();

        if (savePerson > 0)
        {
            return _context.IbsPeople.AsNoTracking().Where(p => p.PccNo == pccNumber).Select(x => new PeopleViewModel()
            {

                ucid = x.Ucid,
                pccNumber = pccNumber,
                firstName = x.FirstName,
                lastName = x.LastName,
                email = x.Email,
                addressLine1 = x.Address01,
                addressLine2 = x.Address02,
                Bvn = x.Bvn,
                phoneNumber = x.MobilePhone,
            }).FirstOrDefault();
        }
        else
        {
            return null;
        }
    }

    public async Task<string> GeneratePccNumber(DateTime CreationDate, string PccNo)
    {
        var PccNoParam = new SqlParameter
        {
            ParameterName = "@PccNo",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.VarChar,
            Size = 20
        };
        var prem = await _context.Database.ExecuteSqlRawAsync("Universal_sp_CreatePccNo @CreationDate, @PccNo OUT",
            new SqlParameter("@CreationDate", CreationDate), PccNoParam);

        if (PccNoParam.Value != null)
        {
            return Convert.ToString(PccNoParam.Value);
        }
        return string.Empty;
    }

    public bool CreateUserAccount(OnlineUserAccount model)
    {
        _context.OnlineUserAccounts.Add(model);

        return _context.SaveChanges() > 0;
    }

    public async Task<PersonBasicInfoViewModel> FetchCustomerByUCID(int ucid)
    {
        var person = await _context.IbsPeople.AsNoTracking().FirstOrDefaultAsync(x => x.Ucid == ucid);

        if (person == null) return new PersonBasicInfoViewModel();

        return new PersonBasicInfoViewModel()
        {
            ucid = person.Ucid,
            accountNumber = person.PccNo,
            lastName = person.LastName,
            name = person.LastName,
            Othername = person.OtherNames,
            firstName = person.FirstName,
            address_line1 = person.Address01,
            address_line2 = person.Address02,
            dateOfbirth = person.Dob.HasValue ? person.Dob.Value : DateTime.Now,
            email = person.Email,
            mobile_phone = person.MobilePhone,
            showDate = person.Dob.HasValue,
            bvn = person.Bvn,
            PhotoImage = person.ProfilePictureUrl
        };
    }

    public void UpdateToken(string email)
    {
        var target = _context.PasswordResetRequests.FirstOrDefault(x => x.Email == email);

        if (target != null)
        {
            target.IsUsed = true;
            target.ExpiryDate = DateTime.Now.AddDays(-1);

            _context.SaveChanges();
        }

    }

    public string GeneratePasswordResetLink(string email, bool isMobile = false)
    {
        var str = generateRandomString(40);

        if (isMobile)
        {
            str = generateRandomNumber(7);
        }

        var link = new PasswordResetRequest()
        {
            Email = email,
            ExpiryDate = DateTime.Now.AddMinutes(90),
            IsUsed = false,
            Token = str
        };

        _context.PasswordResetRequests.Add(link);
        _context.SaveChanges();
        return str;
    }

    public async Task<bool> IsPasswordResetTokenExpires(string token)
    {
        bool result = false;
        var data = await _context.PasswordResetRequests.AsNoTracking().FirstOrDefaultAsync(x => x.Token == token);
        if (data != null)
        {
            var expiredDate = data.ExpiryDate;
            if (expiredDate < DateTime.Now)
            {
                result = true;
            }
        }
        return result;

    }
    public async Task<string> GetPasswordRequest(string token)
    {
        OnlineUserAccount result = null;
        var req = await _context.PasswordResetRequests.AsNoTracking().FirstOrDefaultAsync(x => x.Token == token);
        if (req != null)
        {
            result = await _context.OnlineUserAccounts.AsNoTracking().FirstOrDefaultAsync(x => x.Email.ToLower() == req.Email.ToLower());
        }
        return result != null ? result.Email : string.Empty;

    }

    public async Task<bool> ResetPassword(PasswordResetModel model)
    {
        var requestRecord = await _context.PasswordResetRequests
            .FirstOrDefaultAsync(x => x.Token == model.token);

        if (requestRecord == null) return false;

        var targetUser = await _context.OnlineUserAccounts.FirstOrDefaultAsync(x => x.Email == requestRecord.Email);

        if (targetUser == null) return false;

        targetUser.Password = model.password;
        targetUser.LastLoginDate = DateTime.Now;
        targetUser.NextPasswordChangeDate = DateTime.Now.AddDays(90);
        requestRecord.IsUsed = true;

        var passHist = new PasswordChangeHistory()
        {
            ChangeDate = DateTime.Now,
            Password = model.password,
            Username = targetUser.Email
        };

        _context.PasswordChangeHistories.Add(passHist);

        return await _context.SaveChangesAsync() > 0;

    }
    public async Task<bool> ChangeuserPasswordAsync(ChangePasswordViewModel model)
    {
        var user = _context.OnlineUserAccounts.Where(x => x.LoginPin == model.accountId && x.Password == model.oldpassword).FirstOrDefault();
        if (user != null)
        {
            user.Password = model.newpassword;
            user.LastLoginDate = DateTime.Now.Date;
        }
        return await _context.SaveChangesAsync() > 0;
    }

    public IQueryable<IbsPeopleNextOfKinModel> FetchPersonNOK(int ucid)
    {
        return from x in _context.IbsPeopleNextOfKins.AsNoTracking()
               join r in _context.RelationShips.AsNoTracking()
               on x.IdRelationShip equals r.IdRelationShip
               where x.Ucid == ucid
               select new IbsPeopleNextOfKinModel()
               {
                   firstName = x.FirstName,
                   lastName = x.LastName,
                   otherName = x.OtherNames,
                   address = x.Address01,
                   phoneNumber = x.MobilePhone,
                   idRelationship = x.IdRelationShip,
                   relationship = r.RelationShip1,
                   email = x.Email,
                   client_unique_ref = x.Ucid ?? 0,
                   id = x.IdNextOfKin
               };
    }

    public IQueryable<IbsPeopleBankAccountModel> GetPersonBankAccounts(int ucid)
    {
        return from x in _context.IbsPeopleBankAccounts.AsNoTracking()
               join r in _context.IbsBanks.AsNoTracking()
               on x.IdBank equals r.IdBank
               where x.Ucid == ucid
               select new IbsPeopleBankAccountModel()
               {
                   IdBank = x.IdBank,
                   AccountName = x.AccountName,
                   AccountNumber = x.AccountNumber,
                   client_unique_ref = x.Ucid ?? 0,
                   BankName = r.BankName,
                   id = x.IdBankAccount,
                   Bvn = x.Bvn
               };
    }

    public IQueryable<IbsPeopleMinorModel> FetchCustomersMinior(int ucid)
    {
        return _context.IbsPeople.AsNoTracking().Where(x => x.ParrentUCID == ucid).Select(person => new IbsPeopleMinorModel()
        {
            ucid = person.Ucid,
            accountNumber = person.PccNo,
            lastName = person.LastName,
            othername = person.OtherNames,
            firstName = person.FirstName,
            address_line1 = person.Address01,
            address_line2 = person.Address02,
            dateOfbirth = person.Dob.HasValue ? person.Dob.Value.ToString("dd/MM/yyyy") : "",
            email = person.Email,
            mobile_phone = person.MobilePhone,
            parrentUCID = person.ParrentUCID ?? 0
        });
    }

    public IQueryable<RelationShip> GetRelationShips()
    {
        return _context.RelationShips.AsNoTracking();
    }

    public IQueryable<BankViewModel> ListAllBanks()
    {
        return _context.IbsBanks.AsNoTracking().
            Where(b => b.BankCode != null || b.BankCode != string.Empty).
            Select(x => new BankViewModel
            {
                bankId = x.IdBank,
                bankCode = x.BankCode,
                bankName = x.BankName
            });
    }

    public async Task<bool> UpdateNextOfKin(IbsPeopleNextOfKinModel model, int id)
    {
        var nextOfKin = _context.IbsPeopleNextOfKins.FirstOrDefault(x => x.IdNextOfKin == id);
        if (nextOfKin != null)
        {
            nextOfKin.Email = model.email;
            nextOfKin.FirstName = model.firstName;
            nextOfKin.LastName = model.lastName;
            nextOfKin.OtherNames = string.IsNullOrWhiteSpace(model.otherName) ? " " : model.otherName;
            nextOfKin.Address01 = model.address;
            model.phoneNumber = model.phoneNumber;
            model.idRelationship = model.idRelationship;
        }
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> AddNextOfKin(IbsPeopleNextOfKinModel model)
    {
        var nextOfKin = new IbsPeopleNextOfKin()
        {
            FirstName = model.firstName,
            LastName = model.lastName,
            OtherNames = model.otherName,
            Email = model.email,
            Address01 = model.address,
            MobilePhone = model.phoneNumber,
            IdRelationShip = model.idRelationship ?? 0,
            Ucid = model.client_unique_ref,
        };
        _context.IbsPeopleNextOfKins.Add(nextOfKin);
        await _context.SaveChangesAsync();
        return nextOfKin.IdNextOfKin;
    }

    public async Task<bool> UpdatePersonMinor(IbsPeopleMinorUpdateModel model, int ucid)
    {
        var minor = _context.IbsPeople.FirstOrDefault(x => x.Ucid == ucid);
        if (minor != null)
        {
            minor.Address01 = model.address_line1;
            minor.Address02 = model.address_line1;
            minor.FirstName = model.firstName;
            minor.LastName = model.lastName;
            minor.OtherNames = string.IsNullOrWhiteSpace(model.othername) ? " " : model.othername;
            minor.Email = model.email;
            minor.MobilePhone = model.mobile_phone;
            minor.Dob = model.dob;
        }
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdatePersonBankAccount(IbsPeopleBankAccountModel model, int id)
    {
        var bankAccount = _context.IbsPeopleBankAccounts.FirstOrDefault(x => x.IdBankAccount == id);
        if (bankAccount != null)
        {
            bankAccount.AccountName = model.AccountName;
            bankAccount.AccountNumber = model.AccountNumber;
            bankAccount.IdBank = model.IdBank;
            bankAccount.Bvn = model.Bvn;
            bankAccount.Ucid = model.client_unique_ref;
        }
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletePersonBankAccount(int id, int ucid)
    {
        var bankAccount = _context.IbsPeopleBankAccounts.FirstOrDefault(x => x.IdBankAccount == id && x.Ucid == ucid);
        if (bankAccount != null)
        {
            _context.IbsPeopleBankAccounts.Remove(bankAccount);
        }
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> AddPersonBankAccount(IbsPeopleBankAccountModel model)
    {
        var bankAccount = new IbsPeopleBankAccount()
        {
            AccountNumber = model.AccountNumber,
            IdBank = model.IdBank,
            Bvn = model.Bvn,
            Ucid = model.client_unique_ref,
            AccountName = model.AccountName,
        };
        _context.IbsPeopleBankAccounts.Add(bankAccount);
        await _context.SaveChangesAsync();
        return bankAccount.IdBankAccount;
    }

    public async Task<int> AddPersonMinor(IbsPeopleMinorUpdateModel model)
    {
        var pccNumber = await GeneratePccNumber(DateTime.Now, string.Empty);
        var person = new IbsPerson()
        {
            PccNo = pccNumber,
            Address01 = model.address_line1,
            Address02 = model.address_line1,
            CreationDate = DateTime.Now,
            Status = "P",
            FirstName = model.firstName,
            LastName = model.lastName,
            OtherNames = model.othername,
            IdCustomerType = "IND",
            Customer = true,
            Comments = $"People created via API on {DateTime.Now};",
            DatabaseName = "",
            Email = model.email,
            KycComplete = false,
            MobilePhone = model.mobile_phone,
            Dob = model.dob,
            IdApplication = "API",
            ParrentUCID = model.client_unique_ref
        };

        _context.IbsPeople.Add(person);
        await _context.SaveChangesAsync();
        return person.Ucid;
    }

    public CurrencyAccountMapping FetchBankByCurrency(string currencyId)
    {
        return _context.CurrencyAccountMappings.AsNoTracking().FirstOrDefault(c => c.IdCurrency == currencyId);

    }

    public string FetchCustomerType(int ucid)
    {
        var customerType = "IND";
        var person = _context.IbsPeople.AsNoTracking().FirstOrDefault(x => x.Ucid == ucid);
        if (person != null)
        {
            customerType = person.IdCustomerType;
        }
        return customerType;
    }
    public IQueryable<IbsCountry> GetCountries()
    {
        return _context.IbsCountries.AsNoTracking();
    }
    public IQueryable<IbsState> GetStates()
    {
        return _context.IbsStates.Select(x => new IbsState
        {
            IdState = x.IdState,
            Title = x.Title.Trim(),
            IdCountry = x.IdCountry
        }).AsNoTracking();
    }
    public IQueryable<IbsTitle> GetTitles()
    {
        return _context.IbsTitles.AsNoTracking();
    }
    public IQueryable<IbsOccupation> GetOccupations()
    {
        return _context.IbsOccupations.AsNoTracking();
    }

    public IQueryable<SourceOfFund> GetSourceOfFund()
    {
        return _context.SourceOfFunds.AsNoTracking();
    }
    public async Task<bool> LogWebHookRequest(WebHookModel req)
    {
        var hookReq = new VfdBankWebHookLog()
        {
            Amount = req.amount,
            DateLogged = req.loggedDate,
            OriginAccount = req.originAccount,
            OriginAccountName = req.originAccountName,
            OriginBank = req.originBank,
            OriginNarration = req.originNarration,
            RawPayload = req.rawPayload,
            ReferenceNo = req.referenceNo,
            TransactionTimeStamp = req.transactionTimeStamp,
            WalletAccountNo = req.walletAccountNo
        };

        await _context.VfdBankWebHookLogs.AddAsync(hookReq);


        return await _context.SaveChangesAsync() > 0;
    }
    #region Helpers
    private string generateRandomString(int length)
    {
        Random random = new Random();
        string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        StringBuilder result = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            result.Append(characters[random.Next(characters.Length)]);
        }
        return result.ToString();
    }
    private string generateRandomNumber(int length)
    {
        Random random = new Random();
        string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        StringBuilder result = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            result.Append(characters[random.Next(characters.Length)]);
        }
        return result.ToString();
    }
    #endregion
}
