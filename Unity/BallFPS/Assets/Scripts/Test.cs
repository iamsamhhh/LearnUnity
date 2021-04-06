using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public class Test : MonoBehaviourSimplify
{
    int i;
    private void Update()
    {
        i++;
        if (i > 99)
        {
            i = 0;
        }

    }
}
