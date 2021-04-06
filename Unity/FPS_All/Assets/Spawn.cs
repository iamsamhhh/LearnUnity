using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<Material> mat;
    public GameObject planet;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5000; i++)
        {
            var pn = Instantiate(planet, RandomVector3(-50, 50), Quaternion.identity).GetComponent<ExplodeBullet>();
            pn.met = mat[Random.Range(0, mat.Count)];
        }
    }

    Vector3 RandomVector3(float min, float max)
    {
        return (new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
