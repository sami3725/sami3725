namespace MemberRec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("member")]
    public partial class member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public member()
        {
            FeeDetails = new HashSet<FeeDetail>();
        }

        public int MemberId { get; set; }

        [StringLength(10)]
        public string MemberNo { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(50)]
        public string PanNo { get; set; }

        [StringLength(50)]
        public string RegistrationDate { get; set; }
       
        public bool Suspend { get; set; }

        public string image { get; set; }

        public int? ComitteeId { get; set; }

        public virtual comittee Comittee { get; set; }

        public int? PostId { get; set; }

        public virtual Post Post { get; set; }

        public int? BusinessTypeId { get; set; }

        public virtual BusinessType BusinessType { get; set; }

        public int? SubBranchId { get; set; }

        public virtual SubBranch SubBranch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeeDetail> FeeDetails { get; set; }
    }
}
