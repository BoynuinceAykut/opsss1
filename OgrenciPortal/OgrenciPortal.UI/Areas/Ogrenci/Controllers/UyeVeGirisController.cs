using OgrenciPortal.Business.Common;
using OgrenciPortal.UI.Areas.Ogrenci.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciPortal.UI.Areas.Ogrenci.Controllers
{
    public class UyeVeGirisController : Controller
    {
        //
        // GET: /UyeVeGiris/

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult OgrenciKayit(ModelKayitVeGirisUI model)
        {
            try
            {
                // TODO: Add insert logic here

                bool sonuc = UyelikVeGirisManager.OgrenciIlkKayit(model.modelOgrenciIKayit.Adi, model.modelOgrenciIKayit.Soyadi, model.modelOgrenciIKayit.Email, model.modelOgrenciIKayit.Sifre);
                if (sonuc)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /UyeVeGiris/OgrenciGiris
        [HttpPost]
        public ActionResult OgrenciGiris(ModelKayitVeGirisUI model)
        {
            try
            {
                // TODO: Add insert logic here

                bool sonuc = UyelikVeGirisManager.OgrenciGiris(model.modelogrencigiris.Email, model.modelogrencigiris.Sifre);
                if (sonuc != null)
                {
                    
                    return RedirectToAction("Index","../");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
