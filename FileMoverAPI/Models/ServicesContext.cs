using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FileMoverAPI.Models;

public partial class ServicesContext : DbContext
{
    public ServicesContext()
    {
    }

    public ServicesContext(DbContextOptions<ServicesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Destination> Destinations { get; set; }

    public virtual DbSet<EventLog> EventLogs { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<FilePrefixType> FilePrefixTypes { get; set; }

    public virtual DbSet<FileServer> FileServers { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<VwDestinationRoute> VwDestinationRoutes { get; set; }

    public virtual DbSet<VwSourceRoute> VwSourceRoutes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //  => optionsBuilder.UseSqlServer("Server=DOH01DBAZQ1,9799;Database=Services;Trusted_Connection=True;Encrypt=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.ToTable("Application", "FileMove");

            entity.HasIndex(e => e.ApplicationName, "IX_Application_Name").IsUnique();

            entity.Property(e => e.ApplicationId).HasColumnName("Application_ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.AppGuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("App_GUID");
            entity.Property(e => e.ApplicationName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.DateTimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedByUser)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact", "FileMove");

            entity.Property(e => e.ContactId).HasColumnName("Contact_ID");
            entity.Property(e => e.ContactFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateTimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedByUser)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Organization)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telephone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Destination>(entity =>
        {
            entity.ToTable("Destination", "FileMove");

            entity.Property(e => e.DestinationId).HasColumnName("Destination_ID");
            entity.Property(e => e.Comment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ContactId).HasColumnName("Contact_ID");
            entity.Property(e => e.DateTimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DestinationType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("SFT");
            entity.Property(e => e.FolderPath)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Folder_Path");
            entity.Property(e => e.FolderType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("Primary")
                .HasColumnName("Folder_Type");
            entity.Property(e => e.ModifiedByUser)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PasswordUpdate).HasColumnType("datetime");
            entity.Property(e => e.SftFolder)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SFT_Folder");
            entity.Property(e => e.SftPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SFT_Password");
            entity.Property(e => e.SftPasswordHash)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SFT_PasswordHash");
            entity.Property(e => e.SftUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SFT_URL");
            entity.Property(e => e.SftUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SFT_UserName");
        });

        modelBuilder.Entity<EventLog>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK_Event");

            entity.ToTable("EventLog", "FileMove");

            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.DateTimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EventActor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EventDetails)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.EventTypeId).HasColumnName("EventType_ID");
            entity.Property(e => e.FileMoveOptions)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.ToTable("EventType", "FileMove");

            entity.Property(e => e.EventTypeId).HasColumnName("EventType_ID");
            entity.Property(e => e.EventType1)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("EventType");
        });

        modelBuilder.Entity<FilePrefixType>(entity =>
        {
            entity.HasKey(e => e.FilePrefixTypeId).HasName("PK_FilePrefixTypeID");

            entity.ToTable("FilePrefixType", "FileMove");

            entity.HasIndex(e => e.FilePrefixTypeName, "IX_FilePrefixTypeName");

            entity.Property(e => e.FilePrefixTypeId).HasColumnName("FilePrefixType_ID");
            entity.Property(e => e.ApplicationId).HasColumnName("Application_ID");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactId).HasColumnName("Contact_ID");
            entity.Property(e => e.DateTimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FilePrefixTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedByUser)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SourceId).HasColumnName("Source_ID");

            entity.HasOne(d => d.Source).WithMany(p => p.FilePrefixTypes)
                .HasForeignKey(d => d.SourceId)
                .HasConstraintName("FK_FilePrefixType_Source");
        });

        modelBuilder.Entity<FileServer>(entity =>
        {
            entity.ToTable("FileServer", "FileMove");

            entity.Property(e => e.Comment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ContactId).HasColumnName("Contact_ID");
            entity.Property(e => e.DateTimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FileServerType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("SFT");
            entity.Property(e => e.FolderPath)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Folder_Path");
            entity.Property(e => e.FolderType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("Primary")
                .HasColumnName("Folder_Type");
            entity.Property(e => e.ModifiedByUser)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PasswordUpdate).HasColumnType("datetime");
            entity.Property(e => e.SftFolder)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SFT_Folder");
            entity.Property(e => e.SftPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SFT_Password");
            entity.Property(e => e.SftPasswordHash)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SFT_PasswordHash");
            entity.Property(e => e.SftUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SFT_URL");
            entity.Property(e => e.SftUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SFT_UserName");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_File_Server");

            entity.ToTable("Route", "FileMove");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddDtstamp).HasColumnName("AddDTStamp");
            entity.Property(e => e.DestinationId).HasColumnName("Destination_ID");
            entity.Property(e => e.FilePrefixTypeId).HasColumnName("FilePrefixType_ID");
            entity.Property(e => e.ModifiedByUser)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RemoveDtstamp).HasColumnName("RemoveDTStamp");
            entity.Property(e => e.SourceId).HasColumnName("Source_ID");

            entity.HasOne(d => d.Destination).WithMany(p => p.RouteDestinations)
                .HasForeignKey(d => d.DestinationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FileServer_Destination");

            entity.HasOne(d => d.FilePrefixType).WithMany(p => p.Routes)
                .HasForeignKey(d => d.FilePrefixTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Route_FilePrefixType");

            entity.HasOne(d => d.Source).WithMany(p => p.RouteSources)
                .HasForeignKey(d => d.SourceId)
                .HasConstraintName("FK_FileServer_Source");
        });

        modelBuilder.Entity<VwDestinationRoute>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwDestinationRoute", "FileMove");

            entity.Property(e => e.AddDtstamp).HasColumnName("AddDTStamp");
            entity.Property(e => e.Comment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ConsumerContactId).HasColumnName("ConsumerContact_ID");
            entity.Property(e => e.DestinationId).HasColumnName("Destination_ID");
            entity.Property(e => e.FilePrefixTypeId).HasColumnName("FilePrefixType_ID");
            entity.Property(e => e.FilePrefixTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FileServerType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FolderPath)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Folder_Path");
            entity.Property(e => e.FolderType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Folder_Type");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PasswordUpdate).HasColumnType("datetime");
            entity.Property(e => e.ProviderContactId).HasColumnName("ProviderContact_ID");
            entity.Property(e => e.RemoveDtstamp).HasColumnName("RemoveDTStamp");
            entity.Property(e => e.SftFolder)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SFT_Folder");
            entity.Property(e => e.SftPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SFT_Password");
            entity.Property(e => e.SftPasswordHash)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SFT_PasswordHash");
            entity.Property(e => e.SftUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SFT_URL");
            entity.Property(e => e.SftUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SFT_UserName");
            entity.Property(e => e.SourceId).HasColumnName("Source_ID");
        });

        modelBuilder.Entity<VwSourceRoute>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwSourceRoute", "FileMove");

            entity.Property(e => e.AddDtstamp).HasColumnName("AddDTStamp");
            entity.Property(e => e.Comment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ConsumerContactId).HasColumnName("ConsumerContact_ID");
            entity.Property(e => e.FilePrefixTypeId).HasColumnName("FilePrefixType_ID");
            entity.Property(e => e.FilePrefixTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FileServerType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FolderPath)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Folder_Path");
            entity.Property(e => e.FolderType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Folder_Type");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PasswordUpdate).HasColumnType("datetime");
            entity.Property(e => e.ProviderContactId).HasColumnName("ProviderContact_ID");
            entity.Property(e => e.RemoveDtstamp).HasColumnName("RemoveDTStamp");
            entity.Property(e => e.SftFolder)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SFT_Folder");
            entity.Property(e => e.SftPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SFT_Password");
            entity.Property(e => e.SftPasswordHash)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SFT_PasswordHash");
            entity.Property(e => e.SftUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SFT_URL");
            entity.Property(e => e.SftUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SFT_UserName");
            entity.Property(e => e.SourceId).HasColumnName("Source_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
