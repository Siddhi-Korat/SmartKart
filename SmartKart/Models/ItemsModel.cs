using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartKart.Models
{
    public class ItemsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Imported { get; set; }
        public decimal price { get; set; }
        public GoodsCategoryModel category { get; set; }
    }
}
