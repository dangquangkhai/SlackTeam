namespace SlackTeam.LIB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistoryLogin")]
    public partial class HistoryLogin
    {
        public int ID { get; set; }

        public int? User_ID { get; set; }

        [StringLength(50)]
        public string User_IP { get; set; }

        public string Location { get; set; }

        public DateTime? Created { get; set; }

        public virtual User User { get; set; }
    }
}
