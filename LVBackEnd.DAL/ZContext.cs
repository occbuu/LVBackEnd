using System;
using Microsoft.EntityFrameworkCore;
using SKG;

namespace LVBackEnd.DAL
{
    using Models;

    public partial class ZContext : DbContext
    {
        public ZContext() { }

        public ZContext(DbContextOptions<ZContext> options) : base(options) { }

        public virtual DbSet<Code> Code { get; set; }
        public virtual DbSet<CodeType> CodeType { get; set; }
        public virtual DbSet<Disease> Disease { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<FunctionRole> FunctionRole { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<HuyLog> HuyLog { get; set; }
        public virtual DbSet<PatientData> PatientData { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Rule> Rule { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<Symptom> Symptom { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserLog> UserLog { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        // Unable to generate entity type for table 'Luan.BenhAn'. Please see the warning messages.
        // Unable to generate entity type for table 'Luan.Luat'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var user = ZRsa.Decrypt(AppSetting.S.DbUser);
                var password = ZRsa.Decrypt(AppSetting.S.DbPassword);
                var t = string.Format(AppSetting.S.DbConnection, user, password);
                optionsBuilder.UseSqlServer(t);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Code>(entity =>
            {
                entity.ToTable("Code", "System");

                entity.Property(e => e.CodeType)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DisplayAs).HasColumnType("ntext");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CodeTypeNavigation)
                    .WithMany(p => p.CodeNavigation)
                    .HasForeignKey(d => d.CodeType)
                    .HasConstraintName("FkCodeType");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FkCodeParent");
            });

            modelBuilder.Entity<CodeType>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__CodeType__A25C5AA648BC8307");

                entity.ToTable("CodeType", "System");

                entity.Property(e => e.Code)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DisplayAs).HasColumnType("ntext");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("Disease", "Luan");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("Function", "System");

                entity.Property(e => e.Code)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<FunctionRole>(entity =>
            {
                entity.ToTable("FunctionRole", "System");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group", "System");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.InitialChar).HasMaxLength(32);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<HuyLog>(entity =>
            {
                entity.ToTable("HuyLog", "Huy");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CipherChange).HasMaxLength(100);

                entity.Property(e => e.ClientExchange).HasMaxLength(100);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DestinationPort).HasMaxLength(100);

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.MessagePhase).HasMaxLength(100);

                entity.Property(e => e.Ping).HasMaxLength(100);

                entity.Property(e => e.Protocol)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SourcePort).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PatientData>(entity =>
            {
                entity.ToTable("PatientData", "Luan");

                entity.Property(e => e.BloodPressure).IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.NDays).HasColumnName("nDays");

                entity.Property(e => e.OriginalHealth).HasMaxLength(256);

                entity.Property(e => e.ResultDisease1).IsUnicode(false);

                entity.Property(e => e.ResultDisease2).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.Symptons).IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "System");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Rule>(entity =>
            {
                entity.ToTable("Rule", "Luan");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.Vp)
                    .HasColumnName("VP")
                    .IsUnicode(false);

                entity.Property(e => e.Vt)
                    .HasColumnName("VT")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK__Setting__C41E02881D191EC8");

                entity.ToTable("Setting", "System");

                entity.Property(e => e.Key)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DataType)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Module)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.Value).HasColumnType("ntext");
            });

            modelBuilder.Entity<Symptom>(entity =>
            {
                entity.ToTable("Symptom", "Luan");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Group).HasMaxLength(100);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "System");

                entity.Property(e => e.Birthday).HasColumnType("smalldatetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(32);

                entity.Property(e => e.Joined).HasColumnType("smalldatetime");

                entity.Property(e => e.LastName).HasMaxLength(32);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Pob).HasMaxLength(128);

                entity.Property(e => e.ReminderExpire).HasColumnType("datetime");

                entity.Property(e => e.ReminderToken)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserName)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.ToTable("UserLog", "System");

                entity.Property(e => e.Action).IsUnicode(false);

                entity.Property(e => e.ContentAfter).HasColumnType("ntext");

                entity.Property(e => e.ContentBefore).HasColumnType("ntext");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Objects).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLog)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FkLogUser");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole", "System");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });
        }
    }
}
