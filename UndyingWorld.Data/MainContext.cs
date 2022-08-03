using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UndyingWorld.Data
{
    public partial class MainContext : DbContext
    {
        public MainContext()
        {
        }

        public MainContext(DbContextOptions<MainContext> options )
            : base(options)
        {
        }

        public virtual DbSet<Authme> Authmes { get; set; }
        public virtual DbSet<GamepointsUser> GamepointsUsers { get; set; }
        public virtual DbSet<LuckpermsAction> LuckpermsActions { get; set; }
        public virtual DbSet<LuckpermsGroup> LuckpermsGroups { get; set; }
        public virtual DbSet<LuckpermsGroupPermission> LuckpermsGroupPermissions { get; set; }
        public virtual DbSet<LuckpermsMessenger> LuckpermsMessengers { get; set; }
        public virtual DbSet<LuckpermsPlayer> LuckpermsPlayers { get; set; }
        public virtual DbSet<LuckpermsTrack> LuckpermsTracks { get; set; }
        public virtual DbSet<LuckpermsUserPermission> LuckpermsUserPermissions { get; set; }
        public virtual DbSet<Punishment> Punishments { get; set; }
        public virtual DbSet<PunishmentHistory> PunishmentHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("Database is not configured");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Authme>(entity =>
            {
                entity.ToTable("authme");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Username, "username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("mediumint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.HasSession).HasColumnName("hasSession");

                entity.Property(e => e.Ip)
                    .HasMaxLength(40)
                    .HasColumnName("ip")
                    .UseCollation("ascii_bin")
                    .HasCharSet("ascii");

                entity.Property(e => e.IsLogged).HasColumnName("isLogged");

                entity.Property(e => e.Lastlogin).HasColumnName("lastlogin");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password")
                    .UseCollation("ascii_bin")
                    .HasCharSet("ascii");

                entity.Property(e => e.Pitch).HasColumnName("pitch");

                entity.Property(e => e.Realname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("realname");

                entity.Property(e => e.Regdate).HasColumnName("regdate");

                entity.Property(e => e.Regip)
                    .HasMaxLength(40)
                    .HasColumnName("regip")
                    .UseCollation("ascii_bin")
                    .HasCharSet("ascii");

                entity.Property(e => e.Totp)
                    .HasMaxLength(32)
                    .HasColumnName("totp");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");

                entity.Property(e => e.World)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("world")
                    .HasDefaultValueSql("'world'");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.Property(e => e.Yaw).HasColumnName("yaw");

                entity.Property(e => e.Z).HasColumnName("z");
            });

            modelBuilder.Entity<GamepointsUser>(entity =>
            {
                entity.ToTable("gamepoints_users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.LastOnline).HasColumnName("last_online");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Purchases)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("purchases");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<LuckpermsAction>(entity =>
            {
                entity.ToTable("luckperms_actions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActedName)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("acted_name");

                entity.Property(e => e.ActedUuid)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("acted_uuid");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("action");

                entity.Property(e => e.ActorName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("actor_name");

                entity.Property(e => e.ActorUuid)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("actor_uuid");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("type")
                    .IsFixedLength();
            });

            modelBuilder.Entity<LuckpermsGroup>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("luckperms_groups");

                entity.Property(e => e.Name)
                    .HasMaxLength(36)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<LuckpermsGroupPermission>(entity =>
            {
                entity.ToTable("luckperms_group_permissions");

                entity.HasIndex(e => e.Name, "luckperms_group_permissions_name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contexts)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("contexts");

                entity.Property(e => e.Expiry).HasColumnName("expiry");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("name");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("permission");

                entity.Property(e => e.Server)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("server");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.Property(e => e.World)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("world");
            });

            modelBuilder.Entity<LuckpermsMessenger>(entity =>
            {
                entity.ToTable("luckperms_messenger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Msg)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("msg");

                entity.Property(e => e.Time)
                    .HasColumnType("timestamp")
                    .HasColumnName("time");
            });

            modelBuilder.Entity<LuckpermsPlayer>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PRIMARY");

                entity.ToTable("luckperms_players");

                entity.HasIndex(e => e.Username, "luckperms_players_username");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .HasColumnName("uuid");

                entity.Property(e => e.PrimaryGroup)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("primary_group");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<LuckpermsTrack>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("luckperms_tracks");

                entity.Property(e => e.Name)
                    .HasMaxLength(36)
                    .HasColumnName("name");

                entity.Property(e => e.Groups)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("groups");
            });

            modelBuilder.Entity<LuckpermsUserPermission>(entity =>
            {
                entity.ToTable("luckperms_user_permissions");

                entity.HasIndex(e => e.Uuid, "luckperms_user_permissions_uuid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contexts)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("contexts");

                entity.Property(e => e.Expiry).HasColumnName("expiry");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("permission");

                entity.Property(e => e.Server)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("server");

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("uuid");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.Property(e => e.World)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("world");
            });

            modelBuilder.Entity<Punishment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calculation)
                    .HasMaxLength(50)
                    .HasColumnName("calculation");

                entity.Property(e => e.End)
                    .HasColumnType("mediumtext")
                    .HasColumnName("end");

                entity.Property(e => e.Name)
                    .HasMaxLength(16)
                    .HasColumnName("name");

                entity.Property(e => e.Operator)
                    .HasMaxLength(16)
                    .HasColumnName("operator");

                entity.Property(e => e.PunishmentType)
                    .HasMaxLength(16)
                    .HasColumnName("punishmentType");

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .HasColumnName("reason");

                entity.Property(e => e.Start)
                    .HasColumnType("mediumtext")
                    .HasColumnName("start");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(35)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<PunishmentHistory>(entity =>
            {
                entity.ToTable("PunishmentHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calculation)
                    .HasMaxLength(50)
                    .HasColumnName("calculation");

                entity.Property(e => e.End)
                    .HasColumnType("mediumtext")
                    .HasColumnName("end");

                entity.Property(e => e.Name)
                    .HasMaxLength(16)
                    .HasColumnName("name");

                entity.Property(e => e.Operator)
                    .HasMaxLength(16)
                    .HasColumnName("operator");

                entity.Property(e => e.PunishmentType)
                    .HasMaxLength(16)
                    .HasColumnName("punishmentType");

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .HasColumnName("reason");

                entity.Property(e => e.Start)
                    .HasColumnType("mediumtext")
                    .HasColumnName("start");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(35)
                    .HasColumnName("uuid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
