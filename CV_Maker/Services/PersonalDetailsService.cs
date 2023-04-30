using CV_Maker.IServices;
using CV_Maker.Repository.Models;
using CV_Maker.Repository;

namespace CV_Maker.Services
{
    /// <summary>
    /// contains methods that manages personal details
    /// </summary>
    public class PersonalDetailsService : IPersonalDetailsService
    {
        private readonly Cv_MakerDbDbContext _connectionString;

        public PersonalDetailsService(Cv_MakerDbDbContext connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// creates(insert) personal details
        /// </summary>
        /// <param name="personalDetails"></param>
        /// <returns></returns>
        public async Task Create(PersonalDetail personalDetails)
        {
            await _connectionString.PersonalDetails.AddAsync(personalDetails);
            await _connectionString.SaveChangesAsync();
        }
        /// <summary>
        /// gets personal details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<PersonalDetail> GetById(int id)
        {
            var results = _connectionString.PersonalDetails;

            return from personalDetail in results
                   where personalDetail.Id == id
                   select personalDetail;
        }
        /// <summary>
        /// gets personal details used for generation of pdf
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonalDetail GetInfoById(int id)
        {
            return _connectionString.PersonalDetails.FirstOrDefault(p => p.Id == id);
        }

    }
}
