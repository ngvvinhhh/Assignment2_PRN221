using CandidateManagement_BusinessObject;
using CandidateManagement_Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assigment2_SE172166.Pages
{
    public class LoginModel : PageModel
    {
        private IHRAccountRepo accountRepo;

        public LoginModel(IHRAccountRepo accountRepo)
        {
            this.accountRepo = accountRepo;
        }
        public void OnPost()
        {
            String email = Request.Form["txtEmail"];

            String password = Request.Form["txtPassword"];

            Hraccount hraccount = accountRepo.GetHraccountByEmail(email);
            if (hraccount != null && hraccount.Password.Equals(password))
            {
                HttpContext.Session.SetString("RoleID", hraccount.MemberRole.ToString());
                Response.Redirect("/CandidateProfilePage");
            }
            else
            {
                Response.Redirect("/Error");
            }


        }
    }
}
