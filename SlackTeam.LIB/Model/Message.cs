namespace SlackTeam.LIB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public int ID { get; set; }

        public int? Conversation_ID { get; set; }

        public int? Sender_ID { get; set; }

        public string Memessage { get; set; }

        [StringLength(50)]
        public string attachment_url { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? Delete_At { get; set; }

        public virtual Conversation Conversation { get; set; }

        public virtual User User { get; set; }
    }
}
