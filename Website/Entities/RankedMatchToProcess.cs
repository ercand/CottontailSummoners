using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class RankedMatchToProcess
    {
        [Key]
        public long ID { get; set; }

        public long RiotMatchID { get; set; }
        public int Platform { get; set; }
        public int Season { get; set; }
        public long Score { get; set; }
    }
}