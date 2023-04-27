using CV_Maker.IRepository;
using CV_Maker.Repository.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{
    public class CVController : Controller
    {
        private readonly IPersonalDetailsRepository _repository;

        public CVController(IPersonalDetailsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult GenerateCV(int id)
        {
            PersonalDetail personalDetails = _repository.GetById(id);

            // Generate the PDF document
            GeneratePdf(personalDetails);

            // Return the PDF document to the client
            byte[] pdfBytes = System.IO.File.ReadAllBytes("cv.pdf");
            return File(pdfBytes, "application/pdf", "cv.pdf");
        }

        private void GeneratePdf(PersonalDetail personalDetails)
        {
            // Create a new PDF document using iTextSharp
            using (var document = new Document())
            {
                // Create a new PDF writer and attach the document to it
                using (var writer = PdfWriter.GetInstance(document, new FileStream("cv.pdf", FileMode.Create)))
                {
                    // Open the document for writing
                    document.Open();

                    // Add the personal details to the document
                    document.Add(new Paragraph(personalDetails.FirstName + " " + personalDetails.LastName));
                    document.Add(new Paragraph(personalDetails.Address));
                    document.Add(new Paragraph(personalDetails.Email));
                    document.Add(new Paragraph(personalDetails.Phone));

                    // Close the document
                    document.Close();
                }
            }
        }
    }

}
