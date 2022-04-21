using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Entities
{
    public class Position
    {
        [Key] //Key data annotation - convention for primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Generates primary keys
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}