namespace PriorizacionTareas
{
    internal class Program
    {
        private static Planner? planner;
        private static readonly List<PlannerTask> selectedTasks = [];
        private static float remainingHours;


		static void Main(string[] args)
        {
            planner = JsonHandler.ReadFromJSON();
            if (planner is not null)
            {
				PickTasks(planner);
                ShowSummary();
			}
            else
            {
                Console.WriteLine("No se ha encontrado información en el json");
            }
            
            Thread.Sleep(-1);
            // Evita que se cierre la consola
        }


        /// <summary>
        /// Muestra por pantalla las tareas elegidas con sus horas y su valor, junto con un valor total y el número de horas sobrante.
        /// </summary>
        private static void ShowSummary()
        {
            int totalScore = 0;
            Console.WriteLine("Selected tasks: " + selectedTasks.Count);
            foreach (var task in selectedTasks)
            {
                totalScore += task.Score;
                Console.WriteLine($"{task.Hours} hours - {task.Score} score");
            }
            Console.WriteLine("Total score: " + totalScore);
            Console.WriteLine("Free hours: " + remainingHours.ToString("0.0"));
        }


        /// <summary>
        /// Intenta elegir la mejor combinacion de tareas que hacer siguiendo lo siguiente:<br></br>
        /// 1. Ordena todas las tareas por su valor.<br></br>
        /// 2. Guarda las tareas una por una mientras que queden horas disponibles.<br></br> 
        /// Si una tarea fuera a sobrepasar el límite de horas disponibles, será ignorada.<br></br>
        /// Al final, el número de horas ocupadas no debería ser mayor al número de horas disponibles. Si esto pasa se dirá por la consola.
        /// </summary>
        /// <param name="planner">El objeto de horario del que salen las tareas.</param>
        private static void PickTasks(Planner planner)
        {
            selectedTasks.Clear();
            remainingHours = planner.WorkHours;
            var tasks = planner.Tasks.OrderByDescending(task => task.Score);

            foreach (var task in tasks)
            {
                if (remainingHours - task.Hours < 0) continue;

                selectedTasks.Add(task);
                remainingHours -= task.Hours;

                if (remainingHours == 0) break;
                if (remainingHours < 0)
                {
                    Console.WriteLine("Algo ha salido mal evaluando las tareas");
                    break;
                }
            }
        }
    }
}
