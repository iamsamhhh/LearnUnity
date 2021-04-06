#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using Random = UnityEngine.Random;

namespace SFramework
{
    public partial class MathUtil
    {
        /// <summary>
        /// 输入百分比返回是否命中概率
        /// </summary>
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }

#if UNITY_EDITOR
        [MenuItem("SFramework/6.概率函数", false, 7)]
#endif
        private static void MenuClicked()
        {
            Debug.Log(Percent(50));
        }
    }
}