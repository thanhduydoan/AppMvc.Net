using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Contacts{
    public class Contacts{
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        public string FullName { get; set; }
        [StringLength(50)]
        [Required]
        public string Email { get; set; }
        public DateTime DataSent { get; set; }
        public string Message { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
    }
}