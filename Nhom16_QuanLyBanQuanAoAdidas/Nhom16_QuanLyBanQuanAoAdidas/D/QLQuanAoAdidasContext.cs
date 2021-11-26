using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class QLQuanAoAdidasContext : DbContext
    {
        public QLQuanAoAdidasContext()
        {
        }

        public QLQuanAoAdidasContext(DbContextOptions<QLQuanAoAdidasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDatHangNhaCc> ChiTietDatHangNhaCcs { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DbSet<ChiTietPhieuSua> ChiTietPhieuSuas { get; set; }
        public virtual DbSet<DatHangNhaCc> DatHangNhaCcs { get; set; }
        public virtual DbSet<DoiTra> DoiTras { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiSp> LoaiSps { get; set; }
        public virtual DbSet<NhaCc> NhaCcs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SuaHang> SuaHangs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-5LSQB1SI\\SQLEXPRESS;Initial Catalog=QLQuanAoAdidas;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietDatHangNhaCc>(entity =>
            {
                entity.HasKey(e => new { e.MaDatHang, e.MaSp })
                    .HasName("PK__ChiTietD__CC0592716FDDE039");

                entity.ToTable("ChiTietDatHangNhaCC");

                entity.Property(e => e.MaDatHang)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.GiaDat).HasColumnType("money");

                entity.Property(e => e.Sldat).HasColumnName("SLDat");

                entity.Property(e => e.SldatCon).HasColumnName("SLDatCon");

                entity.HasOne(d => d.MaDatHangNavigation)
                    .WithMany(p => p.ChiTietDatHangNhaCcs)
                    .HasForeignKey(d => d.MaDatHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDa__MaDat__33D4B598");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietDatHangNhaCcs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDat__MaSP__32E0915F");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaSp })
                    .HasName("PK__ChiTietH__F557F661B69A283E");

                entity.ToTable("ChiTietHoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.Gia).HasColumnType("money");

                entity.Property(e => e.Slmua).HasColumnName("SLMua");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHoa__MaHD__403A8C7D");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHoa__MaSP__412EB0B6");
            });

            modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
            {
                entity.HasKey(e => new { e.MaPn, e.MaSp })
                    .HasName("PK__ChiTietP__F557B771CF865CF9");

                entity.ToTable("ChiTietPhieuNhap");

                entity.Property(e => e.MaPn)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaPN")
                    .IsFixedLength(true);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.GiaNhap).HasColumnType("money");

                entity.Property(e => e.Slnhap).HasColumnName("SLNhap");

                entity.HasOne(d => d.MaPnNavigation)
                    .WithMany(p => p.ChiTietPhieuNhaps)
                    .HasForeignKey(d => d.MaPn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPhi__MaPN__3B75D760");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietPhieuNhaps)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPhi__MaSP__3A81B327");
            });

            modelBuilder.Entity<ChiTietPhieuSua>(entity =>
            {
                entity.HasKey(e => new { e.MaSuaHang, e.MaSp })
                    .HasName("PK__ChiTietP__88315407FF42F378");

                entity.ToTable("ChiTietPhieuSua");

                entity.Property(e => e.MaSuaHang)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.TinhTrang).HasMaxLength(100);

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietPhieuSuas)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPhi__MaSP__46E78A0C");

                entity.HasOne(d => d.MaSuaHangNavigation)
                    .WithMany(p => p.ChiTietPhieuSuas)
                    .HasForeignKey(d => d.MaSuaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPh__MaSua__47DBAE45");
            });

            modelBuilder.Entity<DatHangNhaCc>(entity =>
            {
                entity.HasKey(e => e.MaDatHang)
                    .HasName("PK__DatHangN__1E77C2F02E764C08");

                entity.ToTable("DatHangNhaCC");

                entity.Property(e => e.MaDatHang)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaNCC")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayGiao).HasColumnType("datetime");

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.NguoiLap).HasMaxLength(30);

                entity.Property(e => e.TongTien).HasColumnType("money");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.DatHangNhaCcs)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK__DatHangNh__MaNCC__300424B4");
            });

            modelBuilder.Entity<DoiTra>(entity =>
            {
                entity.HasKey(e => e.MaDoiTra)
                    .HasName("PK__DoiTra__5F75908C78A01115");

                entity.ToTable("DoiTra");

                entity.Property(e => e.MaDoiTra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayDoiHang).HasColumnType("datetime");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.DoiTras)
                    .HasForeignKey(d => d.MaHd)
                    .HasConstraintName("FK__DoiTra__MaHD__4AB81AF0");

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.DoiTras)
                    .HasForeignKey(d => new { d.MaHd, d.MaSp })
                    .HasConstraintName("FK__DoiTra__4BAC3F29");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E0C779218F");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");

                entity.Property(e => e.TenNguoiLap).HasMaxLength(50);
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK__LoaiSP__730A57595131C1DB");

                entity.ToTable("LoaiSP");

                entity.Property(e => e.TenLoai).HasMaxLength(30);
            });

            modelBuilder.Entity<NhaCc>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK__NhaCC__3A185DEBE38D9993");

                entity.ToTable("NhaCC");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaNCC")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NguoiLienHe).HasMaxLength(50);

                entity.Property(e => e.SoDt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SoDT");

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(50)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A6134B81A");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.ChucVu).HasMaxLength(20);

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.LuongCb)
                    .HasColumnType("money")
                    .HasColumnName("LuongCB");

                entity.Property(e => e.SoCmt)
                    .HasMaxLength(15)
                    .HasColumnName("SoCMT");

                entity.Property(e => e.SoDt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SoDT");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(30)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaPn)
                    .HasName("PK__PhieuNha__2725E7F079FD0051");

                entity.ToTable("PhieuNhap");

                entity.Property(e => e.MaPn)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaPN")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaDiemNhap).HasMaxLength(100);

                entity.Property(e => e.MaDatHang)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaNCC")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.NguoiGiaoHang).HasMaxLength(50);

                entity.Property(e => e.NguoiLap).HasMaxLength(50);

                entity.HasOne(d => d.MaDatHangNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaDatHang)
                    .HasConstraintName("FK__PhieuNhap__MaDat__37A5467C");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK__PhieuNhap__MaNCC__36B12243");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081C77E699E8");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.Property(e => e.Mau).HasMaxLength(20);

                entity.Property(e => e.Size)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Slcon).HasColumnName("SLCon");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK__SanPham__MaLoai__2B3F6F97");
            });

            modelBuilder.Entity<SuaHang>(entity =>
            {
                entity.HasKey(e => e.MaSuaHang)
                    .HasName("PK__SuaHang__5A430486B9ACEA76");

                entity.ToTable("SuaHang");

                entity.Property(e => e.MaSuaHang)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.NgayTra).HasColumnType("datetime");

                entity.Property(e => e.SoDt)
                    .HasMaxLength(10)
                    .HasColumnName("SoDT");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(30)
                    .HasColumnName("TenKH");

                entity.Property(e => e.TinhTrang).HasMaxLength(100);

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.SuaHangs)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK__SuaHang__MaSP__440B1D61");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__TaiKhoan__2725D70AAC39F670");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.MaNv)
                    .ValueGeneratedNever()
                    .HasColumnName("MaNV");

                entity.Property(e => e.LoaiTaiKhoan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithOne(p => p.TaiKhoan)
                    .HasForeignKey<TaiKhoan>(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TaiKhoan__MaNV__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
