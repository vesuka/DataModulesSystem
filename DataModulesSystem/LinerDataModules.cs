
namespace DataModulesSystem
{
	public static class LinerDataModules
	{
		public static Module Load(string path)
		{
			System.IO.StreamReader streamReader = new(path);

			Module resultModule = new("Had");

			string Text = streamReader.ReadToEnd();


			for(int index = 0; index < Text.Length; index++)
			{
				if (Text[index] == '{')
				{
					Module NameSpace = new ("No Named namespace");
					NameSpace.childs.AddRange(LoadNamespace(Text, ref index));
					resultModule.childs.Add(NameSpace);

				}
				else if (Text[index] == '<')
					resultModule.childs.Add(LoadModule(Text, ref index));
			}

			return resultModule;
		}
		private static Module LoadModule(string text, ref int index)
		{
			string? name = null;
			string? data = null;

			Module result = new ("");

			if (text[index] != '<') throw new System.Exception();

			for (; index < text.Length; index++)
			{
				if (text[index] == '>') break;
				if (text[index] == '"')
				{
					index++;
					for (; index < text.Length; index++)
					{
						if (text[index] == '"') break;
						name += text[index];
					}
				}
				if (text[index] == '*')
				{
					index++;
					for (; index < text.Length; index++)
					{
						if (text[index] == '*') break;
						data += text[index];
					}
				}
			}
			for(index++;index < text.Length; index++)
			{
				if (text[index] == ';') break;
				if ( text[index] == ' ' || text[index] == '\r' || text[index] == '\n' || text[index] == '\t') continue;
				else if (text[index] == '-')
				{
					index++;
					for (; index < text.Length; index++)
					{
						if (text[index] == ';') break;
						if (text[index] == ' ' || text[index] == '\r' || text[index] == '\n' || text[index] == '\t') continue;
						if (text[index] != '{') throw new System.Exception($"{text[index]}");

						result.childs.AddRange(LoadNamespace(text, ref index));
						break;
					}
				}
				else
				{
					throw new System.Exception(text[index].ToString());
				}
			}

			result.Name = name ?? "ModuleStandartName";
			result.data = data;
			return result;
		}
		private static Module[] LoadNamespace(string text, ref int index)
		{
			if (text[index] != '{') throw new System.Exception();
			System.Collections.Generic.List<Module> result = new();

			index++;

			for (; index < text.Length; index++)
			{
				if (text[index] == '}') break;

				if (text[index] == ' ' || text[index] == '\r' || text[index] == '\n' || text[index] == '\t') continue;
				
				else if (text[index] != '<') throw new System.Exception($"{text[index]}");
				result.Add(LoadModule(text, ref index));
			}

			return result.ToArray();
		}
	}
}