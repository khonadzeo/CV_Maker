using CV_Maker.Repository.Models;

namespace CV_Maker.IServices
{
    /// <summary>
    /// interface contains methods for cv generation
    /// </summary>
    public interface ICVgenerator
    {
        /// <summary>
        ///method to generate pdf
        /// </summary>
        /// <param name="personalDetails"></param>
        /// <returns></returns>
       Task GeneratePdf(PersonalDetail personalDetails);
    }
}
