using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using WebProje.Utility;

namespace WebProje.Controllers
{
    public class KlinikTuruController : Controller
    {
        private readonly IKlinikTuruRepository _klinikTuruRepository;

        public KlinikTuruController(IKlinikTuruRepository context)
        {
            _klinikTuruRepository = context;
        }

        public IActionResult Index()
        {
            List<KlinikTuru>NsnKlinikTuruList= _klinikTuruRepository.GetAll().ToList();
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
                _klinikTuruRepository.Ekle(klinikTuru);
                _klinikTuruRepository.Kaydet();         //bilgileri veritabanına ekler
                TempData["Basarili"] = "Yeni Klinik Oluşturma İşlemi Başarılı.";
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
            KlinikTuru? klinikTuruDb = _klinikTuruRepository.Get(u => u.KlinikTuruId == id);
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
                _klinikTuruRepository.Guncelle(klinikTuru);
                _klinikTuruRepository.Kaydet();      //bilgileri veritabanına ekler
                TempData["Basarili"] = "Klinik Güncelleme İşlemi Başarılı.";
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
                KlinikTuru? klinikTuruDb =_klinikTuruRepository.Get(u => u.KlinikTuruId == id);
                if (klinikTuruDb == null)
                {
                    return NotFound();
                }
                return View(klinikTuruDb);
            }

        [HttpPost, ActionName("KlinikSil")]
        public IActionResult KlinikSill(int? id)
        {
            KlinikTuru? klinikTuru = _klinikTuruRepository.Get(u => u.KlinikTuruId == id);
            if(klinikTuru == null)
            {
                return NotFound();
            }
            _klinikTuruRepository.Sil(klinikTuru);
            _klinikTuruRepository.Kaydet();
            TempData["Basarili"] = " Klinik Silme İşlemi Başarılı.";
            return RedirectToAction("Index");

        }

    }
}

