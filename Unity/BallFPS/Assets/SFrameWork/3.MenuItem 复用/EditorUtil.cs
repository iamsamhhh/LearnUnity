using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SFramework
{
    public partial class EditorUtil
    {

#if UNITY_EDITOR

        [MenuItem("SFramework/3.MenuItem 复用", false, 3)]
        private static void MenuClicked()
        {
            CallMenuItem("SFramework/2.复制文本到剪切板");
        }


        public static void CallMenuItem(string menuPath)
        {
            EditorApplication.ExecuteMenuItem(menuPath);

            Debug.LogFormat("\"" + menuPath + "\" Executed!");
        }


        public static void OpenInFolder(string folderPath)
        {
            Application.OpenURL("file://" + folderPath);

            Debug.LogFormat("\"file://" + folderPath + "\" Opened!");
        }


        public static void ExportPackage(string assetPathName, string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);

            Debug.LogFormat("Package on the assest path\"" + assetPathName + "\" export  successfully!" + @" File name: {0}", fileName);
        } 

#endif

    }

}