using EFCoreUTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreUTC.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DateTimeをUTCで保存する為、UTC⇔JST変換をする
            var jstZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            var datetimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.Kind == DateTimeKind.Utc ? v : TimeZoneInfo.ConvertTimeToUtc(v, TimeZoneInfo.Local),
                v => v.Kind == DateTimeKind.Utc ? TimeZoneInfo.ConvertTimeFromUtc(v, TimeZoneInfo.Local) : v);

            modelBuilder.Entity<Todo>()
                .Property(x => x.ExecutionDate)
                .HasConversion(datetimeConverter);
        }
    }
}
