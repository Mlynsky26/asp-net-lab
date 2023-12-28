using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("cars")]
    public class CarEntity
    {
        [Key]
        public int Id { get; set; }

        [Column("maker")]
        [Required]
        [MaxLength(50)]
        public string Maker { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("volume")]
        [Required]
        public int Volume { get; set; }

        [Column("power")]
        [Required]
        public int Power { get; set; }

        [Column("engine_type")]
        [Required]
        public int EngineType { get; set; }

        [Column("registration")]
        [Required]
        [MaxLength(10)]
        public string Registration { get; set; }

        [Column("owner")]
        public OwnerEntity? Owner { get; set; }
        public int? OwnerId { get; set; }
    }
}
