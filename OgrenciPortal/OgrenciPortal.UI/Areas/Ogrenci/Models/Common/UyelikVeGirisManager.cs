using OgrenciPortal.Provider;
using OgrenciPortal.UI.Areas.Ogrenci.Model;
using OgrenciPortal.UI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OgrenciPortal.Business.Common
{
    public class UyelikVeGirisManager
    {
        /// <summary>
        /// Öğrenci Kayıt işlemi yapar.
        /// </summary>
        /// <param name="mdlOgr"></param>
        /// <returns></returns>
        public static bool OgrenciIlkKayit(string Adi ,string Soyadi, string Email, string Sifre)
        {
            bool sonuc = false;
            DataLayer servis = new DataLayer();
            try
            {
                Hashtable param = new Hashtable();
                param.Add("@Adi", Adi);
                param.Add("@Soyadi", Soyadi);
                param.Add("@Email", Email);
                param.Add("@Sifre", Sifre);
                int gelenCevap = servis.SorguCalistir("prc_OgrenciIlkKayit", param, System.Data.CommandType.StoredProcedure);
                if (gelenCevap > 0)
                    sonuc = true;
                else
                    sonuc = false;
            }
            catch (Exception ex)
            {
                sonuc = false;
                //TODO : LOG KAYIT YAPILACAK.
            }
            return sonuc;
        }

        /// <summary>
        /// Öğrenci Giriş Yapar
        /// </summary>
        /// <param name="mdlOgr"></param>
        /// <returns></returns>
        public static bool OgrenciGiris(string Email, string Sifre)
        {
            DataLayer servis = new DataLayer();
            bool sonuc = false;
            try
            {
                
                Hashtable param = new Hashtable();
                param.Add("@Email", Email);
                param.Add("@Sifre", Sifre);
                DataTable gelenCevap = servis.Getir("prc_OgrenciGirisKontrol", param,CommandType.StoredProcedure);
                if (gelenCevap.Rows.Count > 0)
                {
                    
                    sonuc = true;
                }
                else
                    sonuc = false;
            }
            catch (Exception ex)
            {
                sonuc = false;
            }
            return sonuc;
        }
    }
}
