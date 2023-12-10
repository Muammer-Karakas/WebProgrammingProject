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

            if(ModelState.IsValid) 
            {
            _hastaneRandevuDbContext.KlinikTurleri.Add(klinikTuru);
            _hastaneRandevuDbContext.SaveChanges();      //bilgileri veritabanına ekler
            return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult KlinikGuncelle(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            KlinikTuru? klinikTuruDb = _hastaneRandevuDbContext.KlinikTurleri.Find(id);
            if(klinikTuruDb == null)
            {
                return NotFound();
            }
            return View(klinikTuruDb);
        }

        [HttpPost]
        public IActionResult KlinikGuncelle(KlinikTuru klinikTuru)
        {

            if (ModelState.IsValid)
            {
                _hastaneRandevuDbContext.KlinikTurleri.Update(klinikTuru);
                _hastaneRandevuDbContext.SaveChanges();      //bilgileri veritabanına ekler
                return RedirectToAction("Index");

            }
            return View();
        }

            public IActionResult KlinikSil(int? id)
            {
                if (id == 0 || id == null)
                {
                    return NotFound();
                }
                KlinikTuru? klinikTuruDb = _hastaneRandevuDbContext.KlinikTurleri.Find(id);
                if (klinikTuruDb == null)
                {
                    return NotFound();
                }
                return View(klinikTuruDb);
            }

        [HttpPost, ActionName("KlinikSil")]
        public IActionResult KlinikSill(int? id)
        {
            KlinikTuru? klinikTuru = _hastaneRandevuDbContext.KlinikTurleri.Find(id);
            if(klinikTuru == null)
            {
                return NotFound();
            }
            _hastaneRandevuDbContext.KlinikTurleri.Remove(klinikTuru);
            _hastaneRandevuDbContext.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}

