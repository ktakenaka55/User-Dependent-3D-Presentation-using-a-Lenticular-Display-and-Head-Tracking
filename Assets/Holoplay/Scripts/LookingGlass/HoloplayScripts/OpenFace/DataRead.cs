using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Linq;
using System.Diagnostics;

public class DataRead : MonoBehaviour
{
    OpenFaceReader openface;
    private int[] flag = new int[5] { 0, 0, 0, 0, 0 };

    public float[] angle_x = new float[5];
    public float[] angle_y = new float[5];
    public int user_num = 0;
    public float center_angle;
    public int user1_index = -1;
    public int user2_index = -1;
    public string user1_obj;
    public string user2_obj;
    public int format_tracking = 0;  //0:‹“_’Ç]‚È‚µ, 1:‹“_’Ç]‚ ‚è
    public int format_split = 0;  //0:‰æ–Ê•ªŠ„‚È‚µ, 1:‰æ–Ê•ªŠ„‚ ‚è

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        openface = this.gameObject.GetComponent<OpenFaceReader>();

        for (int i = 0; i < openface.faces.Count; i++) 
        {
            var lastupdate_time = openface.faces[i].timestamp;
            if (openface.time_now - lastupdate_time < 1)
            {
                flag[i] = 1;
            }
            else
            {
                flag[i] = 0;
            }
            //UnityEngine.Debug.Log($"flag:{flag[0]},{flag[1]}");

            var x = openface.faces[i].GetValue("pose_Tx");
            var y = openface.faces[i].GetValue("pose_Ty");
            var z = openface.faces[i].GetValue("pose_Tz");
            angle_x[i] = (float)(Mathf.Atan2(-y, z) * 180 / Math.PI);
            angle_y[i] = (float)(Mathf.Atan2(x, z) * 180 / Math.PI);
            //UnityEngine.Debug.Log($"{i}::angle_x:{angle_x[i]}, angle_y:{angle_y[i]}");
        }


        user_num = flag.Count(x => x == 1);
        //UnityEngine.Debug.Log($"user_num:{user_num}");
        if (user_num == 0)
        {
            user1_index = -1;
            user2_index = -1;
        }
        else if (user_num == 1)
        {
            determine_userIndex1();
        }
        else
        {
            determine_userIndex2();
        }
    }

    private void determine_userIndex1()
    {
        if(format_split == 0)
        {
            user1_index = Array.IndexOf(flag, 1);
            user2_index = -1;
        }
        else
        {
            int index = Array.IndexOf(flag, 1);
            if(openface.faces[index].GetValue("pose_Tx") >= 0)
            {
                user1_index = index;
                user2_index = -1;
            }
            else
            {
                user1_index = -1;
                user2_index = index;
            }
        }

        //
        if (user1_index % 2 == 0)
        {
            user1_obj = "obj_A";
        }
        else
        {
            user1_obj = "obj_B";
        }
        UnityEngine.Debug.Log($"user:{user1_index},{user2_index}");
    }

    private void determine_userIndex2()
    {
        int index1 = Array.IndexOf(flag, 1);
        int index2 = Array.IndexOf(flag, 1, user1_index + 1);
        if(openface.faces[index1].GetValue("pose_Tx") >= openface.faces[index2].GetValue("pose_Tx"))
        {
            user1_index = index1;
            user2_index = index2;
        }
        else
        {
            user1_index = index2;
            user2_index = index1;
        }

        //
        if (user1_index % 2 == 0)
        {
            user1_obj = "obj_A";
        }
        else
        {
            user1_obj = "obj_B";
        }
        if (user2_index % 2 == 0)
        {
            user2_obj = "obj_A";
        }
        else
        {
            user2_obj = "obj_B";
        }
        UnityEngine.Debug.Log($"user:{user1_index},{user2_index}");

        center_angle = 35 - (int)((angle_y[user1_index] + angle_y[user2_index]) / 2);
    }
}
