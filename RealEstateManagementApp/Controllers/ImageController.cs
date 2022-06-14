using System.Web;
namespace RealEstateManagementApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly IDataService _dataService;
    private readonly ILogger<AuthController> _logger;

    private readonly IOptionsMonitor<AuthentificationOptionsMonitor> _optionsMonitor;
    public ImageController(IDataService dataService, ILogger<AuthController> logger, IOptionsMonitor<AuthentificationOptionsMonitor> optionsMonitor)
    {
        _logger = logger;
        _dataService = dataService;
        _optionsMonitor = optionsMonitor;
    }

    [HttpPost("Save/{propertyId}")]
    public async Task Save(int propertyId, IList<IFormFile> UploadFiles)
    {
        foreach (var file in UploadFiles)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    UploadedImage img = new()
                    {
                        PropertyId = propertyId,
                        ImageData = s
                    };
                    await _dataService.TransferImageToDatabase(img);
                }
            }
        }

    }

}
