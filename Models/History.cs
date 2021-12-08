using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equipment_Rental_Application.Models
{
    // History model is used for keeping renting history and creating the invoice
    public class History
    {
        [Key]
        public int Id { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentType { get; set; }
        public int Duration { get; set; }
        public DateTime OrderTime { get; set; }
        [NotMapped]
        public int Price { get; set; }
        [NotMapped]
        public int Total { get; set; }
    }
}