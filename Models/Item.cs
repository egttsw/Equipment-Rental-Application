using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equipment_Rental_Application.Models
{
    // Item model represents the shopping cart for rental equipment
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Equipment")]
        public string EquipmentName { get; set; }
        public string EquipmentType { get; set; }
       
        [DisplayName("Duration")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        public int Duration { get; set; }
        [NotMapped]
        public List<Equipment> Products { get; set; }
        [NotMapped]
        public int DropDownId { get; set; }

        public int Price { get; set; }

    }
}
