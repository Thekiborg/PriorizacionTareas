using System.Text.Json;

namespace PriorizacionTareas
{
	internal static class JsonHandler
	{
		private const string JsonPath = @".\planner.json";
		private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };


		/// <summary>
		/// Escribe el horario a JSON.
		/// </summary>
		/// <param name="planner">El objeto de horario a guardar.</param>
		public static void WriteToJSON(Planner planner)
		{
			try
			{
				using var stream = File.Create(JsonPath);
				JsonSerializer.Serialize(stream, planner, JsonOptions);
			}
			catch (Exception e)
			{
				Console.WriteLine("No se ha podido crear el archivo JSON: " + e.Message);
			}
		}


		/// <summary>
		/// Lee el horario guardado en JSON
		/// </summary>
		/// <returns>Un objeto de horario con los datos del JSON.</returns>
		public static Planner? ReadFromJSON()
		{
			try
			{
				using var stream = File.OpenRead(JsonPath);
				return JsonSerializer.Deserialize<Planner>(stream);
			}
			catch (Exception e)
			{
				Console.WriteLine("No se ha podido leer el archivo JSON: " + e.Message);
				return null;
			}

		}
	}
}
