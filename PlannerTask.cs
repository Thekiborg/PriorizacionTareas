namespace PriorizacionTareas
{
	internal class PlannerTask
	{
		/// <summary>
		/// El valor que tiene cada tarea.
		/// </summary>
		public required int Score { get; set; }

		/// <summary>
		/// El número de horas que se tarda en completar esta tarea.
		/// </summary>
		public required float Hours { get; set; }
	}
}
