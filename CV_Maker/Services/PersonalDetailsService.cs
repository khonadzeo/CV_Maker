using CV_Maker.IServices;
using CV_Maker.Repository.Models;
using CV_Maker.Repository;

namespace CV_Maker.Services
{
    public class PersonalDetailsService : IPersonalDetailsService
    {
        private readonly Cv_MakerDbDbContext _connectionString;

        public PersonalDetailsService(Cv_MakerDbDbContext connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Create(PersonalDetail personalDetails)
        {
            await _connectionString.PersonalDetails.AddAsync(personalDetails);
            await _connectionString.SaveChangesAsync();
        }
        public IQueryable<PersonalDetail> GetById(int id)
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
