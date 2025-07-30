using System.ComponentModel.DataAnnotations;

namespace BloodDoner.Mvc.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

    }
}
