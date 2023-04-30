using CV_Maker.IRepository;
using CV_Maker.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_Maker.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IPersonalDetailsRepository _personalDetailsRepository;

        public PersonalDetailsController(IPersonalDetailsRepository personalDetailsRepository)
        {
            _personalDetailsRepository = personalDetailsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create( PersonalDetail personalDetails)
        {
            await _personalDetailsRepository.Create(personalDetails);
            return Ok(personalDetails);
        }

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
