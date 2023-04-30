using CV_Maker.IRepository;
using CV_Maker.Repository.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using CV_Maker.IServices;

namespace CV_Maker.Controllers
{
    /// <summary>
    /// provides endpoint for creation of cv document
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : Controller
    {
        private readonly IPersonalDetailsRepository _repository;
        private readonly ICVgenerator _generator;
        /// <summary>
        /// initialize constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="cVgenerator"></param>
        public CVController(IPersonalDetailsRepository repository ,ICVgenerator cVgenerator)
        {
            _generator = cVgenerator;
            _repository = repository;
        }
        /// <summary>
        /// this creates a pdf cv document from the personaldetails obtained by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GenerateCV(int id)
        {
            PersonalDetail personalDetails = (PersonalDetail)_repository.GetInfoById(id);

            // Generate the PDF document
            _generator.GeneratePdf(personalDetails);

            // Return the PDF document to the client
            byte[] pdfBytes = System.IO.File.ReadAllBytes("cv.pdf");
            return File(pdfBytes, "application/pdf", "cv.pdf");
        }

    }

}
