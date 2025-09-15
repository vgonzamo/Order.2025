﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Shared.Entites;

public class Category
{
    public int Id { get; set; }
    [Display(Name = "categoria")]
    [MaxLength(100, ErrorMessage = "El campo {0} no puede  tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string Name { get; set; } = null!;

}
