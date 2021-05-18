using System;
using System.IO;

using UnityEditor;
using UnityEngine;

namespace SFramework.Utils
{
    public partial class Exporter
    {
        [MenuItem("SFramework/Framework/Util/导出 UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            var generatePackageName = GenerateUnityPackageName();
            
            EditorUtil.ExportPackage("Assets/SFramework", generatePackageName + ".unitypackage");

            EditorUtil.OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }

        public static string GenerateUnityPackageName()
        {
            return "SFramework_" + DateTime.Now.ToString("yyyyMMdd");
        }
    }

    public partial class EditorUtil
    {
#if UNITY_EDITOR
        public static void CallMenuItem(string menuPath)
        {
            UnityEditor.EditorApplication.ExecuteMenuItem(menuPath);
        }

        public static void OpenInFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }

        public static void ExportPackage(string assetPathName, string fileName)
        {
            UnityEditor.AssetDatabase.ExportPackage(assetPathName, fileName, UnityEditor.ExportPackageOptions.Recurse);
        }
#endif
    }
}