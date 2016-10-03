using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TusAutos.Models
{
    public class Imagen
    {
        public int Id { get; set; }
        [DisplayName("Imagen")]
        public int Img { get; set; }
        public int IdAuto { get; set; }
        public int IdPromotor { get; set;  }
    }
}