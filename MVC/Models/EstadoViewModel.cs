﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EstadoViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IdImage { get; set; }
        public PaisViewModel Pais { get; set; }
    }
}