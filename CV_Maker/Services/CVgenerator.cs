using CV_Maker.IServices;
using CV_Maker.Repository.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Threading.Tasks;

namespace CV_Maker.Services
{
    public class CVgenerator : ICVgenerator
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
            Paragraph title = new Paragraph(new Chunk("Curriculum Vitae", FontFactory.GetFont(FontFactory.TIMES_BOLD, 20, Font.UNDERLINE)));
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Add the personal details to the document
            document.Add(new Paragraph("\n"));
            Paragraph personalInfo = new Paragraph();
            personalInfo.Add(new Chunk($"Name: {personalDetails.FirstName} {personalDetails.LastName}\n", FontFactory.GetFont(FontFactory.TIMES_BOLD, 16)));
            personalInfo.Add(new Chunk($"Email: {personalDetails.Email}\n", FontFactory.GetFont(FontFactory.TIMES, 16)));
            personalInfo.Add(new Chunk($"Phone: {personalDetails.Phone}\n", FontFactory.GetFont(FontFactory.TIMES, 16)));
            document.Add(new Paragraph("\n"));
            personalInfo.Add(new Chunk($"Address: {personalDetails.Address}," +
                $" {personalDetails.City}," +
                $" {personalDetails.State}, " +
                $"{personalDetails.Country}," +
                $" {personalDetails.PostalCode}\n",
                FontFactory.GetFont(FontFactory.TIMES_BOLD, 16)));
          //  personalInfo.Alignment = Element.ALIGN_CENTER;
            document.Add(personalInfo);

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            Paragraph education = new Paragraph("Education:", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18, Font.UNDERLINE));
            document.Add(new Paragraph("\n"));
            education.Alignment = Element.ALIGN_CENTER;
            document.Add(education);
            Paragraph educationDetails = new Paragraph(personalDetails.Education);
           // educationDetails.Alignment = Element.ALIGN_CENTER;
            document.Add(educationDetails);

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            Paragraph workExperience = new Paragraph("Work Experience:", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18, Font.UNDERLINE));
            document.Add(new Paragraph("\n"));
            workExperience.Alignment = Element.ALIGN_CENTER;
            document.Add(workExperience);
            Paragraph workExperienceDetails = new Paragraph(personalDetails.WorkExperience);
           // workExperienceDetails.Alignment = Element.ALIGN_CENTER;
            document.Add(workExperienceDetails);

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            Paragraph aboutSection = new Paragraph("About", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18, Font.UNDERLINE));
            document.Add(new Paragraph("\n"));
            aboutSection.Alignment = Element.ALIGN_CENTER;
            document.Add(aboutSection);
            document.Add(new Paragraph(personalDetails.About));

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            Paragraph hobbiesSection = new Paragraph("Hobbies", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18, Font.UNDERLINE));
            document.Add(new Paragraph("\n"));
            hobbiesSection.Alignment = Element.ALIGN_CENTER;
            document.Add(hobbiesSection);
            document.Add(new Paragraph(personalDetails.Hobbies));

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            Paragraph certificatesSection = new Paragraph("Certificates", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18, Font.UNDERLINE));
            document.Add(new Paragraph("\n"));
            certificatesSection.Alignment = Element.ALIGN_CENTER;
            document.Add(certificatesSection);
            document.Add(new Paragraph(personalDetails.Certificates));

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            Paragraph languagesSection = new Paragraph("Languages", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18, Font.UNDERLINE));
            document.Add(new Paragraph("\n"));
            languagesSection.Alignment = Element.ALIGN_CENTER;
            document.Add(languagesSection);
            document.Add(new Paragraph(personalDetails.Languages));

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            Paragraph skillsSection = new Paragraph("Skills", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18, Font.UNDERLINE));
            document.Add(new Paragraph("\n"));
            skillsSection.Alignment = Element.ALIGN_CENTER;
            document.Add(skillsSection);
            document.Add(new Paragraph(personalDetails.Skills));

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            Paragraph reference = new Paragraph("Reference:", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18, Font.UNDERLINE));
            document.Add(new Paragraph("\n"));
            reference.Alignment = Element.ALIGN_CENTER;
            document.Add(reference);
            Paragraph referenceDetails = new Paragraph(personalDetails.Reference);
            //referenceDetails.Alignment = Element.ALIGN_CENTER;
            document.Add(referenceDetails);

            // Close the document
            document.Close();

            // Save the document to a file
            File.WriteAllBytes("cv.pdf", stream.ToArray());
        }
    }
}
