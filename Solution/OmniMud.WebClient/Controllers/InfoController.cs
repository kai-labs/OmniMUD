using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OmniMud.WebClient.Controllers
{
    //[Authorize]
    public class InfoController : Controller
    {
        public IActionResult GoogleHeaders()
        {
            var googleHeaders = new List<string>
            {
                "X-MS-TOKEN-GOOGLE-ID-TOKEN",
                "X-MS-TOKEN-GOOGLE-ACCESS-TOKEN",
                "X-MS-TOKEN-GOOGLE-EXPIRES-ON",
                "X-MS-TOKEN-GOOGLE-REFRESH-TOKEN"
            };

            var output = Request.Headers
                .Where(kvp => googleHeaders.Contains(kvp.Key))
                .ToList();

            return View(output);
        }
    }
}
