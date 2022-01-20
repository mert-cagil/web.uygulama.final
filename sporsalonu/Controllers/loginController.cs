using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using sporsalonu.Models.entity;
namespace sporsalonu.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        sporsalonuEntities1 db = new sporsalonuEntities1();
        public ActionResult AdminGiriş()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminGiriş(admingiriş p)
        {
            var bilgiler = db.admingiriş.FirstOrDefault(x => x.adminkullaniciadi == p.adminkullaniciadi && x.adminşifre == p.adminşifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.adminkullaniciadi, false);
                Session["adminkullaniciadi"] = bilgiler.adminkullaniciadi.ToString();
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                return RedirectToAction("AdminGiriş", "login");

            }
        }
        public ActionResult KullanıcıGiriş()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullanıcıGiriş(kullanicigiriş p)
        {
            var bilgiler = db.kullanicigiriş.FirstOrDefault(x => x.kullanicigiriş1 == p.kullanicigiriş1 && x.kullanicişifre == p.kullanicişifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanicigiriş1, false);
                Session["kullanicigiriş1"] = bilgiler.kullanicigiriş1.ToString();
                return RedirectToAction("Index", "HomeKullanıcı");
            }
            else
            {
                return RedirectToAction("KullanıcıGiriş", "login");

            }
        }

        [HttpGet]
        public ActionResult YeniKullanıcı()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKullanıcı(kullanicigiriş p1)
        {
            if (p1.kullanicigiriş1 == null || p1.kullanicişifre == null)
            {
                Response.Write("<script lang='JavaScript'>alert('LÜTFEN TÜM ALANLARI DOLDURUN!');</script>");
                return View();
            }
            else
            {
                db.kullanicigiriş.Add(p1);
                db.SaveChanges();
                Response.Write("Tebrikler Kullanıcı Eklenmiştir.");
                return RedirectToAction("KullanıcıGiriş", "login");
            }

        }
    }
}