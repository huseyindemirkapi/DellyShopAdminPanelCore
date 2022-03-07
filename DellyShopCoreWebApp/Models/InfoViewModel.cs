using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DellyShopCoreWebAppAdminPanel.Models
{
    public class InfoViewModel
    {
        public string Message { get; set; }

        public InfoViewModel(string _message)
        {
            Message = _message;
        }

    }
}
