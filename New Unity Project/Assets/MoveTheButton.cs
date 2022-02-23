using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheButton : MonoBehaviour
{
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 pos = tr.position;
        pos.x += Random.Range(-10, 10);
        tr.position = pos;*/
    }
}
