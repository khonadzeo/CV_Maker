using CV_Maker.Repository.Models;

namespace CV_Maker.IRepository
{
    public interface IPersonalDetailsRepository
    {
       Task Create(PersonalDetail personalDetails);

        IQueryable<PersonalDetail> GetById(int id);

        PersonalDetail GetInfoById(int id);
    }
}
