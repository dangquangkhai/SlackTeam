namespace SlackTeam.LIB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserContact")]
    public partial class UserContact
    {
        public int ID { get; set; }

        public int User_ID { get; set; }

        public int Contact_ID { get; set; }

        public DateTime? Created { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
