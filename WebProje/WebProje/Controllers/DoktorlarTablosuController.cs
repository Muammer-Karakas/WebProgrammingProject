using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProje.Models;
using WebProje.Utility;

namespace WebProje.Controllers
{
    public class DoktorlarTablosuController : Controller
    {
        private readonly IDoktorlarTablosuRepository _doktorlarTablosuRepository;

        private readonly IKlinikTuruRepository _klinikTuruRepository;

        public DoktorlarTablosuController(IDoktorlarTablosuRepository context , IKlinikTuruRepository klinikTuruRepository)
        {
            _doktorlarTablosuRepository = context;
            _klinikTuruRepository = klinikTuruRepository;
        }

        public IActionResult Index()
        {
            //List<DoktorlarTablosu> NsnDoktorlarTablosuList = _doktorlarTablosuRepository.GetAll().ToList();
            List<DoktorlarTablosu> NsnDoktorlarTablosuList = _doktorlarTablosuRepository.GetAll(includeProps:"KlinikTuru").ToList();
            return View(NsnDoktorlarTablosuList);
        }

        public IActionResult KlinikEkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> KlinikTuruList = _klinikTuruRepository.GetAll()
            .Select(k => new SelectListItem
            {
                Text = k.Ad,
                Value = k.KlinikTuruId.ToString()
            });

            ViewBag.KlinikTuruList = KlinikTuruList;
            if(id==null || id==0)
            {
                //ekle
                return View();
            }
            else
            {
                //guncelle
                DoktorlarTablosu? doktorlarTablosuDb = _doktorlarTablosuRepository.Get(u => u.DoktorId == id);
                if (doktorlarTablosuDb == null)
                {
                    return NotFound();
                }
                return View(doktorlarTablosuDb);

            }
            
        }
        [HttpPost]
        public IActionResult KlinikEkleGuncelle(DoktorlarTablosu doktorlarTablosu)
        {

            if(ModelState.IsValid) 
            {
                if(doktorlarTablosu.DoktorId == 0)
                {
                    _doktorlarTablosuRepository.Ekle(doktorlarTablosu);
                    TempData["Basarili"] = "Doktor Oluşturma İşlemi Başarılı.";
                }
                else
                {
                    _doktorlarTablosuRepository.Guncelle(doktorlarTablosu);
                    TempData["Basarili"] = "Doktor güncelleme İşlemi Başarılı.";
                }
               
                _doktorlarTablosuRepository.Kaydet();         //bilgileri veritabanına ekler
                
            return RedirectToAction("Index","DoktorlarTablosu");

            }
            return View();
        }

        /*  CLEAN CODE UYGULANDI
         * 
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
        */

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

