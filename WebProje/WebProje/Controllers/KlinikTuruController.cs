using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using WebProje.Utility;

namespace WebProje.Controllers
{
    public class KlinikTuruController : Controller
    {
        private readonly HastaneRandevuDbContext _hastaneRandevuDbContext;

        public KlinikTuruController(HastaneRandevuDbContext context)
        {
            _hastaneRandevuDbContext = context;
        }

        public IActionResult Index()
        {
            List<KlinikTuru>NsnKlinikTuruList= _hastaneRandevuDbContext.KlinikTurleri.ToList();
            return View(NsnKlinikTuruList);
        }
    }
}
