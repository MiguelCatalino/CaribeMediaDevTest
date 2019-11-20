using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.web.Models
{
    public class CategoryViewModel
    {
        [DisplayName("ID")]
        public int CategoryID { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; }
        [DisplayName("Description")]
        public string CategoryDescription { get; set; }
        [DisplayName("IsActive")]
        public bool IsActive { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}
