using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ColorWeb.Pages
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
                APIUrl = "https://markcolorapi.azurewebsites.net/api/randomcolor";
        }


        public IActionResult OnPost()
        {
            if (APIUrl != null)
            {
                Response.Cookies.Append("APIUrl", APIUrl,
                    new CookieOptions
                    {
                        HttpOnly = false,
                        Secure = false,
                        Expires = DateTime.Now.AddMonths(12)
                    }
                );
                return RedirectToPage("/Default");
            }

            return RedirectToPage("/Config");
        }
    }
}