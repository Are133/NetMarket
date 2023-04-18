﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; }
        public int Marca { get; set; }

        [Column(TypeName = "decimal(18,4)")]  
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
