using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

#if UNITY_EDITOR
namespace SOA.CodeGenerators
{
    public partial class SOA_ListenerGeneratorInterface:SOA_ListenerGenerator
    {

        public static void Generate(string outputPath)
        {
            SOA_ListenerGenerator generator = new SOA_ListenerGenerator();

            generator.Session = new Dictionary<string, object>();


            string eventTypesFull = Path.GetFileNameWithoutExtension(outputPath);

            string[] eventTypesSplit = eventTypesFull.Split('_');

            generator.Session["Types"] = eventTypesSplit;

            generator.Initialize();

            string classDef = generator.TransformText();

            string[] sepparatedName = eventTypesFull.Split('_');
            string uppercasedName = "";
            for (int i = 0; i < sepparatedName.Length; i++)
            {
                char firstLetter = sepparatedName[i][0];
                sepparatedName[i] = sepparatedName[i].Remove(0, 1);
                uppercasedName += char.ToUpper(firstLetter) + sepparatedName[i];
            }

            File.WriteAllText(outputPath.Remove(outputPath.Length - (eventTypesFull.Length + 3)) + "SOA_Listener_" + uppercasedName + ".cs", classDef);

            AssetDatabase.Refresh();
        }
    }
}
#endif
