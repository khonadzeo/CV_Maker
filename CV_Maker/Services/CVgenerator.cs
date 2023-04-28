using CV_Maker.Repository.Models;
using System.Reflection.Metadata;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Document = iTextSharp.text.Document;
using CV_Maker.IServices;

namespace CV_Maker.Services
{/// <summary>
/// 
/// </summary>
    public class CVgenerator:ICVgenerator
    {
        public async Task GeneratePdf(PersonalDetail personalDetails)
        {
            // Create a new PDF document
            Document document = new Document();
            MemoryStream stream = new MemoryStream();
            PdfWriter.GetInstance(document, stream);

            // Open the document
            document.Open();

            // Add a title to the document
            Paragraph title = new Paragraph("Curriculum Vitae");
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Add the personal details to the document
            document.Add(new Paragraph(""));
            document.Add(new Paragraph($"Name: {personalDetails.FirstName} {personalDetails.LastName}"));
            document.Add(new Paragraph($"Email: {personalDetails.Email}"));
            document.Add(new Paragraph($"Phone: {personalDetails.Phone}"));
            document.Add(new Paragraph($"Address: {personalDetails.Address}, {personalDetails.City}, {personalDetails.State}, {personalDetails.Country}, {personalDetails.PostalCode}"));
            document.Add(new Paragraph(""));
            document.Add(new Paragraph("Education:"));
            document.Add(new Paragraph(personalDetails.Education));
            document.Add(new Paragraph(""));
            document.Add(new Paragraph("Work Experience:"));
            document.Add(new Paragraph(personalDetails.WorkExperience));

            // Close the document
            document.Close();

            // Save the document to a file
            File.WriteAllBytes("cv.pdf", stream.ToArray());
        }
    }
}
