using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ColorWeb
{
    public class ConfigModel : PageModel
    {
        [BindProperty]
        public string APIUrl { get; set; }

        public void OnGet()
        {
            var vURL = Request.Cookies["APIUrl"];
            if (vURL != null)
                APIUrl = vURL.ToString();
            else
                APIUrl = "http://address/";
        }

        public IActionResult OnPost()
        {
            if (APIUrl.EndsWith('/'))
                APIUrl = APIUrl.TrimEnd('/');

            Response.Cookies.Append("APIUrl", APIUrl,
                        new CookieOptions
                        {
                            HttpOnly = false,
                            Secure = false,
                            Expires = DateTime.Now.AddMonths(12)
                        }
                );

            return RedirectToPage("/Index");
        }
    }
}