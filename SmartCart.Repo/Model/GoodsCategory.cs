using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartCart.Repo.Model
{
    [Serializable]
    [Table("GoodsCategories")]
    public class GoodsCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
