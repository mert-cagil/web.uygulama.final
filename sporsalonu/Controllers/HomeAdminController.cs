using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sporsalonu.Models.entity;

namespace sporsalonu.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: HomeAdmin
        sporsalonuEntities1 db = new sporsalonuEntities1();

        public ActionResult Index()
        {
            var degerler = db.kullanicigiriş.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniEtkinlik()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniEtkinlik(etkinlik p1)
        {
            if (p1.etkinlikadı == null || p1.etkinliktürü == null || p1.etkinlikhocası == null || p1.etkinliktarih == null || p1.etkinlikkontejan == null || p1.etkinlikaçıklama == null)
            {
                Response.Write("<script lang='JavaScript'>alert('LÜTFEN TÜM ALANLARI DOLDURUN!');</script>");
                return View();
            }
            else
            {
                db.etkinlik.Add(p1);
                db.SaveChanges();
                Response.Write("Tebrikler İşlem Eklenmiştir.");
                return RedirectToAction("EtkinlikListesiAdmin", "Etkinlik");
            }

        }
        [HttpGet]
        public ActionResult YeniÖlcüm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniÖlcüm(üyebilgidetay p1)
        {
            if (p1.ad == null || p1.soyad == null || p1.tel == null || p1.boy == null || p1.kilo == null || p1.ölçüm == null || p1.tarih == null)
            {
                Response.Write("<script lang='JavaScript'>alert('LÜTFEN TÜM ALANLARI DOLDURUN!');</script>");
                return View();
            }
            else
            {
                db.üyebilgidetay.Add(p1);
                db.SaveChanges();
                Response.Write("Tebrikler Ölçüm Eklenmiştir.");
                return RedirectToAction("ÖlcümListesi", "HomeAdmin");
            }

        }
        public ActionResult ÖlcümListesi()
        {
            var degerler = db.üyebilgidetay.ToList();
            return View(degerler);
        }
        public ActionResult SILBILGI(int id)
        {
            var bilgi = db.üyebilgidetay.Find(id);
            db.üyebilgidetay.Remove(bilgi);
            db.SaveChanges();
            return RedirectToAction("ÖlcümListesi");
        }

    }
}