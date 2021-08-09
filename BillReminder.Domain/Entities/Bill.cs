using BillReminder.Domain.Enums;
using BillReminder.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BillReminder.Domain.Entities
{
    public class Bill : Entity
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public ECategory Category { get; set; }
    }
}
