using CV_Maker.Repository.Models;

namespace CV_Maker.IServices
{
    public interface IPersonalDetailsService
    {

        Task Create(PersonalDetail personalDetails);

        IQueryable<PersonalDetail> GetById(int id);

        PersonalDetail GetInfoById(int id);
    }
}
