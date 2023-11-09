using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRecog : MonoBehaviour
{
    public static GameObject data;
    OpenFaceReader openface;
    DataRead reader;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("DataReader");
        openface = data.GetComponent<OpenFaceReader>();
        reader = data.GetComponent<DataRead>();

        //Material blue = (Material)Materials.Load("blue");
        //Material red = (Material)Materials.Load("red");
        //Material black = (Material)Materials.Load("black");
    }

    // Update is called once per frame
    void Update()
    {
        if (reader.user_num == 2)
        {
            this.GetComponent<Renderer>().material.color = Color.black;
        }
        else if (reader.user_num == 1 && reader.user1_index >= 0 && reader.user2_index < 0)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (reader.user_num == 1 && reader.user1_index < 0 && reader.user2_index >= 0)
        {
            this.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
