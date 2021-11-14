using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles04.API.Data.Entities;
using Vehicles04.API.Models;

namespace Vehicles04.API.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool IsNew);

        UserViewModel ToUserViewModel(User user);
    }
}
