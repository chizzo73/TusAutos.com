using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TusAutos.Models
{
    public class Consesionaria
    {
        public Consesionaria(){
            Autos = new List<Auto>();    
        }

        public int Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [DisplayName("Geolocalizacion")]
        public decimal Lat { get; set; }

        public decimal Lon { get; set; }

        [DisplayName("Telefono")]
        public int Telefono { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }


        public virtual ICollection<Auto> Autos { get; set; }
    }
}