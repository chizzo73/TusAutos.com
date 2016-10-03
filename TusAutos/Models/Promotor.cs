﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TusAutos.Models
{
    public class Promotor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}