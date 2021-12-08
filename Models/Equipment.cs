using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Equipment_Rental_Application.Models
{
    // Store equipment that is available for renting
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EquipmentName { get; set; }
        [Required]
        public string EquipmentType { get; set; }
    }
}
