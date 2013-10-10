using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using VentanaFinal.Core;
using VentanaFinal.Interfaces;
using WebMatrix.WebData;
using VentanaFinal.Core.Interfaces;

namespace VentanaFinal.Services
{
    public class Membership : IMembership
    {
        private IRepository Repository;

        public Membership(IRepository repository)
        {
            this.Repository = repository;
        }

        public bool CreateAccount(string email, string password, string userRole, bool confirm, object propertyValues)
        {
            WebSecurity.CreateUserAndAccount(email, password, propertyValues, confirm);
            Roles.AddUserToRole(email, userRole);
            return true;
        }

        public bool LoginUser(string username, string password)
        {
            return WebSecurity.Login(username, password);
        }

        public bool ConfirmAccount(string confirmationToken)
        {
            return WebSecurity.ConfirmAccount(confirmationToken);
        }

        public bool LogoutUser()
        {
            WebSecurity.Logout();
            return true;
        }

        public int UserId()
        {
            return WebSecurity.CurrentUserId;
        }

        public Tuple<int, string> GetCompanyIdAndName()
        {
            Company company = this.Repository.Single<UserProfile>(x => x.id_user == WebSecurity.CurrentUserId).Company;
            return new Tuple<int, string>(company.id_company, company.CompanyName);
        }
    }
}