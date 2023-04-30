using CV_Maker.IRepository;
using CV_Maker.IServices;
using CV_Maker.Repository.Models;
using Microsoft.Data.SqlClient;

namespace CV_Maker.Repository
{/// <summary>
/// contains methods that calls the services
/// </summary>
    public class PersonalDetailsRepository : IPersonalDetailsRepository
    {
        private readonly IPersonalDetailsService _personalDetailsService;

        public PersonalDetailsRepository(IPersonalDetailsService personalDetailsService)
        {
            _personalDetailsService = personalDetailsService;
        }
        /// <summary>
        /// calls method to create personal details
        /// </summary>
        /// <param name="personalDetails"></param>
        /// <returns></returns>
        public async Task Create(PersonalDetail personalDetails)
        {
            await _personalDetailsService.Create(personalDetails);
           
        }
        /// <summary>
        /// calls method that reads personal details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable< PersonalDetail> GetById(int id)
        {
            var results=_personalDetailsService.GetById(id);
            return results;
        }
        /// <summary>
        /// calls method that reads personal details for generation of a pdf document
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonalDetail GetInfoById(int id)
        {
            var results=_personalDetailsService.GetInfoById(id);
            return results;
        }
    }
}
