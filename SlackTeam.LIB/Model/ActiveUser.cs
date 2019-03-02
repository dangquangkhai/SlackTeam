namespace SlackTeam.LIB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActiveUser")]
    public partial class ActiveUser
    {
        public int ID { get; set; }

        [Required]
        public string Generate_URL { get; set; }

        public int User_ID { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Expired { get; set; }

        public int? ResetTime { get; set; }

        public virtual User User { get; set; }
    }
}
