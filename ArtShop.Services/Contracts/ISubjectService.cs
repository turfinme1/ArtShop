using ArtShop.Web.ViewModels.Subject;

namespace ArtShop.Services.Contracts
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectViewModel>> GetAllAsync();

        Task<SubjectViewModel?> GetByIdAsync(int id);
    }
}
