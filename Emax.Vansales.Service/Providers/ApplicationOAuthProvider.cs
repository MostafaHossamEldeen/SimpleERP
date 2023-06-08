using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Emax.Vansales.Service.Models;
using Emax.Dal;
using Emax.SharedLib;

namespace Emax.Vansales.Service.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
           
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);
            //-- add compney data
           var dtcomp= SqlCommandHelper.ExcecuteToDataTable("sys_company_sel").dataTable; 
            var dtsetting = SqlCommandHelper.ExcecuteToDataTable("sys_setting_sel").dataTable;
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("user_id", user.Id);

            var dtuserprop = SqlCommandHelper.ExcecuteToDataTable("sys_userprepsinglerow_sel", dict,false).dataTable;
            var dtadvancepayment = SqlCommandHelper.ExcecuteToDataTable("rec_charts", 
                new Dictionary<object, object> { { "branchid", dtuserprop.Rows[0]["branchid"] } }).dataTable;

            AuthenticationProperties properties = CreateProperties(user.UserName, user.Id, dtcomp.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtcomp.Rows[0]["compname"]) : ""
                , dtcomp.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtcomp.Rows[0]["compvatno"]) : ""
                , dtcomp.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtcomp.Rows[0]["compact"]) : "",
                dtcomp.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtcomp.Rows[0]["complogo"]) : ""
                , dtsetting.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtsetting.Rows[0]["vattype"]) : ""
               , dtsetting.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtsetting.Rows[0]["vat"]) : "", 
                dtsetting.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtsetting.Rows[0]["autoitem"]) : "false",
                dtuserprop.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtuserprop.Rows[0]["branchid"]) : "",
                dtuserprop.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtuserprop.Rows[0]["branchname"]) : ""
                , dtuserprop.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtuserprop.Rows[0]["uyear"]) : ""
                , dtsetting.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtsetting.Rows[0]["autoemp"]) : "false"
                , dtsetting.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtsetting.Rows[0]["printno"]) : "1"
                , dtsetting.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtsetting.Rows[0]["sprice"]) : "false"
                , dtsetting.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtsetting.Rows[0]["wpitem"]) : "false"
                , dtsetting.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtsetting.Rows[0]["wpitemdigit"]) : "0",
                dtadvancepayment.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtadvancepayment.Rows[0]["chartid"]) : "0",
               dtadvancepayment.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtadvancepayment.Rows[0]["chartcode"]) : "0",
               dtadvancepayment.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtadvancepayment.Rows[0]["chartname"]) : "0",
               dtuserprop.Rows.Count != 0 ? EmaxGlobals.NullToEmpty(dtuserprop.Rows[0]["udiscperitem"]) : "0");

            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties( string userName,string userid
            ,string copmneyname,string compvatno, string compact,string complogo,string vattype,string vat,string autoitem,
            string branchid,string branchname,string fyear, string autoemp , string printno , string sprice , string wpitem , string wpitemdigit
            ,string advancedpaymentid,string advancedpaymentcode,string advancedpaymentname, string udiscperitem)
        {
            
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                  { "userName", userName },{ "userid",userid},{ "compneyName",copmneyname},{ "compvatno",compvatno},{ "compact",compact},{ "complogo",complogo}

                ,{ "vattype",vattype},{ "vat",vat},{ "autoitem",autoitem} ,{"branchid",branchid},{"branchname",branchname}

            ,{"fyear",fyear},{ "autoemp",autoemp} , { "printno",printno}, { "sprice",sprice}, { "wpitem",wpitem}, { "wpitemdigit",wpitemdigit},
            { "advancedpaymentchartid",advancedpaymentid},{ "advancedpaymentchartcode",advancedpaymentcode},{ "advancedpaymentchartname",advancedpaymentname},{ "udiscperitem",udiscperitem}};
            return new AuthenticationProperties(data);
        }
    }
}