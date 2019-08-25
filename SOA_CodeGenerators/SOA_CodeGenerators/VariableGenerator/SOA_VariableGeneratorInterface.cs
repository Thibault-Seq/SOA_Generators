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

    public partial class SOA_VariableGeneratorInterface : SOA_VariableGenerator
    {
        [MenuItem("SOA Generators/Variable")]
        public static void Generate()
        {
            string outputPath = EditorUtility.SaveFilePanelInProject(title: "Save Location", defaultName: "new Variable", extension: "cs", message: "Be sure that your variable is valid");

            SOA_VariableGenerator generator = new SOA_VariableGenerator();

            generator.Session = new Dictionary<string, object>();


            string variableName = Path.GetFileNameWithoutExtension(outputPath);

            generator.Session["Variable"] = variableName;

            generator.Initialize();

            string classDef = generator.TransformText();


            File.WriteAllText(outputPath.Remove(outputPath.Length - (variableName.Length+3)) +"SOA_Variables_" + variableName + ".cs", classDef);

            AssetDatabase.Refresh();
        }
    }
}
#endif
