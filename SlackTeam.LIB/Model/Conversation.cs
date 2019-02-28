namespace SlackTeam.LIB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Conversation")]
    public partial class Conversation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conversation()
        {
            Messages = new HashSet<Message>();
            Participants = new HashSet<Participant>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int Creator_ID { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
