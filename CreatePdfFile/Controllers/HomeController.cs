using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CreatePdfFile.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.IO;
using Syncfusion.Drawing;




namespace CreatePdfFile.Controllers
{
	public class HomeController : Controller
    {
        private const string V = "Photo.jpg";
		
		public object Doc { get; private set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult CreateDocument()
        {


            return View();

        }



        public ActionResult CreateDocument1(PersonalDetails details)
        {

            //Create a new PDF document
            PdfDocument document = new PdfDocument();



            //Create a header and draw the image.

            //RectangleF bounds = new RectangleF(0, 0, pdfDocument.Pages[0].GetClientSize().Width, 50);





            //Set margin for all the pages

            document.PageSettings.Margins.All = 30;


            


            //Add a page to the document
            PdfPage page = document.Pages.Add();



            

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;



			//Set the standard font
			PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11);






            // Set the color space.
            graphics.ColorSpace = PdfColorSpace.GrayScale;
            //Get the graphics client size.
            SizeF clientSize = graphics.ClientSize;
            //Draw rectangle to PDF graphics.
            graphics.DrawRectangle(PdfBrushes.Linen, new RectangleF(PointF.Empty, clientSize));


           







            //Draw the text


            graphics.DrawString("Personal Profile ", font, PdfBrushes.DarkBlue, new PointF(5, 250));
            graphics.DrawString("---------------------------- ",font, PdfBrushes.Black, new PointF(5, 260));
            graphics.DrawString("Date Birth      :" + details.Date_birth, font, PdfBrushes.Black, new PointF(5, 280));
            graphics.DrawString("Email            :" + details.Email, font, PdfBrushes.Black, new PointF(5, 310));
            graphics.DrawString("Phone           :" + details.Phone, font, PdfBrushes.Black, new PointF(5, 340));
            graphics.DrawString("Address        :" + details.Address, font, PdfBrushes.Black, new PointF(5, 370));
            graphics.DrawString("Country        :" + details.Country, font, PdfBrushes.Black, new PointF(5, 410));
            graphics.DrawString("State            :" + details.State, font, PdfBrushes.Black, new PointF(5, 430));
            graphics.DrawString("City              :" + details.City, font, PdfBrushes.Black, new PointF(5, 460));
			

			graphics.DrawString("Name     : " + details.Name, font, PdfBrushes.Black, new PointF(240, 50));
			




			graphics.DrawString("Education", font, PdfBrushes.DarkBlue, new PointF(240, 100));
            graphics.DrawString("-----------------------------", font, PdfBrushes.Black, new PointF(240, 110));

            graphics.DrawString("Masters Degree      : " + details.Masters_Degree, font, PdfBrushes.Black, new PointF(240, 130));
            graphics.DrawString("Bachelors Degree   : " + details.Bachelors_Degree, font, PdfBrushes.Black, new PointF(240, 150));
            graphics.DrawString("Higher secondary   :" + details.Higher_secondary, font, PdfBrushes.Black, new PointF(240, 170));
            graphics.DrawString("Matriculationl        :" + details.Matriulationlty, font, PdfBrushes.Black, new PointF(240, 190));



           
            graphics.DrawString("Experience ", font, PdfBrushes.DarkBlue, new PointF(240, 220));
            graphics.DrawString("----------------------------", font, PdfBrushes.DarkBlue, new PointF(240, 230));
            graphics.DrawString("Company, Location — Job Title1    :" + details.Experience, font, PdfBrushes.Black, new PointF(240, 250));
          




            graphics.DrawString("Achievements", font, PdfBrushes.DarkBlue, new PointF(240, 300));
            graphics.DrawString("-------------------------", font, PdfBrushes.DarkBlue, new PointF(240, 320));
            graphics.DrawString("Type Here   :" + details.Achievements, font, PdfBrushes.Black, new PointF(240, 330));





            graphics.DrawString("Projects", font, PdfBrushes.DarkBlue, new PointF(240, 400));
            graphics.DrawString("--------------------------------", font, PdfBrushes.DarkBlue, new PointF(240, 410));
            graphics.DrawString("Project Name — Detail  :" + details.Projects, font, PdfBrushes.Black, new PointF(240, 430));
            //graphics.DrawString(details.Projects, font, PdfBrushes.Black, new PointF(240, 400));
            // graphics.DrawString("download certificate with a key", font, PdfBrushes.Black, new PointF(240, 420));


            graphics.DrawString("Skills", font, PdfBrushes.DarkBlue, new PointF(0, 500));
            graphics.DrawString("---------------------------", font, PdfBrushes.DarkBlue, new PointF(0, 510));
            graphics.DrawString("Technical skills:" + details.Technical_skills, font, PdfBrushes.Black, new PointF(0, 530));

            graphics.DrawString("Additional skills :" + details.Additional_skills, font, PdfBrushes.Black, new PointF(0, 560));





            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            // document.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            // stream.Position = 0;

            //Download the PDF document in the browser.
            // FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            //fileStreamResult.FileDownloadName = "Anuresume.pdf";
            //return fileStreamResult;








            //IMAGE PDF CODE HERE




            //Add a page to the document.
            _ = document.Pages.Add();
            //Create PDF graphics for the page
            _ = page.Graphics;
            //Load the image as stream.



            FileStream imageStream = new FileStream("C:\\Users\\hp\\source\\repos\\CreatePdfFile\\CreatePdfFile\\images\\p.jpg", FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            graphics.DrawImage(image, 20, 10);
            //Save the PDF document to stream
            stream.Position = 0;
            document.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            document.Close(true);











            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";
            //Define the file name.
            string fileName = "ResumeTest.pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);

        }

        public ActionResult ImageDocument1(PersonalDetails details)

        {
            PdfDocument doc = new PdfDocument();
            //Add a page to the document.
            PdfPage page = doc.Pages.Add();
            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;
            //Load the image as stream.
            FileStream imageStream = new FileStream("C:\\Users\\hp\\AppData\\Local\\Temp\\CreatePdfFile_CoreWeb-983162689\\CreatePdfFile\\CreatePdfFile\\images\\Photo.jpg", FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            graphics.DrawImage(image, 0, 0);
            //Save the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";
            //Define the file name.
            string fileName = "Resume12.pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);
        }


    }


}