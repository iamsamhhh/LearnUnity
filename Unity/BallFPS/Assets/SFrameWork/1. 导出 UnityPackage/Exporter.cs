using System.IO;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SFramework
{
    public class Exporter : MonoBehaviour
    {

#if UNITY_EDITOR
        [MenuItem("SFramework/1. 导出 UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            var generatePackageName = Exporter.GenerateUnityPackageName();

            EditorUtil.ExportPackage("Assets/SFramework", generatePackageName + ".unitypackage");

            EditorUtil.OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }
#endif

        private static string GenerateUnityPackageName()
        {
            Debug.LogFormat("Package name \"SFramework_" + DateTime.Now.ToString("yyyyMMdd_hhmm") + "\" Generated!");

            return "SFramework_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
        }

    }
}