﻿using System.ComponentModel.DataAnnotations;

namespace habitos_app.Web.Models
{
    public class MedicationDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int UnitId { get; set; }

        public int ViaAdminId { get; set; }

        public float Quantity { get; set; }

    }
}
