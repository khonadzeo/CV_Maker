using CV_Maker.IRepository;
using CV_Maker.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{
    /// <summary>
    /// this contains endPoints for managing personal details
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IPersonalDetailsRepository _personalDetailsRepository;
        /// <summary>
        /// initialise constructor
        /// </summary>
        /// <param name="personalDetailsRepository"></param>
        public PersonalDetailsController(IPersonalDetailsRepository personalDetailsRepository)
        {
            _personalDetailsRepository = personalDetailsRepository;
        }
        /// <summary>
        /// inserts(create) personal details
        /// </summary>
        /// <param name="personalDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create( PersonalDetail personalDetails)
        {
            await _personalDetailsRepository.Create(personalDetails);
            return Ok(personalDetails);
        }

        /// <summary>
        /// retrieves personal details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var personalDetails = _personalDetailsRepository.GetById(id);

            if (personalDetails == null)
            {
                return NotFound();
            }

            return Ok(personalDetails);
        }
    }

}
