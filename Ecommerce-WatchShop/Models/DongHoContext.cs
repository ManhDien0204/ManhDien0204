using Microsoft.EntityFrameworkCore;

namespace Ecommerce_WatchShop.Models;

public partial class DongHoContext : DbContext
{
    public DongHoContext(DbContextOptions<DongHoContext> options) : base(options)
    {
    }

    public required virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public required virtual DbSet<HoaDon> HoaDons { get; set; }

    public required virtual DbSet<BaiViet> BaiViets { get; set; }

    public required virtual DbSet<HinhAnhBaiViet> HinhAnhBaiViets { get; set; }

    public required virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

    public required virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public required virtual DbSet<LienHe> LienHes { get; set; }

    public required virtual DbSet<KhachHang> KhachHangs { get; set; }

    public required virtual DbSet<YeuThich> YeuThichs { get; set; }

    public required virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public required virtual DbSet<SanPham> SanPhams { get; set; }

    public required virtual DbSet<BinhLuanSanPham> BinhLuanSanPhams { get; set; }

    public required virtual DbSet<HinhAnhSanPham> HinhAnhSanPhams { get; set; }

    public required virtual DbSet<DanhGiaSanPham> DanhGiaSanPhams { get; set; }

    public required virtual DbSet<VaiTro> VaiTros { get; set; }

    public required virtual DbSet<Footer> Footers { get; set; }

    public required virtual DbSet<FooterLink> FooterLinks { get; set; }

    public required virtual DbSet<GioiThieu> GioiThieus { get; set; }

    public required virtual DbSet<ChinhSach> ChinhSachs { get; set; }

    public required virtual DbSet<Slider> Sliders { get; set; }
}
