namespace habitos_app.Web.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Medication
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "El nombre del medicamento es obligatorio.")]
		public string Nombre { get; set; }

		public int Unidad_id { get; set; }

		public int Via_admin_id { get; set; }

		[Required(ErrorMessage = "La cantidad del medicamento es obligatoria.")]
		[Range(0.1, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
		public float Cantidad { get; set; }
	}
}
