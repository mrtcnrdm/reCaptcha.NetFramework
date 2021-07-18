using Newtonsoft.Json;
using System.Net;
using System.Web.Mvc;

namespace reCaptcha.NetFramework.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.reCaptcha response)
        {
            Recaptcha();
            if (check)
            {
                //ok
                return View();
            }
            else
            {
                //error
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                return View();
            }
        }

        private bool check;

        public void Recaptcha()
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "secret-key";
            var client = new WebClient();
            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));

            var captchaResponse = JsonConvert.DeserializeObject<Models.reCaptcha>(GoogleReply);
            if (captchaResponse.Success)

                check = true;
            else

                check = false;
        }
    }
}