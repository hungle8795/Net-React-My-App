using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

[Route("api/images")]
[ApiController]
public class UploadImageController : ControllerBase
{
    private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "Img");

    public UploadImageController()
    {
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage(IFormFile image)
    {
        if (image == null || image.Length == 0)
        {
            return BadRequest("No image uploaded.");
        }

        var filePath = Path.Combine(_storagePath, image.FileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        // Lưu thông tin hình ảnh vào database (bạn cần thêm mã để kết nối và lưu vào database ở đây)

        return Ok(new { FilePath = filePath });
    }
}
