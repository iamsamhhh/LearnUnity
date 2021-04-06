using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

//public class Line : MonoBehaviourSimplify
//{
//    public GameObject gameobject;
    
//    float dis;
    
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//            RaycastHit hit;
//            if (Physics.Raycast(ray, out hit))
//            {
//               dis = TransformSimplify.CauculateDis(Vector3.zero, hit.point);
//            }

//            GameObject hhh = Instantiate(gameobject, Vector3.zero, Quaternion.LookRotation(TransformSimplify.CauculateDir(Vector3.zero, hit.point)));

//            hhh.transform.localScale = new Vector3(0.1f, 0.1f, dis);
            
            
//        }
//    }
//}

namespace SFramework
{
    public partial class MathUtil
    {
        public static float RoundTo1000th(float num)
        {
            return (float)(Mathf.Round(num * 1000)) / 1000;
        }
        public static float RoundTo100th(float num)
        {
            return (float)(Mathf.Round(num * 100)) / 100;
        }
        public static float RoundTo10th(float num)
        {
            return (float)(Mathf.Round(num * 10)) / 10;
        }
    }

    public partial class TransformSimplify
    {
        public static Quaternion LookAtDir(Vector3 dir, Vector3 up, Transform trans)
        {
            var rot = Quaternion.LookRotation(dir, up);
            trans.rotation = rot;
            return rot;
        }

        public static Quaternion LookAtDir(Vector3 dir, Vector3 up)
        {
            var rot = Quaternion.LookRotation(dir, up);
            return rot;
        }

        public static Quaternion LookAtDir(Vector3 dir)
        {
            var rot = Quaternion.LookRotation(dir);
            return rot;
        }

        public static Quaternion LookAtDir(Vector3 dir, Transform trans)
        {
            var rot = Quaternion.LookRotation(dir);
            trans.rotation = rot;
            return rot;
        }

        public static Vector3 CauculateDir(Vector3 from, Vector3 to)
        {
            return to - from;
        }

        public static float CauculateDis(Vector3 from, Vector3 to)
        {
            return MathUtil.RoundTo1000th(TransformSimplify.CauculateDir(from, to).magnitude);
        }
    }
}
