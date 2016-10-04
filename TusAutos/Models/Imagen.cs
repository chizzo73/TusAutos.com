using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TusAutos.Models
{
    public class Imagen
    {
        public int Id { get; set; }

        [DisplayName("Imagen")]
        public string FileName { get; set; }

        public int Size { get; set;}

        public string Path { get; set;}
        
        [ForeignKey("Auto")]
        public int AutoId { get; set; }
        public virtual Auto Auto { get;set;}

        [ForeignKey("Promotor")]
        public int PromotorId { get; set;  }
        public virtual Promotor Promotor { get; set;  }

    }
}