using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GetVPMatrix_camera1 : MonoBehaviour
{
    Camera cam;
    Vector3 initAng;
    Vector3 originPos;
    GameObject obj;
    public float rotation_speed = 1f;
    public float radius = 10f;
    int flag = 1;

    public static GameObject data;
    DataRead reader;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("DataReader");
        reader = data.GetComponent<DataRead>();

        cam = this.gameObject.GetComponent<Camera>();
        initAng = cam.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (reader.user1_index < 0) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            flag = -(flag);
        }

        if (flag == -1)
        {
            return;
        }
        else
        {
            originPos = get_cameraOriginPos(reader.user1_obj);

            float xAng = reader.angle_x[reader.user1_index] * rotation_speed;
            float yAng = reader.angle_y[reader.user1_index] * rotation_speed;
            float zAng = initAng.z;
            Vector3 angle = new Vector3(xAng, yAng, zAng);
            cam.transform.eulerAngles = angle;

            float xPos = -(radius * Mathf.Sin((90f - xAng) * Mathf.Deg2Rad) * Mathf.Sin(yAng * Mathf.Deg2Rad)) + originPos.x;
            float yPos = radius * Mathf.Cos((90f - xAng) * Mathf.Deg2Rad) + originPos.y;
            float zPos = -(radius * Mathf.Sin((90f - xAng) * Mathf.Deg2Rad) * Mathf.Cos(yAng * Mathf.Deg2Rad)) + originPos.z;
            Vector3 position = new Vector3(xPos, yPos, zPos);
            cam.transform.localPosition = position;
            //UnityEngine.Debug.Log($"user1_camera_Pos:{position}");
        }
    }

    private Vector3 get_cameraOriginPos(string user1_obj)
    {
        Vector3 position = new Vector3(0f, 0f, 0f);
        if (SceneManager.GetActiveScene().name == "Sample")
        {
            obj = GameObject.Find(user1_obj);
            position = obj.transform.position;
        }
        else if (SceneManager.GetActiveScene().name == "MentalBlock")
        {
            position = new Vector3(0f, 0f, 0f);
        }
        else if (SceneManager.GetActiveScene().name == "VoiceGame" || SceneManager.GetActiveScene().name == "VoiceGame1" || SceneManager.GetActiveScene().name == "VoiceGame2" || SceneManager.GetActiveScene().name == "VoiceGame3" || SceneManager.GetActiveScene().name == "VoiceGame4" || SceneManager.GetActiveScene().name == "VoiceGame5" || SceneManager.GetActiveScene().name == "VoiceGame6" || SceneManager.GetActiveScene().name == "VoiceGame7" || SceneManager.GetActiveScene().name == "VoiceGame8")
        {
            obj = GameObject.Find(user1_obj);
            position = obj.transform.position;
        }
        else if (SceneManager.GetActiveScene().name == "ClickGame")
        {
            obj = GameObject.Find(user1_obj);
            position = obj.transform.position;
        }

        return position;
    }
}
