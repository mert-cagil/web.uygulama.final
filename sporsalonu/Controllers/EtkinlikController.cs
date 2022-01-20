using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sporsalonu.Models.entity;

namespace sporsalonu.Controllers
{
    public class EtkinlikController : Controller
    {
        // GET: Etkinlik
        sporsalonuEntities1 db = new sporsalonuEntities1();

        public ActionResult Index()
        {
            var degerler = db.etkinlik.ToList();
            return View(degerler);
        }
        public ActionResult EtkinlikListesiAdmin()
        {
            var degerler = db.etkinlik.ToList();
            return View(degerler);
        }
        public ActionResult SIL(int id)
        {
            var etkinlik = db.etkinlik.Find(id);
            db.etkinlik.Remove(etkinlik);
            db.SaveChanges();
            return RedirectToAction("EtkinlikListesiAdmin");
        }

        public ActionResult EtkinlikGetir(int id)
        {
            var ktgr = db.etkinlik.Find(id);
            return View("EtkinlikGetir", ktgr);

        }
        public ActionResult Guncelle(etkinlik p1)
        {
            var ktgr = db.etkinlik.Find(p1.etkinlikid);
            ktgr.etkinlikadı = p1.etkinlikadı;
            ktgr.etkinliktürü = p1.etkinliktürü;
            ktgr.etkinlikhocası = p1.etkinlikhocası;
            ktgr.etkinliktarih = p1.etkinliktarih;
            ktgr.etkinlikkontejan = p1.etkinlikkontejan;
            ktgr.etkinlikaçıklama = p1.etkinlikaçıklama;
            db.SaveChanges();
            return RedirectToAction("EtkinlikListesiAdmin");

        }
        public ActionResult EtkinlikBasvuruGetir(int id)
        {
            var ktgr = db.etkinlik.Find(id);
            return View("EtkinlikBasvuruGetir", ktgr);

        }
        [HttpGet]
        public ActionResult EtkinlikBaşvur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EtkinlikBaşvur(etkinlikbasvuruları p1)
        {
            if (p1.etkinlikadı == null || p1.başvuranadsoyad == null)
            {
                Response.Write("<script lang='JavaScript'>alert('LÜTFEN TÜM ALANLARI DOLDURUN!');</script>");
                return View();
            }
            else
            {
                db.etkinlikbasvuruları.Add(p1);
                db.SaveChanges();
                Response.Write("Tebrikler Başvuru Eklenmiştir.");
                return RedirectToAction("EtkinlikBaşvurular", "Etkinlik");
            }

        }
        public ActionResult EtkinlikBaşvurular()
        {
            var degerler = db.etkinlikbasvuruları.ToList();
            return View(degerler);
        }
        public ActionResult AdminEtkinlikBaşvuru()
        {
            var degerler = db.etkinlikbasvuruları.ToList();
            return View(degerler);
        }
        public ActionResult SILBASVURU(int id)
        {
            var basvuru = db.etkinlikbasvuruları.Find(id);
            db.etkinlikbasvuruları.Remove(basvuru);
            db.SaveChanges();
            return RedirectToAction("AdminEtkinlikBaşvuru");
        }
    }
}