using Microsoft.Build.Framework;
using System.Reflection;
using System.Runtime.Loader;
using System.Text.Json;
using BUILD = Microsoft.Build.Utilities;

namespace TestAccountability.BuildTasks
{
	public class ReportGenerationTask : BUILD.Task
	{
		[Required]
		public string AssemblyPath { get; set; }

		[Required]
		public string OutputPath { get; set; }

		public override bool Execute()
		{

			AssemblyLoadContext loadContext = null!;

			try
			{
				Log.LogMessage($"Generating report for {AssemblyPath} to {OutputPath}");

				loadContext = new AssemblyLoadContext("ReportGenerationTask", true);
				var assembly = loadContext.LoadFromAssemblyPath(AssemblyPath);
				var methodDetails = new List<MethodDetail>();

				foreach (var type in assembly.GetTypes())
				{
					foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
					{
						var featureAttribute = method.GetCustomAttribute<FeatureAttribute>();
						if (featureAttribute is null) continue;

						var featureName = featureAttribute.FeatureId;
						methodDetails.Add(new MethodDetail
						{
							MethodName = $"{type.FullName}.{method.Name}",
							FeatureName = featureName
						});
					}
				}

				var json = JsonSerializer.Serialize(methodDetails);
				File.WriteAllText(OutputPath, json);

				// Unload the assembly
				//loadContext.

				return true;
			}
			catch (Exception ex)
			{
				Log.LogError($"Error of type {ex.GetType()} occurred while generating report");
				Log.LogErrorFromException(ex);

				if (ex is ReflectionTypeLoadException reflectionTypeLoadException)
				{
					foreach (var loaderException in reflectionTypeLoadException.LoaderExceptions)
					{
						Log.LogError(loaderException.Message);
					}
				}

				return false;
			}
			finally
			{
				if (loadContext != null)
				{
					loadContext.Unload();
				}

			}
		}
	}

	public class MethodDetail
	{
		public string MethodName { get; set; }
		public string FeatureName { get; set; }
	}

}
