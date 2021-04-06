using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.FPS
{
    public class PlayerRotate : MonoBehaviour
    {
        Transform tran, camTran;
        Vector2 rot, max_min;

        // Start is called before the first frame update
        void Start()
        {
            camTran = Camera.main.transform;
            tran = transform;
            rot = camTran.eulerAngles;
        }

        public void Set(float min, float max)
        {
            max_min.x = max;
            max_min.y = min;
        }

        public void Rotate(Vector2 input)
        {
            rot.x -= input.y;
            rot.y += input.x;

            rot.x = Mathf.Clamp(rot.x, max_min.y, max_min.x);

            tran.rotation = Quaternion.Euler(0, rot.y, 0);
            camTran.rotation = Quaternion.Euler(rot.x, rot.y, 0);
        }
    }
}