using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models;

public partial class SanPham
{
    [Key]
    public int MaSanPham { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string HinhAnh { get; set; } = null!;
    [Column(TypeName = "nvarchar(100)")]
    public string? TenSanPham { get; set; }

    public int? MaDanhMuc { get; set; }

    public int? MaThuongHieu { get; set; }

    public int? GioiTinh { get; set; }

    public double? Gia { get; set; }
    [Column(TypeName = "nvarchar(200)")]
    public string? MoTaNgan { get; set; }
    [Column(TypeName = "nvarchar(500)")]
    public string? MoTa { get; set; }
    [Column(TypeName = "nvarchar(MAX)")]
    public string? ThongSoKyThuat { get; set; }

    public int? SoLuong { get; set; }

    public int LuotXem { get; set; }

    public int? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public int? DaXoa { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? Slug { get; set; }

    public virtual ThuongHieu? ThuongHieu { get; set; }

    public virtual DanhMuc? DanhMuc { get; set; }

    public virtual ICollection<YeuThich> YeuThichs { get; set; } = new List<YeuThich>();

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual ICollection<BinhLuanSanPham> BinhLuanSanPhams { get; set; } = new List<BinhLuanSanPham>();

    public virtual ICollection<HinhAnhSanPham> HinhAnhSanPhams { get; set; } = new List<HinhAnhSanPham>();

    public virtual ICollection<DanhGiaSanPham> DanhGiaSanPhams { get; set; } = new List<DanhGiaSanPham>();

}
