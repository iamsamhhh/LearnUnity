using UnityEngine;

namespace SFramework
{
    public partial class MathUtil
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("SFramework/9.从若干个值中随机取出一个值", false, 10)]
#endif
        private static void GetRandomValueFromMenuClicked()
        {
            Debug.Log(GetRandomValueFrom(1, 2, 3));
            Debug.Log(GetRandomValueFrom("asdasd", "123123"));
            Debug.Log(GetRandomValueFrom(0.1f, 0.2f));
        }

        public static T GetRandomValueFrom<T>(params T[] values)
        {
            return values[Random.Range(0, values.Length)];
        }
    }
}