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

        public IActionResult KlinikEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KlinikEkle(KlinikTuru klinikTuru)
        {
            _hastaneRandevuDbContext.KlinikTurleri.Add(klinikTuru);
            _hastaneRandevuDbContext.SaveChanges();      //bilgileri veritabanına ekler
            return RedirectToAction("Index");
        }
    }
}
