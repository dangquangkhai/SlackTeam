namespace SlackTeam.LIB.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RDBMDBContext : DbContext
    {
        public RDBMDBContext()
            : base("name=RDBMDBContext")
        {
        }

        public virtual DbSet<BlockList> BlockLists { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserContact> UserContacts { get; set; }
        public virtual DbSet<HistoryLogin> HistoryLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.Conversation)
                .HasForeignKey(e => e.Conversation_ID);

            modelBuilder.Entity<Conversation>()
                .HasMany(e => e.Participants)
                .WithOptional(e => e.Conversation)
                .HasForeignKey(e => e.Conversation_ID);

            modelBuilder.Entity<User>()
                .Property(e => e.Lastname)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.BlockLists)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Block_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BlockLists1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.User_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Sender_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Participants)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.HistoryLogins)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserContacts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserContacts1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.Contact_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
