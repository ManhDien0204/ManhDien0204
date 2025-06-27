using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models;

public partial class YeuThich
{
    [Key]
    public int MaYeuThich { get; set; }

    public int MaSanPham { get; set; }

    public int? MaKhachHang { get; set; }

    public virtual KhachHang? KhachHang { get; set; }

    public virtual SanPham SanPham { get; set; } = null!;
}
