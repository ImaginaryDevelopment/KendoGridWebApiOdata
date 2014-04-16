using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KendoGridWebApiOdata.Models
{
    public class Cat
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int? MateId { get; set; }

        [ForeignKey("MateId")]
        public virtual Cat Mate { get; set; }
    }
}