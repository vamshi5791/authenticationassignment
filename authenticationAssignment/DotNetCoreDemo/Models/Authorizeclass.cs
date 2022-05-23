using DotNetCoreDemo.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.Data.SqlClient;

namespace DotNetCoreDemo.Models
{
    public class AuthorizeMe:IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            SqlConnection cn = new SqlConnection("Server=GOVINDHUV\\SQLEXPRESS;Database=BookListRazor;Trusted_Connection=True;");
            cn.Open();

            LoginModel log=new LoginModel();
            if (log.username == "" && log.possword == "")
            {
                Console.WriteLine("login successfull");
            }
            else
            {
                Console.WriteLine("invalid credentials");
            }
        }

        
    }
}
