using CV_Maker.Repository.Models;

namespace CV_Maker.IRepository
{
    public interface IPersonalDetailsRepository
    {
        Create(PersonalDetail personalDetails);
    }
}
