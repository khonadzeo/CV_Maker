using CV_Maker.Repository.Models;

namespace CV_Maker.IServices
{
    public interface ICVgenerator
    {
       Task GeneratePdf(PersonalDetail personalDetails);
    }
}
