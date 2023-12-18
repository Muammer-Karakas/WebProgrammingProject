using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using WebProje.Utility;

namespace WebProje.Controllers
{
    public class DoktorlarTablosuController : Controller
    {
        private readonly IDoktorlarTablosuRepository _doktorlarTablosuRepository;

        public DoktorlarTablosuController(IDoktorlarTablosuRepository context)
        {
            _doktorlarTablosuRepository = context;
        }

        public IActionResult Index()
        {
            List<DoktorlarTablosu>NsnDoktorlarTablosuList= _doktorlarTablosuRepository.GetAll().ToList();
            return View(NsnDoktorlarTablosuList);
        }

        public IActionResult KlinikEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KlinikEkle(DoktorlarTablosu doktorlarTablosu)
        {

            if(ModelState.IsValid) 
            {
                _doktorlarTablosuRepository.Ekle(doktorlarTablosu);
                _doktorlarTablosuRepository.Kaydet();         //bilgileri veritabanına ekler
                TempData["Basarili"] = "Doktor Oluşturma İşlemi Başarılı.";
            return RedirectToAction("Index","DoktorlarTablosu");

            }
            return View();
        }

        public IActionResult KlinikGuncelle(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            DoktorlarTablosu? doktorlarTablosuDb = _doktorlarTablosuRepository.Get(u => u.DoktorId == id);
            if(doktorlarTablosuDb == null)
            {
                return NotFound();
            }
            return View(doktorlarTablosuDb);
        }

        [HttpPost]
        public IActionResult KlinikGuncelle(DoktorlarTablosu doktorlarTablosu)
        {

            if (ModelState.IsValid)
            {
                _doktorlarTablosuRepository.Guncelle(doktorlarTablosu);
                _doktorlarTablosuRepository.Kaydet();      //bilgileri veritabanına ekler
                TempData["Basarili"] = "Doktor Güncelleme İşlemi Başarılı.";
                return RedirectToAction("Index", "DoktorlarTablosu");

            }
            return View();
        }

            public IActionResult KlinikSil(int? id)
            {
                if (id == 0 || id == null)
                {
                    return NotFound();
                }
            DoktorlarTablosu? doktorlarTablosuDb = _doktorlarTablosuRepository.Get(u => u.DoktorId == id);
                if (doktorlarTablosuDb == null)
                {
                    return NotFound();
                }
                return View(doktorlarTablosuDb);
            }

        [HttpPost, ActionName("KlinikSil")]
        public IActionResult KlinikSill(int? id)
        {
            DoktorlarTablosu? doktorlarTablosu = _doktorlarTablosuRepository.Get(u => u.DoktorId == id);
            if(doktorlarTablosu == null)
            {
                return NotFound();
            }
            _doktorlarTablosuRepository.Sil(doktorlarTablosu);
            _doktorlarTablosuRepository.Kaydet();
            TempData["Basarili"] = " Doktor Silme İşlemi Başarılı.";
            return RedirectToAction("Index", "DoktorlarTablosu");

        }

    }
}

