using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OgrenciPortal.UI.Areas.Ogrenci.Model
{

    public class ModelOgrenciGiris 
    {
        [Required(ErrorMessage="Lütfen E-Mail Giriniz.")]
        [Display(Name = "E-Mail")]
        [StringLength(255, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 3)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen E-Mail formatı giriniz.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        [StringLength(20, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}