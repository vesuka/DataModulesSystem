namespace DataModulesSystem
{
	public class Module
	{
		public string Name { get; set; }

		public string? data;

		public System.Collections.Generic.List<Module> childs;

		public Module(string name,string? data = null)
		{
			Name = name;
			this.data = data;
			childs = new ();
		}

		
		
	}
}
