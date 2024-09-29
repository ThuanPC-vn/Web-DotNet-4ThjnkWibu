using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai5_23TH2519.Models
{
    public class EmailModel
    {
        public String From { get; set; }

        public String Password { get; set; }

        public String To { get; set; }

        public String Subject { get; set; }

        public String Body { get; set; }
    }
}