using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartCart.Repo.Model
{
    [Serializable]
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; } //Emun preferable
        public virtual List<OrderItems> OrderItems { get; set; }

    }
}
