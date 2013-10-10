using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentanaFinal.Interfaces
{
    public interface IMembership
    {
        bool CreateAccount(string email, string password, string userRole, bool confirm, object propertyValues);
        bool LoginUser(string username, string password);
        bool ConfirmAccount(string confirmationToken);
        int UserId();
        bool LogoutUser();
        Tuple<int, string> GetCompanyIdAndName();
    }
}
