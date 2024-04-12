namespace habitos_app.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Medication
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del medicamento es obligatorio.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int Quantity { get; set; }

        // Otras propiedades relacionadas con los medicamentos, como la dosis, la frecuencia, etc.
    }
}
