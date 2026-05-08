using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Domain
{
    [Serializable]
    [Table("Vehicle")]
    public class Vehicle : IEntity<int>
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        public string VehicleName { get; set; }

        [Required]
        [StringLength(25)]
        public string Brand { get; set; }

        [Required]
        [StringLength(15)]
        public string ModelYear { get; set; }

        [Required]
        [StringLength(15)]
        public string RegistrationNo { get; set; }
    }
}
