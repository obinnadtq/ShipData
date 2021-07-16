using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShipData.Model
{
    public class Ship
    {
        [Key]
        public int Id { get; set; }
        [Required, Column("Shipname")]
        public string Name { get; set; }
        [Required, Column("Length(meters)")]
        public double Length { get; set; }
        [Required, Column("Width(meters)")]
        public double Width { get; set; }
        [Required, Column("Shipcode")]
        public string Code { get; set; }

    }
}
