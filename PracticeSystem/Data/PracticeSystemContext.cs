using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PracticeSystem
{
    public partial class PracticeSystemContext : DbContext
    {
        public PracticeSystemContext()
        {
        }

        public PracticeSystemContext(DbContextOptions<PracticeSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groupp> Groupps { get; set; }
        public virtual DbSet<Pd> Pds { get; set; }
        public virtual DbSet<Phead> Pheads { get; set; }
        public virtual DbSet<Prac> Pracs { get; set; }
        public virtual DbSet<Pracani> Pracanis { get; set; }
        public virtual DbSet<Pracanlp> Pracanlps { get; set; }
        public virtual DbSet<Pracapp> Pracapps { get; set; }
        public virtual DbSet<Pracbpdp> Pracbpdps { get; set; }
        public virtual DbSet<Pracbptp> Pracbptps { get; set; }
        public virtual DbSet<Pracbynir> Pracbynirs { get; set; }
        public virtual DbSet<Pracbyop> Pracbyops { get; set; }
        public virtual DbSet<Pracmpnir> Pracmpnirs { get; set; }
        public virtual DbSet<Pracmptp> Pracmptps { get; set; }
        public virtual DbSet<Pracmyop> Pracmyops { get; set; }
        public virtual DbSet<Preferal> Preferals { get; set; }
        public virtual DbSet<Stud> Studs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=PracticeSystem;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Groupp>(entity =>
            {
                entity.HasKey(e => e.Grid)
                    .HasName("groupp_pkey");

                entity.ToTable("groupp");

                entity.Property(e => e.Grid).HasColumnName("grid");

                entity.Property(e => e.Edlvl)
                    .HasMaxLength(20)
                    .HasColumnName("edlvl");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Profile).HasColumnName("profile");

                entity.Property(e => e.Spec).HasColumnName("spec");
            });

            modelBuilder.Entity<Pd>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pd_pkey");

                entity.ToTable("pd");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Text).HasColumnName("text");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pds)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pd_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pds)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pd_stud");
            });

            modelBuilder.Entity<Phead>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("pk_for_phead");

                entity.ToTable("phead");

                entity.HasIndex(e => e.Pid, "phead_pid_key")
                    .IsUnique();

                entity.Property(e => e.Pid)
                    .ValueGeneratedNever()
                    .HasColumnName("pid");

                entity.Property(e => e.Depart)
                    .HasMaxLength(100)
                    .HasColumnName("depart");

                entity.Property(e => e.Eds)
                    .HasMaxLength(100)
                    .HasColumnName("eds");

                entity.Property(e => e.Fname)
                    .HasMaxLength(100)
                    .HasColumnName("fname");

                entity.HasOne(d => d.PidNavigation)
                    .WithOne(p => p.Phead)
                    .HasForeignKey<Phead>(d => d.Pid)
                    .HasConstraintName("key_foreign_phead_users");
            });

            modelBuilder.Entity<Prac>(entity =>
            {
                entity.HasKey(e => new { e.Pid, e.Grid, e.Pracid })
                    .HasName("prac_pkey");

                entity.ToTable("prac");

                entity.HasIndex(e => e.Pracid, "prac_pracid_key")
                    .IsUnique();

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Grid).HasColumnName("grid");

                entity.Property(e => e.Pracid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("pracid");

                entity.Property(e => e.Dateend)
                    .HasColumnType("date")
                    .HasColumnName("dateend");

                entity.Property(e => e.Datestart)
                    .HasColumnType("date")
                    .HasColumnName("datestart");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type");

                entity.HasOne(d => d.Gr)
                    .WithMany(p => p.Pracs)
                    .HasForeignKey(d => d.Grid)
                    .HasConstraintName("key_foreign_prac_groupp");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Pracs)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("key_foreign_prac_phead");
            });

            modelBuilder.Entity<Pracani>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracani_pkey");

                entity.ToTable("pracani");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Conf).HasColumnName("conf");

                entity.Property(e => e.Halfyear).HasColumnName("halfyear");

                entity.Property(e => e.Other).HasColumnName("other");

                entity.Property(e => e.Publicw).HasColumnName("publicw");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.Workbefore).HasColumnName("workbefore");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracanis)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracani_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracanis)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracani_stud");
            });

            modelBuilder.Entity<Pracanlp>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracanlp_pkey");

                entity.ToTable("pracanlp");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Conclusion).HasColumnName("conclusion");

                entity.Property(e => e.Personaltask).HasColumnName("personaltask");

                entity.Property(e => e.Placedesc).HasColumnName("placedesc");

                entity.Property(e => e.Pracbase).HasColumnName("pracbase");

                entity.Property(e => e.Prachead).HasColumnName("prachead");

                entity.Property(e => e.Researcharea).HasColumnName("researcharea");

                entity.Property(e => e.Usedlit).HasColumnName("usedlit");

                entity.Property(e => e.Usedpubl).HasColumnName("usedpubl");

                entity.Property(e => e.Usedres).HasColumnName("usedres");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracanlps)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracanlp_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracanlps)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracanlp_stud");
            });

            modelBuilder.Entity<Pracapp>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracapp_pkey");

                entity.ToTable("pracapp");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Conclusion).HasColumnName("conclusion");

                entity.Property(e => e.Edprog).HasColumnName("edprog");

                entity.Property(e => e.Personaltask).HasColumnName("personaltask");

                entity.Property(e => e.Placedesc).HasColumnName("placedesc");

                entity.Property(e => e.Ptparts).HasColumnName("ptparts");

                entity.Property(e => e.Useded).HasColumnName("useded");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracapps)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracapp_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracapps)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracapp_stud");
            });

            modelBuilder.Entity<Pracbpdp>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracbpdp_pkey");

                entity.ToTable("pracbpdp");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Basechar)
                    .HasMaxLength(30)
                    .HasColumnName("basechar");

                entity.Property(e => e.Intro)
                    .HasMaxLength(30)
                    .HasColumnName("intro");

                entity.Property(e => e.Taskresult)
                    .HasMaxLength(30)
                    .HasColumnName("taskresult");

                entity.Property(e => e.Usedres)
                    .HasMaxLength(30)
                    .HasColumnName("usedres");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracbpdps)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracbpdp_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracbpdps)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracbpdp_stud");
            });

            modelBuilder.Entity<Pracbptp>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracbptp_pkey");

                entity.ToTable("pracbptp");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Basechar)
                    .HasMaxLength(30)
                    .HasColumnName("basechar");

                entity.Property(e => e.Equipchar)
                    .HasMaxLength(30)
                    .HasColumnName("equipchar");

                entity.Property(e => e.Intro)
                    .HasMaxLength(30)
                    .HasColumnName("intro");

                entity.Property(e => e.Progchar)
                    .HasMaxLength(30)
                    .HasColumnName("progchar");

                entity.Property(e => e.Result)
                    .HasMaxLength(30)
                    .HasColumnName("result");

                entity.Property(e => e.Usedres)
                    .HasMaxLength(30)
                    .HasColumnName("usedres");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracbptps)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracbptp_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracbptps)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracbptp_stud");
            });

            modelBuilder.Entity<Pracbynir>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracbynir_pkey");

                entity.ToTable("pracbynir");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Conclusion)
                    .HasMaxLength(30)
                    .HasColumnName("conclusion");

                entity.Property(e => e.Planedesk)
                    .HasMaxLength(30)
                    .HasColumnName("planedesk");

                entity.Property(e => e.Pracplan)
                    .HasMaxLength(30)
                    .HasColumnName("pracplan");

                entity.Property(e => e.Pracres)
                    .HasMaxLength(30)
                    .HasColumnName("pracres");

                entity.Property(e => e.Prtask)
                    .HasMaxLength(30)
                    .HasColumnName("prtask");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracbynirs)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracbynir_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracbynirs)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracbynir_stud");
            });

            modelBuilder.Entity<Pracbyop>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracbyop_pkey");

                entity.ToTable("pracbyop");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Conclusion)
                    .HasMaxLength(30)
                    .HasColumnName("conclusion");

                entity.Property(e => e.Datacodetask)
                    .HasMaxLength(30)
                    .HasColumnName("datacodetask");

                entity.Property(e => e.Intro)
                    .HasMaxLength(30)
                    .HasColumnName("intro");

                entity.Property(e => e.Programmingtask)
                    .HasMaxLength(30)
                    .HasColumnName("programmingtask");

                entity.Property(e => e.Taskresults)
                    .HasMaxLength(30)
                    .HasColumnName("taskresults");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracbyops)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracbyop_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracbyops)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracbyop_stud");
            });

            modelBuilder.Entity<Pracmpnir>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracmpnir_pkey");

                entity.ToTable("pracmpnir");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Conf).HasColumnName("conf");

                entity.Property(e => e.Halfyear).HasColumnName("halfyear");

                entity.Property(e => e.Other).HasColumnName("other");

                entity.Property(e => e.Publicw).HasColumnName("publicw");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.Workbefore).HasColumnName("workbefore");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracmpnirs)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracmpnir_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracmpnirs)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracmpnir_stud");
            });

            modelBuilder.Entity<Pracmptp>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracmptp_pkey");

                entity.ToTable("pracmptp");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Basechar)
                    .HasMaxLength(20)
                    .HasColumnName("basechar");

                entity.Property(e => e.Equipchar)
                    .HasMaxLength(20)
                    .HasColumnName("equipchar");

                entity.Property(e => e.Intro)
                    .HasMaxLength(20)
                    .HasColumnName("intro");

                entity.Property(e => e.Progchar)
                    .HasMaxLength(20)
                    .HasColumnName("progchar");

                entity.Property(e => e.Result)
                    .HasMaxLength(20)
                    .HasColumnName("result");

                entity.Property(e => e.Usedres)
                    .HasMaxLength(20)
                    .HasColumnName("usedres");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracmptps)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracmptp_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracmptps)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracmptp_stud");
            });

            modelBuilder.Entity<Pracmyop>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("pracmyop_pkey");

                entity.ToTable("pracmyop");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.Basechar)
                    .HasMaxLength(30)
                    .HasColumnName("basechar");

                entity.Property(e => e.Equipchar)
                    .HasMaxLength(30)
                    .HasColumnName("equipchar");

                entity.Property(e => e.Intro)
                    .HasMaxLength(30)
                    .HasColumnName("intro");

                entity.Property(e => e.Progchar)
                    .HasMaxLength(30)
                    .HasColumnName("progchar");

                entity.Property(e => e.Result)
                    .HasMaxLength(30)
                    .HasColumnName("result");

                entity.Property(e => e.Usedres)
                    .HasMaxLength(30)
                    .HasColumnName("usedres");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Pracmyops)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_pracmyop_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Pracmyops)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_pracmyop_stud");
            });

            modelBuilder.Entity<Preferal>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Pracid })
                    .HasName("preferal_pkey");

                entity.ToTable("preferal");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Pracid).HasColumnName("pracid");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .HasColumnName("city");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Commentd).HasColumnName("commentd");

                entity.Property(e => e.Contractdate)
                    .HasColumnType("date")
                    .HasColumnName("contractdate");

                entity.Property(e => e.Contractnum).HasColumnName("contractnum");

                entity.Property(e => e.Dean)
                    .HasMaxLength(30)
                    .HasColumnName("dean");

                entity.Property(e => e.Faculty)
                    .HasMaxLength(30)
                    .HasColumnName("faculty");

                entity.Property(e => e.Headpos).HasColumnName("headpos");

                entity.Property(e => e.Headposd).HasColumnName("headposd");

                entity.Property(e => e.Listgraph).HasColumnName("listgraph");

                entity.Property(e => e.Listmat).HasColumnName("listmat");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("date")
                    .HasColumnName("orderdate");

                entity.Property(e => e.Orderr)
                    .HasMaxLength(30)
                    .HasColumnName("orderr");

                entity.Property(e => e.Pracbase)
                    .HasMaxLength(30)
                    .HasColumnName("pracbase");

                entity.Property(e => e.Prachead)
                    .HasMaxLength(30)
                    .HasColumnName("prachead");

                entity.Property(e => e.Pracresult)
                    .HasMaxLength(30)
                    .HasColumnName("pracresult");

                entity.Property(e => e.Pracresultd).HasColumnName("pracresultd");

                entity.Property(e => e.Practaskresult)
                    .HasMaxLength(30)
                    .HasColumnName("practaskresult");

                entity.Property(e => e.Practaskresultd).HasColumnName("practaskresultd");

                entity.Property(e => e.Practype)
                    .HasMaxLength(30)
                    .HasColumnName("practype");

                entity.Property(e => e.Productionobj).HasColumnName("productionobj");

                entity.Property(e => e.Ptheme).HasColumnName("ptheme");

                entity.Property(e => e.Recomend).HasColumnName("recomend");

                entity.Property(e => e.Refnum).HasColumnName("refnum");

                entity.Property(e => e.Studchar).HasColumnName("studchar");

                entity.Property(e => e.Studchard).HasColumnName("studchard");

                entity.Property(e => e.Uhead)
                    .HasMaxLength(30)
                    .HasColumnName("uhead");

                entity.Property(e => e.Univyear).HasColumnName("univyear");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Preferals)
                    .HasPrincipalKey(p => p.Pracid)
                    .HasForeignKey(d => d.Pracid)
                    .HasConstraintName("key_foreign_preferal_prac");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Preferals)
                    .HasPrincipalKey(p => p.Sid)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("key_foreign_preferal_stud");
            });

            modelBuilder.Entity<Stud>(entity =>
            {
                entity.HasKey(e => new { e.Sid, e.Grid })
                    .HasName("stud_pkey");

                entity.ToTable("stud");

                entity.HasIndex(e => e.Sid, "stud_sid_key")
                    .IsUnique();

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Grid).HasColumnName("grid");

                entity.Property(e => e.Eds)
                    .HasMaxLength(30)
                    .HasColumnName("eds");

                entity.Property(e => e.Fname)
                    .HasMaxLength(30)
                    .HasColumnName("fname");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.Gr)
                    .WithMany(p => p.Studs)
                    .HasForeignKey(d => d.Grid)
                    .HasConstraintName("key_foreign_stud_groupp");

                entity.HasOne(d => d.SidNavigation)
                    .WithOne(p => p.Stud)
                    .HasForeignKey<Stud>(d => d.Sid)
                    .HasConstraintName("key_foreign_stud_users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Login)
                    .HasMaxLength(30)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
