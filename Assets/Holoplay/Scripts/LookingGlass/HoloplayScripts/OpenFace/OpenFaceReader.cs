using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Linq;
using System.Diagnostics;

public class OpenFaceReader : MonoBehaviour
{
    // ���s�R�}���h
    // .\FaceLandmarkVidMulti.exe -device 0 -out_dir <out_dir> -of realtime
    // �C���X�y�N�^�̐ݒ�
    // CSVFilePath��"<out_dir>\realtime.csv";
    // FieldNames�Ɏg�������p�����[�^����ǉ�
    // ���̃I�u�W�F�N�g�ł͈ȉ��̂悤�Ɋ�̈ʒu��ǂ݂���
    // openFaceReader.faces[faceID].GetValue("gaze_0_x"));


    public string OpenFaceFilePath = @"C:\Users\klab\Documents\OpenFace_2.2.0_win_x64\FaceLandmarkVidMulti.exe";
    public string CSVFilePath = @"C:\Users\klab\Documents\OpenFace_2.2.0_win_x64\processed\realtime.csv";
    private ProcessStartInfo pInfo;
    private Process p;
    private FileStream fileStream;
    private StreamReader streamReader;
    private List<string> allFieldNames;
    private string[] fieldNames = new string[] { "pose_Tx", "pose_Ty", "pose_Tz" };//public
    public float[] fieldValues;
    public List<Face> faces = new();
    private bool headerRead = false;

    public float time_now = 0f;

    // Start is called before the first frame update
    void Start()
    {
        fileStream = new FileStream(CSVFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        streamReader = new StreamReader(fileStream, Encoding.UTF8);
    }

    // Update is called once per frame
    void Update()
    {
        if (!headerRead)
        {
            allFieldNames = streamReader.ReadLine().Split(", ").ToList();  
            headerRead = true;
            fileStream.Seek(0, SeekOrigin.End); 
            return;
        }

        var line = streamReader.ReadLine();
        if (line == null) return;

        var values = line.Split(", ");
        var isSuccess = int.Parse(values[allFieldNames.IndexOf("success")]); // == 1;
        if (isSuccess  == 0) return;
        var faceID = int.Parse(values[allFieldNames.IndexOf("face_id")]);
        var frame = int.Parse(values[allFieldNames.IndexOf("frame")]);
        var timestamp = float.Parse(values[allFieldNames.IndexOf("timestamp")]);
        time_now = timestamp;
        fieldValues = fieldNames.Select(x => float.Parse(values[allFieldNames.IndexOf(x)])).ToArray();

        // faceID���Ɋi�[
        if (faceID >= faces.Count)
        {
            faces.Add(new Face() { faceID = faceID, frame = frame, timestamp = timestamp, fieldNames = fieldNames, fieldValues = fieldValues });
        }
        else
        {
            faces[faceID].frame = frame;
            faces[faceID].timestamp = timestamp;
            faces[faceID].fieldValues = (float[])fieldValues.Clone();
        }
        UnityEngine.Debug.Log("isSuccess" + isSuccess);
        //UnityEngine.Debug.Log("x" + faces[faceID].GetValue("pose_Tx"));
    }


    public class Face
    {
        public int faceID, frame;
        public float timestamp;
        public float[] fieldValues;
        public string[] fieldNames;
        public float GetValue(string fieldName)
        {
            return fieldValues[fieldNames.ToList().IndexOf(fieldName)];
        }
    }
}
