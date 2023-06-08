using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VanSales.Service.Controllers
{
  //  [Authorize]
   // [EnableCors(origins: CORS_Params.origins, headers: CORS_Params.headers, methods: CORS_Params.methods)]
    [Route("api/User/{action}/", Name = "User")]
    public class UserController : ApiController
    {
        //protected readonly IUnitOfWork unitOfWork;
        //protected readonly IUnitOfWork viewsUnitOfWork;

        //public UserController()
        //{
        //    unitOfWork = ApiDependencyInjector.GetUnitOfWork();
        //    viewsUnitOfWork = ApiDependencyInjector.GetViewsUnitOfWork();
        //}


        //[HttpPost]
        //public virtual HttpResponseMessage GetUserInfo(StringData requestData)
        //{
        //    var userRepository = unitOfWork.GetRepository<C_User>();
        //    var formsRepository = viewsUnitOfWork.GetRepository<qrFormPermision>();

        //    var user = userRepository.SingleOrDefault(e => e.User_ID == requestData.data);

        //    if (user == null)
        //    {
        //        return this.Request.CreateResponse(NotFound());
        //    }

        //    UserInfo userInfo = new UserInfo
        //    {
        //        UserId = user.User_ID,
        //        EmpId = user.Emp_ID,
        //        UserName = user.User_Name,
        //        DepartmentId = user.Department_ID,
        //        Forms = formsRepository.Getall()
        //        .Where(e => e.User_ID == user.User_ID)
        //        .Select(e => new UserForm
        //        {
        //            FormID = e.Form_ID,
        //            UserPermissions = new UserEditorPermissions
        //            {
        //                CanAdd = e.CanAdd ?? false,
        //                CanDelete = e.CanDelete ?? false,
        //                CanEntry = e.CanEntry ?? false,
        //                CanOpen = e.CanOpen ?? false,
        //                CanPost = e.CanPost ?? false,
        //                CanPrice = e.CanPrice ?? false,
        //                CanUpdate = e.CanUpdate ?? false,
        //                CanViewReport = e.CanViewReport ?? false

        //            }
        //        }).ToList()
        //    };


        //    HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.OK);
        //    response.Headers.Location = this.Request.RequestUri;
        //    response.Content = new StringContent(JsonConvert.SerializeObject(userInfo), System.Text.Encoding.UTF8, "application/json");
        //    return response;
        //}
    }
}
