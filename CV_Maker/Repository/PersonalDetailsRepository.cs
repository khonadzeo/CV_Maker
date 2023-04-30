using CV_Maker.IRepository;
using CV_Maker.IServices;
using CV_Maker.Repository.Models;
using Microsoft.Data.SqlClient;

namespace CV_Maker.Repository
{
    public class PersonalDetailsRepository : IPersonalDetailsRepository
    {
        private readonly Cv_MakerDbDbContext _connectionString;
        private readonly IPersonalDetailsService _personalDetailsService;

        public PersonalDetailsRepository(Cv_MakerDbDbContext connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Create(PersonalDetail personalDetails)
        {
            await _connectionString.PersonalDetails.AddAsync(personalDetails);
            await _connectionString.SaveChangesAsync();
        }
        public IQueryable< PersonalDetail> GetById(int id)
        {
            var results = _connectionString.PersonalDetails;

            // return results;
            return from personalDetail in results
                   where personalDetail.Id == id
                   select personalDetail;
        }
        public PersonalDetail GetInfoById(int id)
        {
            return _connectionString.PersonalDetails.FirstOrDefault(p => p.Id == id);
        }



    }
}
