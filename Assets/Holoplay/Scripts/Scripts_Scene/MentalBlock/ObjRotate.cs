using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    GameObject obj;
    Vector3 angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.Find("obj2");

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            angle = new Vector3(0f, obj.transform.eulerAngles.y + 90f, 0f);
            obj.transform.eulerAngles = angle;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            angle = new Vector3(0f, obj.transform.eulerAngles.y - 90f, 0f);
            obj.transform.eulerAngles = angle;
        }
    }
}
