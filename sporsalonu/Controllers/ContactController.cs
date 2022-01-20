using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sporsalonu.Models.entity;

namespace sporsalonu.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        sporsalonuEntities1 db = new sporsalonuEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(iletisim p1)
        {
            if (p1.AdSoyad == null || p1.Telefon == null || p1.Açıklama == null)
            {
                Response.Write("<script lang='JavaScript'>alert('LÜTFEN TÜM ALANLARI DOLDURUN!');</script>");
                return View();
            }
            else
            {
                db.iletisim.Add(p1);
                db.SaveChanges();
                Response.Write("Tebrikler İşlem Eklenmiştir.");
                return RedirectToAction("Index", "HomeKullanıcı");
            }

        }
        public ActionResult GelenMesajlar()
        {
            var mesaj = db.iletisim.ToList();
            return View(mesaj);
        }
    }
}