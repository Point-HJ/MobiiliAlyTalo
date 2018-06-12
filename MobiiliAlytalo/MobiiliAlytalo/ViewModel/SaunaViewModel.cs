using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobiiliAlytalo.ViewModel
{
    public class SaunaViewModel
    {
        public int SaunaID { get; set; }
        public string SaunaNimi { get; set; }
        public int? SaunaNykyLampotila { get; set; }
        public bool SaunaON { get; set; }
        public bool SaunaOFF { get; set; }


    }
}