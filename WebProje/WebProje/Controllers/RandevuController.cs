using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProje.Models;
using WebProje.Utility;

namespace WebProje.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IRandevuRepository _randevuRepository;

        private readonly IDoktorlarTablosuRepository _doktorlarTablosuRepository;

        public RandevuController(IRandevuRepository randevuRepository , IDoktorlarTablosuRepository context)
        {
            _randevuRepository = randevuRepository;
            _doktorlarTablosuRepository = context;
        }

        public IActionResult Index()
        {
            List<Randevu> NsnRandevuList = _randevuRepository.GetAll(includeProps:"DoktorlarTablosu").ToList();
            return View(NsnRandevuList);
        }

        public IActionResult KlinikEkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> DoktorlarTablosuList = _doktorlarTablosuRepository.GetAll()
            .Select(k => new SelectListItem
            {
                Text = k.DoktorAdi,
                Value = k.DoktorId.ToString()
            });

            ViewBag.DoktorlarTablosuList = DoktorlarTablosuList;

            if(id==null || id==0)
            {
                //ekle
                return View();
            }
            else
            {
                //guncelle
                Randevu? randevuDb = _randevuRepository.Get(u => u.RandevuId == id);
                if (randevuDb == null)
                {
                    return NotFound();
                }
                return View(randevuDb);

            }
            
        }
        [HttpPost]
        public IActionResult KlinikEkleGuncelle(Randevu randevu)
        {

            if(ModelState.IsValid) 
            {
                if(randevu.RandevuId == 0)
                {
                    _randevuRepository.Ekle(randevu);
                    TempData["Basarili"] = "Randevu Kayıt Oluşturma İşlemi Başarılı.";
                }
                else
                {
                    _randevuRepository.Guncelle(randevu);
                    TempData["Basarili"] = "Randevu Kayıt güncelleme İşlemi Başarılı.";
                }
               
                _randevuRepository.Kaydet();         //bilgileri veritabanına ekler
                
            return RedirectToAction("Index","Randevu");

            }
            return View();
        }

            public IActionResult KlinikSil(int? id)
            {
            IEnumerable<SelectListItem> DoktorlarTablosuList = _doktorlarTablosuRepository.GetAll()
            .Select(k => new SelectListItem
            {
                Text = k.DoktorAdi,
                Value = k.DoktorId.ToString()
            });

            ViewBag.DoktorlarTablosuList = DoktorlarTablosuList;


            if (id == 0 || id == null)
                {
                    return NotFound();
                }
            Randevu? randevuDb = _randevuRepository.Get(u => u.RandevuId == id);
                if (randevuDb == null)
                {
                    return NotFound();
                }
                return View(randevuDb);
            }

        [HttpPost, ActionName("KlinikSil")]
        public IActionResult KlinikSill(int? id)
        {
            Randevu? randevu = _randevuRepository.Get(u => u.RandevuId == id);
            if(randevu == null)
            {
                return NotFound();
            }
            _randevuRepository.Sil(randevu);
            _randevuRepository.Kaydet();
            TempData["Basarili"] = " Randevu Kayıt Silme İşlemi Başarılı.";
            return RedirectToAction("Index", "Randevu");

        }

    }
}

