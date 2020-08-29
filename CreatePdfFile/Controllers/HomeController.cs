
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

            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 13);

            //Draw the text

            graphics.DrawString(" Personal Profile ", font, PdfBrushes.Blue, new PointF(15, 0));
            graphics.DrawString("Fulll Name     : Anupriya cs", font, PdfBrushes.Black, new PointF(0, 25));
            graphics.DrawString("Date of Birth  :20/01/1995", font, PdfBrushes.Black, new PointF(0, 50));
            graphics.DrawString("Email          :anu.@1995gmail.com", font, PdfBrushes.Black, new PointF(0, 75));




            graphics.DrawString("Education", font, PdfBrushes.Blue, new PointF(205, 100));
            graphics.DrawString("Masters Degree  :JMC, 72%,2019  ", font, PdfBrushes.Black, new PointF(205, 120));
            graphics.DrawString("Bachelors Degre : St. Marys College,Thrissut 73%,2016", font, PdfBrushes.Black, new PointF(205, 140));
            graphics.DrawString("Higher secondary: St.Aloysius, Thrsissur 73 %, 2013", font, PdfBrushes.Black, new PointF(205, 160));
            graphics.DrawString("Matriculationl  :I.J.G.H.S, Thrsissur 73 %, 2011", font, PdfBrushes.Black, new PointF(205, 180));
            graphics.DrawString("Experience ", font, PdfBrushes.Blue, new PointF(205, 220));
            graphics.DrawString("ABC Solutions 03 / 06 / 2018 - 05 / 09 / 2019", font, PdfBrushes.Black, new PointF(205, 240));

            graphics.DrawString("Achievements", font, PdfBrushes.Blue, new PointF(205, 280));
            graphics.DrawString("Developed a new employee orientation program that ", font, PdfBrushes.Black, new PointF(205, 300));
            graphics.DrawString("100% of the company locations adopted", font, PdfBrushes.Black, new PointF(205, 320));

            graphics.DrawString("Projects", font, PdfBrushes.Blue, new PointF(205, 360));
            graphics.DrawString("Pocket Certificate , 3 / 03 / 2019 - 05 / 06 / 2019" ,font, PdfBrushes.Black, new PointF(205, 380));
            graphics.DrawString("Python Django web based application to uploading and download certificate with a key", font, PdfBrushes.Black, new PointF(205, 400));
            graphics.DrawString("download certificate with a key", font, PdfBrushes.Black, new PointF(205, 420));



            graphics.DrawString("Skills", font, PdfBrushes.Blue, new PointF(40, 120));
            graphics.DrawString("Technical skills: html, css, c, c++", font, PdfBrushes.Black, new PointF(0, 140));

            graphics.DrawString("Additional skills : Leadership", font, PdfBrushes.Black, new PointF(0, 160));

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();


/////////////////////////////////////////////////////////////////////////////
FileStream imageStream = new FileStream("C:\\Users\\hp\\AppData\\Local\\Temp\\CreatePdfFile_CoreWeb-983162689\\CreatePdfFile\\CreatePdfFile\\images\\Photo.jpg", FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            graphics.DrawImage(image, 0, 0);
			//Save the PDF document to stream
			_ = new MemoryStream();
			doc.Save(stream);



            document.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Anuresume.pdf";
            return fileStreamResult;

        }



        public ActionResult CreateDocument1(PersonalDetails details)
        {

			//Create a new PDF document
			PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;



            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 13);


            //Draw the text


            graphics.DrawString(" Personal Profile ", font, PdfBrushes.Blue,new PointF());
            graphics.DrawString("Fulll Name     : "+details.Name, font, PdfBrushes.Black, new PointF(0,25));
            graphics.DrawString("Date of Birth  :"+details.Date_birth, font, PdfBrushes.Black, new PointF(0,50));
            graphics.DrawString("Email             :"+details.Email, font, PdfBrushes.Black, new PointF(0,75));
    

            graphics.DrawString("Education", font, PdfBrushes.Blue, new PointF(205, 100));
            graphics.DrawString("Masters Degree  :JMC, 72%,2019  ", font, PdfBrushes.Black, new PointF(205, 120));
            graphics.DrawString("Bachelors Degre : St. Marys College,Thrissut 73%,2016", font, PdfBrushes.Black, new PointF(205, 140));
            graphics.DrawString("Higher secondary: St.Aloysius, Thrsissur 73 %, 2013", font, PdfBrushes.Black, new PointF(205, 160));
            graphics.DrawString("Matriculationl  :I.J.G.H.S, Thrsissur 73 %, 2011", font, PdfBrushes.Black, new PointF(205, 180));
            graphics.DrawString("Experience ", font, PdfBrushes.Blue, new PointF(205, 220));
            graphics.DrawString("ABC Solutions 03 / 06 / 2018 - 05 / 09 / 2019", font, PdfBrushes.Black, new PointF(205, 240));

            graphics.DrawString("Achievements", font, PdfBrushes.Blue, new PointF(205, 280));
            graphics.DrawString("Developed a new employee orientation program that ", font, PdfBrushes.Black, new PointF(205, 300));
            graphics.DrawString("100% of the company locations adopted", font, PdfBrushes.Black, new PointF(205, 320));

            graphics.DrawString("Projects", font, PdfBrushes.Blue, new PointF(205, 360));
            graphics.DrawString("Pocket Certificate , 3 / 03 / 2019 - 05 / 06 / 2019", font, PdfBrushes.Black, new PointF(205, 380));
            graphics.DrawString("Python Django web based application to uploading and download certificate with a key", font, PdfBrushes.Black, new PointF(205, 400));
            graphics.DrawString("download certificate with a key", font, PdfBrushes.Black, new PointF(205, 420));


            graphics.DrawString("Skills", font, PdfBrushes.Blue, new PointF(40, 120));
            graphics.DrawString("Technical skills: html, css, c, c++", font, PdfBrushes.Black, new PointF(0, 140));

            graphics.DrawString("Additional skills : Leadership", font, PdfBrushes.Black, new PointF(0, 160));

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            //fileStreamResult.FileDownloadName = "Anuresume.pdf";
            //return fileStreamResult;
            
            
            



            
            
            //IMAGE PDF CODE HERE
            
            
            
            PdfDocument doc = new PdfDocument();
			//Add a page to the document.
			_ = doc.Pages.Add();
			//Create PDF graphics for the page
			_ = page.Graphics;
			//Load the image as stream.
			FileStream imageStream = new FileStream("C:\\Users\\hp\\AppData\\Local\\Temp\\CreatePdfFile_CoreWeb-983162689\\CreatePdfFile\\CreatePdfFile\\images\\Photo.jpg", FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            graphics.DrawImage(image, 0, 0);
			//Save the PDF document to stream
			_ = new MemoryStream();
			doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";
            //Define the file name.
            string fileName = "Resume1.pdf";
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
            string fileName = "Resume1.pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);
        }


    }


}
