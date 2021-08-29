using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartKart.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; } //Emun preferable
        public List<OrderItemModel> OrderItems { get; set; }
    }
}
