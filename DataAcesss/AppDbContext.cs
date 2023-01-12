using DataAcesss.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;

namespace DataAcesss
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<CountryBet> CountryBets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Match> Matches { get; set; }
        public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<ChatPost> ChatPosts { get; set; }
        public DbSet<ChatReply> ChatReplies { get; set; }
        public DbSet<ChatLike> ChatLikes { get; set; }
        public DbSet<LeaderBoardVM> LeaderBoard { get; set; }
        public DbSet<MatchResultsVM> MatchResults { get; set; }
        public DbSet<ClanStatsVM.ClanStatsPercentage> ClanStats { get; set; }
        public DbSet<ClanStatsVM.ClanStatsAbs> ClanStatsAbs { get; set; }
        public DbSet<ClanStatsVM.ClanUsers> ClanUsers { get; set; }
        public DbSet<UsersPerClanVM> UsersPerClan { get; set; }
        public DbSet<MyStatsVM> MyStats { get; set; }
        public DbSet<MyStatsGridVM> MyBetList { get; set; }
        public DbSet<GeneralStatsVM.WinsPerDay> WinsPerDay { get; set; }
        public DbSet<UnactiveUsersVM> UsageOverview { get; set; }
        public DbSet<ScalarInt> ScalarInt { get; set; }
        public DbSet<LeaderBoardDetailsVM> LeaderBoardDetails { get; set; }
        public DbSet<ApplicationUsageVM.LoginTypes> AplicationUsage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUser
            modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.UserName).IsUnique();


            // Country
            modelBuilder.Entity<Country>()
            .HasIndex(c => c.CountryName).IsUnique();

            modelBuilder.Entity<Country>()
            .Property(c => c.CountryDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Country>()
            .Property(c => c.CountryCoeficient)
            .HasColumnType("decimal(15,2)");

            // Match
            modelBuilder.Entity<Match>()
            .HasIndex(m => m.WebId).IsUnique();

            modelBuilder.Entity<Match>()
            .Property(m => m.MatchDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Match>()
            .Property(m => m.AwayCoeficient)
            .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<Match>()
            .Property(m => m.DrawCoeficient)
            .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<Match>()
            .Property(m => m.HomeCoeficient)
            .HasColumnType("decimal(15,2)");

            // Bet
            modelBuilder.Entity<Bet>()
            .Property(b => b.BetDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Bet>()
            .Property(b => b.BetCoeficient)
            .HasColumnType("decimal(15,2)");


            // CountryBet
            modelBuilder.Entity<CountryBet>()
            .Property(c => c.CountryBetDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CountryBet>()
            .Property(c => c.CountryCoeficient)
            .HasColumnType("decimal(15,2)");


            // Clan
            modelBuilder.Entity<Clan>()
            .HasIndex(c => c.ClanName).IsUnique();

            modelBuilder.Entity<Clan>()
            .Property(c => c.ClanDate)
            .HasDefaultValueSql("getdate()");


            // ErrorLog
            modelBuilder.Entity<ErrorLog>()
            .Property(l => l.LogDate)
            .HasDefaultValueSql("getdate()");


            // EventLog
            modelBuilder.Entity<EventLog>()
            .Property(e => e.LogDate)
            .HasDefaultValueSql("getdate()");


            // AuditLog
            modelBuilder.Entity<AuditLog>()
            .Property(l => l.LogDateTime)
            .HasDefaultValueSql("getdate()");


            // ChatPost
            modelBuilder.Entity<ChatPost>()
            .Property(cp => cp.PostDateTime)
            .HasDefaultValueSql("getdate()");


            // ChatReply
            modelBuilder.Entity<ChatReply>()
            .Property(cr => cr.ReplyDateTime)
            .HasDefaultValueSql("getdate()");


            // ChatLike
            modelBuilder.Entity<ChatLike>()
            .Property(cl => cl.LikeDate)
            .HasDefaultValueSql("getdate()");


            // ViewModels
            modelBuilder.Entity<LeaderBoardVM>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<UsersPerClanVM>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<MyStatsGridVM>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<GeneralStatsVM.WinsPerDay>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<MyStatsVM>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<MatchResultsVM>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ClanStatsVM.ClanStatsPercentage>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ClanStatsVM.ClanStatsAbs>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ClanStatsVM.ClanUsers>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<UnactiveUsersVM>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ScalarInt>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<LeaderBoardDetailsVM>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ApplicationUsageVM.LoginTypes>().HasNoKey().ToTable(t => t.ExcludeFromMigrations());

            modelBuilder.Entity<ClanStatsVM.ClanStatsPercentage>()
            .Property(c => c.AvgCoeficient)
            .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<LeaderBoardVM>()
            .Property(l => l.TotalCoeficient)
            .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<MyStatsGridVM>()
            .Property(g => g.BetCoeficient)
            .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<MyStatsVM>()
            .Property(s => s.BestWinningCoeficient)
            .HasColumnType("decimal(15,2)");

            // Seeds
            modelBuilder.SeedUsers();
            modelBuilder.SeedCountries();
        }
    }
}
