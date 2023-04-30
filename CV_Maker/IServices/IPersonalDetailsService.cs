using CV_Maker.Repository.Models;

namespace CV_Maker.IServices
{
    /// <summary>
    /// contains methods or services to manage person details
    /// </summary>
    public interface IPersonalDetailsService
    {

        Task Create(PersonalDetail personalDetails);

        IQueryable<PersonalDetail> GetById(int id);

        PersonalDetail GetInfoById(int id);
    }
}
