using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain.Models
{
    public class Notifications
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
