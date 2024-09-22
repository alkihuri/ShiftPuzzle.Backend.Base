using Microsoft.AspNetCore.Mvc;

namespace ImageProzessor.Controllers;

public class ImageController : Controller
{
    public ActionResult ProcessImage(string filter, int? brightness)
    {
        string imagePath = Server.MapPath("~/Images/sample.jpg");
        Bitmap image = new Bitmap(imagePath);
        Bitmap result = null;

        switch (filter)
        {
            case "blur":
                result = ImageProcessor.ApplyBlur(image);
                break;
            case "brightness":
                if (brightness.HasValue)
                {
                    result = ImageProcessor.AdjustBrightness(image, brightness.Value);
                }
                break;
            default:
                return new HttpStatusCodeResult(400, "Invalid filter specified.");
        }

        using (MemoryStream ms = new MemoryStream())
        {
            result.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return File(ms.ToArray(), "image/jpeg");
        }
    }
}