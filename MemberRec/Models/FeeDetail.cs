namespace MemberRec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FeeDetail
    {
        public int FeeDetailId { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        public int? BillNo { get; set; }

        [StringLength(50)]
        public string Particular { get; set; }

       
        public decimal? Amount { get; set; }

        public int? MemberId { get; set; }

        public virtual member member { get; set; }
    }
}
