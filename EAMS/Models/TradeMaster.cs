using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EAMS.View_Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAMS.Models
{
    public class TradeMaster
    {
        [Key]
        public long TradeId { get; set; }
        public string TradeName { get; set; }
        public string Service { get; set; }
        public string Cat { get; set; }
        public string TradeGP { get; set; }
    }
}