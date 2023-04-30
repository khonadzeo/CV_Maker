using CV_Maker.IRepository;
using CV_Maker.IServices;
using CV_Maker.Repository.Models;
using Microsoft.Data.SqlClient;

namespace CV_Maker.Repository
{
    public class PersonalDetailsRepository : IPersonalDetailsRepository
    {
        private readonly IPersonalDetailsService _personalDetailsService;

        public PersonalDetailsRepository(IPersonalDetailsService personalDetailsService)
        {
            _personalDetailsService = personalDetailsService;
        }

        public async Task Create(PersonalDetail personalDetails)
        {
            await _personalDetailsService.Create(personalDetails);
           
        }
        public IQueryable< PersonalDetail> GetById(int id)
        {
            var results=_personalDetailsService.GetById(id);
            return results;
        }
        public PersonalDetail GetInfoById(int id)
        {
            var results=_personalDetailsService.GetInfoById(id);
            return results;
        }
    }
}
