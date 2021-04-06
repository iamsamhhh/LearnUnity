using UnityEngine;

namespace SFramework
{
    public partial class CommonUtil
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("SFramework/2.复制文本到剪切板", false, 2)]
#endif
        private static void MenuClicked2()
        {
            CopyText("要复制的关键字");
        }


        public static void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;

            Debug.LogFormat("You've successfully copied \"" + text + "\"");
        }

    }
}