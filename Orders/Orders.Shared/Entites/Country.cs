﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Orders.Shared.Entites;
    public class Country
    {

    public int Id { get; set; }

    [Display(Name= "Pais")]
    [MaxLength(100, ErrorMessage= "El campo {0} no puede  tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

}

