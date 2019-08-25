using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

#if UNITY_EDITOR
namespace SOA.CodeGenerators
{
    public class SOA_FullEventGenerator
    {
        [MenuItem("SOA Generators/Full Event")]
        public static void GenerateFullEvent()
        {
            string outputPath = EditorUtility.SaveFilePanelInProject(title: "Save Location", defaultName: "new full event", extension: "cs", message: "Be sure that your values are in the valid format");

            SOA_EventGeneratorInterface.Generate(outputPath);
            SOA_ListenerGeneratorInterface.Generate(outputPath);

        }
    }
}
#endif
