﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles04.API.Data.Entities
{
    public class DocumetType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Documento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
