using CV_Maker.Repository.Models;

namespace CV_Maker.IRepository
{ /// <summary>
///interface methods in the repository , they are for management of personal details
/// </summary>
    public interface IPersonalDetailsRepository
    {
        /// <summary>
        /// creates personal details
        /// </summary>
        /// <param name="personalDetails"></param>
        /// <returns></returns>
       Task Create(PersonalDetail personalDetails);

        /// <summary>
        /// reads personal details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<PersonalDetail> GetById(int id);

        /// <summary>
        /// read personal details used for creation of pdf doc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonalDetail GetInfoById(int id);
    }
}
