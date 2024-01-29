using FindInternship.Data.Configurations;
using FindInternship.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data
{
    public class FindInternshipDbContext : IdentityDbContext<User>
    {

        private bool seedDb;

        public FindInternshipDbContext(DbContextOptions<FindInternshipDbContext> options, bool seedDb) 
            : base(options)
        {
            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }



            this.seedDb = seedDb;

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<StudentAbility> StudentAbilities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ChatImage> ChatImages { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<Lector> Lectors { get; set; }

        public DbSet<School> Schools { get; set; }
        public DbSet<CompanyAbility> Technologies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<User>()
                .Property(u => u.BirthDate)
                .HasColumnType("DATE");

            builder.Entity<StudentAbility>()
                .HasKey(sa => new { sa.StudentId, sa.AbilityId });

            builder.Entity<UserGroup>()
                .HasKey(ug => new { ug.GroupId, ug.UserId });

            builder.Entity<CompanyAbility>()
                .HasKey(ug => new { ug.CompanyId, ug.AbilityId });

            builder.Entity<Teacher>()
                .HasOne(t => t.Class)
                .WithOne(c => c.Teacher)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Ability>()
                .HasMany(a => a.Students)
                .WithOne(sa => sa.Ability)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Student>()
                .HasMany(s => s.Abilities)
                .WithOne(a => a.Student)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>()
                .HasMany(u => u.UserGroups)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Group>()
                .HasMany(g => g.UsersGroups)
                .WithOne(ug => ug.Group)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Class>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Class)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Class>()
                .HasMany(c => c.Meetings)
                .WithOne(s => s.Class)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Company>()
                .HasMany(c => c.Classes)
                .WithOne(c => c.Company)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Document>()
                .HasOne(d => d.Class)
                .WithMany(s => s.Documents)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Lector>()
                .HasOne(l => l.Company)
                .WithMany(c => c.Lectors)
                .OnDelete(DeleteBehavior.NoAction);

            if (seedDb)
            {
                builder.ApplyConfiguration(new SchoolConfiguration());
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new RolesConfiguration());
                builder.ApplyConfiguration(new UserRolesConfiguration());
                builder.ApplyConfiguration(new TeacherConfiguration());
                builder.ApplyConfiguration(new ClassConfiguration());
                builder.ApplyConfiguration(new StudentConfiguration());
                builder.ApplyConfiguration(new CompanyConfiguration());
                builder.ApplyConfiguration(new AbilityConfiguration());
                builder.ApplyConfiguration(new CompanyTechnologiesConfiguration());
            }

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
