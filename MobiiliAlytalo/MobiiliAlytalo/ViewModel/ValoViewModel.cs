using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobiiliAlytalo.ViewModel
{
    public class ValoViewModel
    {
        public int ValoID { get; set; }
        public bool ValoOFF { get; set; }
        public bool Valo33 { get; set; }
        public bool Valo66 { get; set; }
        public bool Valo100  { get; set; }
        public DateTime? ValoAikaLeima33 { get; set; }
        public DateTime? ValoAikaLeima66 { get; set; }
        public DateTime? ValoAikaLeima100 { get; set; }
        public string ValaisinNimi { get; set; }
    }
}