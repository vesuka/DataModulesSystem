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

		public Module GetChildForName(string name)
		{
			for(int i = 0; i < childs.Count; i++)
			{
				if (childs[i].Name == name)
				{
					return childs[i];
				}
			}
			throw new System.Exception("Name is not Found");
		}
		public Module GetChildForPath(string path)
		{
			string[] names = path.Split(':');
			Module activ = this;
			for(int i = 0;i < names.Length;i++)
			{
				activ = activ.GetChildForName(names[i]);
			}
			return activ;
		}
	}
}
