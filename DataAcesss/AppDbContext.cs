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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.UserName).IsUnique();

            modelBuilder.Entity<Country>()
            .HasIndex(c => c.CountryName).IsUnique();

            modelBuilder.Entity<Country>()
            .Property(e => e.CountryDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Match>()
            .HasIndex(m => m.WebId).IsUnique();

            modelBuilder.Entity<Match>()
            .Property(m => m.MatchDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Bet>()
            .Property(b => b.BetDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CountryBet>()
            .Property(c => c.CountryBetDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EventLog>()
            .Property(e => e.LogDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Clan>()
            .HasIndex(c => c.ClanName).IsUnique();

            modelBuilder.Entity<Clan>()
            .Property(c => c.ClanDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ErrorLog>()
            .Property(l => l.LogDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AuditLog>()
            .Property(l => l.LogDateTime)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ChatPost>()
            .Property(cp => cp.PostDateTime)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ChatReply>()
            .Property(cr => cr.ReplyDateTime)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ChatLike>()
            .Property(cl => cl.LikeDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Ignore<LeaderBoardVM>();
            modelBuilder.Ignore<UsersPerClanVM>();
            modelBuilder.Ignore<MyStatsGridVM>();
            modelBuilder.Ignore<GeneralStatsVM.WinsPerDay>();
            modelBuilder.Ignore<MyStatsVM>();
            modelBuilder.Ignore<MatchResultsVM>();
            modelBuilder.Ignore<ClanStatsVM.ClanStatsPercentage>();
            modelBuilder.Ignore<ClanStatsVM.ClanStatsAbs>();
            modelBuilder.Ignore<ClanStatsVM.ClanUsers>();
            modelBuilder.Entity<LeaderBoardVM>().HasNoKey();
            modelBuilder.Entity<MatchResultsVM>().HasNoKey();
            modelBuilder.Entity<ClanStatsVM.ClanStatsPercentage>().HasNoKey();
            modelBuilder.Entity<ClanStatsVM.ClanStatsAbs>().HasNoKey();
            modelBuilder.Entity<ClanStatsVM.ClanUsers>().HasNoKey();
            modelBuilder.Entity<UsersPerClanVM>().HasNoKey();
            modelBuilder.Entity<MyStatsVM>().HasNoKey();
            modelBuilder.Entity<MyStatsGridVM>().HasNoKey();
            modelBuilder.Entity<GeneralStatsVM.WinsPerDay>().HasNoKey();

            modelBuilder.SeedUsers();
            modelBuilder.SeedCountries();
        }
    }
}
