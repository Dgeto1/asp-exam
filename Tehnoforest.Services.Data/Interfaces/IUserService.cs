namespace Tehnoforest.Services.Data.Interfaces
{
    using Tehnoforest.Web.ViewModels.User;

    public interface IUserService
    {
        Task<string> GetFullNameByIdAsync(string userId);
        Task<IEnumerable<UserViewModel>> AllAsync();
    }
}
