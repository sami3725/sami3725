namespace MemberRec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeeData")]
    public partial class FeeData
    {
        public int FeeDataId { get; set; }

        [StringLength(50)]
        public string Particular { get; set; }

       public decimal? Amount { get; set; }
    }
}
