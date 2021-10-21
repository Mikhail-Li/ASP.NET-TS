using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface ILoginManager
    {
        Task<LoginResponse> Authenticate(User user);
    }
}
