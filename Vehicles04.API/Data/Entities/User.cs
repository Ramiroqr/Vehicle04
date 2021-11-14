using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehicles04.Common.Enums;

namespace Vehicles04.API.Data.Entities
{
    public class User : IdentityUser
    {

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string LastName { get; set; }

        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DocumetType DocumetType { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Documet { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }


        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44396/images/no-image.png"
            : $"https://vehicle01.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        
        public ICollection<Vehicle> Vehicles { get; set; }

        public int VehiclesCount => Vehicles == null ? 0 : Vehicles.Count;
    }
}
