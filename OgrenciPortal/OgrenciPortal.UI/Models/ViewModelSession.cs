using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciPortal.UI.Models
{
    public abstract class ViewModelSession
    {
        public Guid guid { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
    }
}