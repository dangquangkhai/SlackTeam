namespace SlackTeam.LIB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Participant
    {
        public int ID { get; set; }

        public int? Conversation_ID { get; set; }

        public int? User_ID { get; set; }

        public DateTime? Created { get; set; }

        public virtual Conversation Conversation { get; set; }

        public virtual User User { get; set; }
    }
}
