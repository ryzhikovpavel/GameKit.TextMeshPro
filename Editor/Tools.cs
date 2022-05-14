using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameKit.TextMeshPro.Editor
{
    public class Tools
    {
        [MenuItem("GameKit/Tools/TextMeshPro/Fix HDR")]
        private static void FixHDR()
        {
            var path = Path.Combine(Application.dataPath, "..", "Library/PackageCache/");
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                if (directory.Contains("com.unity.textmeshpro"))
                {
                    path = Path.Combine(path, directory, "Scripts/Editor/TMP_BaseShaderGUI.cs");
                    break;
                }
            }

            if (File.Exists(path) == false)
            {
                Debug.LogError("TextMeshPro plugin not found");
                return;
            }

            var fileContent = File.ReadAllText(path);
            fileContent = fileContent.Replace(
                "Color value = EditorGUI.ColorField(EditorGUILayout.GetControlRect(), s_TempLabel, property.colorValue, false, true, true);",
                "Color value = EditorGUI.ColorField(EditorGUILayout.GetControlRect(), s_TempLabel, property.colorValue, false, true, false);");
            
            File.WriteAllText(path, fileContent);
            
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.IsReadOnly = true;
            
            
            Debug.Log("TextMesh Pro HDR bug is fixed successful");
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}