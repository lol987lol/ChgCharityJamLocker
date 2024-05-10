using LockerOpener.Configuration;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace LockerOpener.Controllers
{
    [Route("code")]
    public class CodeController : ControllerBase
    {
        private readonly GeneralOptions _generalOptions;

        public CodeController(GeneralOptions generalOptions)
        {
            _generalOptions = generalOptions ?? throw new ArgumentNullException(nameof(generalOptions));
        }

        [HttpGet("image")]
        public IActionResult LockerUserQrCode()
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(new Url($"{_generalOptions.PublicUrl}/users/1").ToString(), QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20, [14, 208, 118, 255], [0, 3, 2, 255]);

            return File(qrCodeImage, "image/png");
        }
    }
}
