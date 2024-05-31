using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class QrCodeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly QrCodeService _qrCodeService;

    public QrCodeController(ApplicationDbContext context, QrCodeService qrCodeService)
    {
        _context = context;
        _qrCodeService = qrCodeService;
    }

    [HttpGet]
    public IActionResult Generate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Generate(string data)
    {
        var qrCodeImage = _qrCodeService.GenerateQrCode(data);
        var qrCode = new QrCode
        {
            Data = data,
            QrCodeImage = qrCodeImage
        };

        _context.QrCodes.Add(qrCode);
        await _context.SaveChangesAsync();

        ViewData["QrCodeImage"] = qrCodeImage;
        return View();
    }
}
