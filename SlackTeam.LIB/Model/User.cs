namespace SlackTeam.LIB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            BlockLists = new HashSet<BlockList>();
            BlockLists1 = new HashSet<BlockList>();
            Messages = new HashSet<Message>();
            Participants = new HashSet<Participant>();
            HistoryLogins = new HashSet<HistoryLogin>();
            UserContacts = new HashSet<UserContact>();
            UserContacts1 = new HashSet<UserContact>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(10)]
        public string Lastname { get; set; }

        public DateTime? BirthDay { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsBlocked { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlockList> BlockLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlockList> BlockLists1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participant> Participants { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryLogin> HistoryLogins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContact> UserContacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContact> UserContacts1 { get; set; }
    }
}
