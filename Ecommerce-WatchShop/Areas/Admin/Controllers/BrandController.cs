using Ecommerce_WatchShop.Helper;
using Ecommerce_WatchShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecommerce_WatchShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class BrandController : Controller
    {
        private readonly DongHoContext _context;

        public BrandController(DongHoContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách thương hiệu
        public async Task<IActionResult> Index(string searchQuery = "", int page = 1)
        {
            var pageSize = 5;
            var brands = _context.ThuongHieus.AsQueryable();

            // Tìm kiếm
            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower().Trim();
                brands = brands.Where(b => b.TenThuongHieu != null && b.TenThuongHieu.ToLower().Contains(searchQuery));
            }

            var totalBrands = await brands.CountAsync();
            var totalPages = (int)Math.Ceiling(totalBrands / (double)pageSize);

            var result = await brands
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchQuery = searchQuery;

            return View(result);
        }

        // Hiển thị form thêm thương hiệu
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm thương hiệu
        [HttpPost]
        public async Task<IActionResult> Create(ThuongHieu model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    return Json(new { success = false, message = "Dữ liệu không hợp lệ: " + string.Join(", ", errors) });
                }

                if (string.IsNullOrEmpty(model.TenThuongHieu))
                {
                    return Json(new { success = false, message = "Tên thương hiệu không được để trống!" });
                }

                // Tạo slug duy nhất
                model.Slug = await SlugHelper.GenerateUniqueSlug(_context, model.TenThuongHieu, SlugHelper.EntityType.Brand, null);
                _context.ThuongHieus.Add(model);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Thêm thương hiệu thành công!", id = model.MaThuongHieu, name = model.TenThuongHieu, slug = model.Slug });
            }
            catch (DbUpdateException ex)
            {
                return Json(new { success = false, message = "Lỗi khi lưu vào database: " + ex.InnerException?.Message ?? ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }

        // Hiển thị form sửa thương hiệu
        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _context.ThuongHieus.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // Xử lý sửa thương hiệu
        [HttpPost]
        public async Task<IActionResult> Edit(ThuongHieu model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    return Json(new { success = false, message = "Dữ liệu không hợp lệ: " + string.Join(", ", errors) });
                }

                var brand = await _context.ThuongHieus.FindAsync(model.MaThuongHieu);
                if (brand == null)
                {
                    return Json(new { success = false, message = "Thương hiệu không tồn tại!" });
                }

                brand.TenThuongHieu = model.TenThuongHieu;
                brand.Slug = await SlugHelper.GenerateUniqueSlug(_context, model.TenThuongHieu, SlugHelper.EntityType.Brand, model.MaThuongHieu);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Cập nhật thương hiệu thành công!", id = brand.MaThuongHieu, name = brand.TenThuongHieu, slug = brand.Slug });
            }
            catch (DbUpdateException ex)
            {
                return Json(new { success = false, message = "Lỗi khi lưu vào database: " + ex.InnerException?.Message ?? ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }

        // Xóa thương hiệu
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var brand = await _context.ThuongHieus.FindAsync(id);
                if (brand == null)
                {
                    return Json(new { success = false, message = "Thương hiệu không tồn tại!" });
                }

                if (brand.SanPhams.Any())
                {
                    return Json(new { success = false, message = "Không thể xóa vì thương hiệu đang được sử dụng!" });
                }

                _context.ThuongHieus.Remove(brand);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Xóa thương hiệu thành công!" });
            }
            catch (DbUpdateException ex)
            {
                return Json(new { success = false, message = "Lỗi khi xóa từ database: " + ex.InnerException?.Message ?? ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }

        // Xem chi tiết thương hiệu
        public async Task<IActionResult> Details(int id)
        {
            var brand = await _context.ThuongHieus
                .Include(b => b.SanPhams)
                .FirstOrDefaultAsync(b => b.MaThuongHieu == id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
    }
}