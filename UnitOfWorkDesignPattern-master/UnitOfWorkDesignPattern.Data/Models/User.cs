using System;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkDesignPattern.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(32)]
        public string Username { get; set; }
        [Required]
        [MaxLength(64)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(150)]
        public string EMail { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}