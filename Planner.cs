namespace PriorizacionTareas
{
	internal class Planner
	{
		/// <summary>
		/// Horas disponibles para hacer tareas. Leido desde JSON.
		/// </summary>
		public required int WorkHours { get; set; }

		/// <summary>
		/// Numero de tareas por hacer. Leido desde JSON.
		/// </summary>
		public required List<PlannerTask> Tasks { get; set; }

		public Planner() { }
	}
}
