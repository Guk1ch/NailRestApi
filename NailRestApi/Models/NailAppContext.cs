using Microsoft.EntityFrameworkCore;


namespace NailRestApi.Models;

public partial class NailAppContext : DbContext
{
	public NailAppContext()
	{
	}

	public NailAppContext(DbContextOptions<NailAppContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Client> Clients { get; set; }

	public virtual DbSet<MasterWork> MasterWorks { get; set; }

	public virtual DbSet<Nail> Nails { get; set; }

	public virtual DbSet<NailForm> NailForms { get; set; }

	public virtual DbSet<NailLenght> NailLenghts { get; set; }

	public virtual DbSet<Record> Records { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Server=194.67.111.16;Database=NailApp;User Id=sa;Password=Password123!;TrustServerCertificate=true");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Client>(entity =>
		{
			entity.ToTable("Client");

			entity.Property(e => e.Id).HasColumnName("Id");
			entity.Property(e => e.FullName).HasColumnName("FullName");
			entity.Property(e => e.UserKey).HasColumnType("UserKey");
			entity.Property(e => e.Phone).HasColumnName("Phone");
		});

		modelBuilder.Entity<MasterWork>(entity =>
		{
			entity.ToTable("MasterWork");

			entity.Property(e => e.Id).HasColumnName("Id");
			//entity.Property(e => e.Image).HasColumnType("Image");
			entity.Property(e => e.Price).HasColumnName("Price");
		});

		modelBuilder.Entity<Nail>(entity =>
		{
			entity.ToTable("Nail");

			entity.Property(e => e.Id).HasColumnName("Id");
			entity.Property(e => e.Image).HasColumnName("Image");
			entity.Property(e => e.IdLenght).HasColumnName("IdLenght");
			entity.HasOne(d => d.IdLenghtNavigation).WithMany(p => p.Nails)
				.HasForeignKey(d => d.IdLenght)
				.HasConstraintName("FK_Nail_NailLenght");
			entity.Property(e => e.IdForm).HasColumnName("IdForm");
			entity.HasOne(d => d.IdFormNavigation).WithMany(p => p.Nails)
				.HasForeignKey(d => d.IdForm)
				.HasConstraintName("FK_Nail_NailForm");

		});

		modelBuilder.Entity<NailForm>(entity =>
		{
			entity.ToTable("NailForm");
			entity.Property(e => e.Id).HasColumnName("Id");
			entity.Property(e => e.Name).HasColumnType("Name");


		});

		modelBuilder.Entity<NailLenght>(entity =>
		{
			entity.ToTable("NailLenght");
			entity.Property(e => e.Id).HasColumnName("Id");
			entity.Property(e => e.Name).HasColumnType("Name");
		});

		modelBuilder.Entity<Record>(entity =>
		{
			entity.ToTable("Record");

			entity.Property(e => e.Id).HasColumnName("Id");
			entity.Property(e => e.Time).HasColumnName("Time");
			entity.Property(e => e.Cost).HasColumnName("Cost");
			entity.Property(e => e.IsDone).HasColumnName("IsDone");
			entity.Property(e => e.IdClient).HasColumnName("IdClient");
			entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Records)
			  .HasForeignKey(d => d.IdClient)
			  .HasConstraintName("FK_Record_Client");
		});


		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
