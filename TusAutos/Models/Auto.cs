using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TusAutos.Models;

namespace TusAutos.Models
{
    public class Auto
    {
        public Auto() {
               
            Consesionarias = new List<Consesionaria>();

        }
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Modelo")]
        public string Modelo { get; set; }
        [DisplayName("Fecha de Creacion")]
        public DateTime FechaCreacion { get; set; }
        [DisplayName("Kilometros")]
        public int Kilometros { get; set; }
        [DisplayName("Combustible")]
        public string Combustible { get; set; }
        [DisplayName("Gamma")]
        public string Gamma { get; set; }
        [DisplayName("Precio")]
        public int Precio { get; set; }
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [DisplayName("Consesionaria")]
        [ForeignKey("ConsesionariaId")]
        public long ConsesionariaId { get; set; }
        public virtual Consesionaria Consesionaria { get; set; }
        public List<Consesionaria> Consesionarias { get; private set; }
    }
}