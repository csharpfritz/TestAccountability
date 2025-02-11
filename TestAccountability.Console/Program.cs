// read an input argument that references a .NET DLL and read the methods of all classes in that DLL

using System.Reflection;
using TestAccountability;


if (args.Length == 0)
{
	System.Console.WriteLine("Please provide a path to a .NET DLL.");
	return;
}
string path = args[0];
if (!File.Exists(path))
{
	System.Console.WriteLine("The file does not exist.");
	return;
}
Assembly assembly = Assembly.LoadFrom(path);
foreach (Type type in assembly.GetTypes())
{

	foreach (MethodInfo method in type.GetMethods())
	{

		// if the method is decorated with the FeatureAttribute, print the feature name
		foreach (Attribute attribute in method.GetCustomAttributes())
		{
			if (attribute is FeatureAttribute featureAttribute)
			{
				System.Console.WriteLine($"{type.FullName}.{method.Name} - Feature {featureAttribute.FeatureId}");
			}
		}
	}


}