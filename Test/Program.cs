using DataModulesSystem;
namespace Test
{
	internal class Program
	{
		static void Main()
		{
			Module module = LinerDataModules.Load("C:\\Users\\Alex\\source\\repos\\DataModulesSystem\\Test\\Data.txt");
			for(int i = 0; i < module?.childs.Count; i++)
			{
				Console.WriteLine(module?.childs[i].Name);
				Console.WriteLine(module?.childs[i].data);
			}
		}
	}
}