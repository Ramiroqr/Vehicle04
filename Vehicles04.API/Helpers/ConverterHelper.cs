using System;
using System.Threading.Tasks;
using Vehicles04.API.Data;
using Vehicles04.API.Data.Entities;
using Vehicles04.API.Models;

namespace Vehicles04.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool IsNew)
        {
            return new User
            {
                Address = model.Address,
                Documet = model.Documet,
                DocumetType = await _context.DocumetTypes.FindAsync(model.DocumentTypeId),
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Id = IsNew ? Guid.NewGuid().ToString() : model.Id,
                ImageId = imageId,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email,
                UserType = model.UserType,
            };
        }

        public UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Address = user.Address,
                Documet = user.Documet,
                DocumentTypeId = user.DocumetType.Id,
                DocumentTypes = _combosHelper.GetComboDocumentTypes(),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
            };
        }
    }
}
