using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciPortal.UI.Areas.Ogrenci.Model
{
    /// <summary>
    /// Öğrencinin ilk kayıt sırasında dolduracağı model
    /// </summary>
    public class ModelOgrenciIlkKayit 
    {
        [Required]
        [Display(Name = "Adı")]
        [StringLength(20,ErrorMessage="{0} en az {2} karakter olmalıdır.",MinimumLength = 3)]
        public string Adi { get; set; }

        [Required]
        [Display(Name = "Soyadı")]
        [StringLength(30, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 3)]
        public string Soyadi { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        [StringLength(255, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 3)]
        [DataType(DataType.EmailAddress,ErrorMessage="Lütfen E-Mail formatı giriniz.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        [StringLength(20, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Compare("Sifre",ErrorMessage="Şifreler uyuşmuyor.")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 6)]
        [Required()]
        public string SifreTekrar { get; set; }
    }
}