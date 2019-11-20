using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.web.Models
{
    public class ItemViewModel
    {
        [DisplayName("ID")]
        public int ItemID { get; set; }
        [DisplayName("Item")]
        public string ItemName { get; set; }
        [DisplayName("Description")]
        public string ItemDescription { get; set; }
        [DisplayName("Quantity")]
        public decimal ItemQuantity { get; set; }
        [DisplayName("Price")]
        public decimal ItemPrice { get; set; }
        [DisplayName("Category")]
        public CategoryViewModel ItemCategory { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}
