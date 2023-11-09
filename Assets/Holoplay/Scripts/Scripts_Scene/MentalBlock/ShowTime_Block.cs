using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowTime_Block : MonoBehaviour
{
    private TextMeshProUGUI resultText;

    // Start is called before the first frame update
    void Start()
    {
        resultText = GetComponentInChildren<TextMeshProUGUI>();
        float time = Timer_Block.GetTime();
        resultText.text = "èäóvéûä‘" + time.ToString("n2") + "ïb";
        Debug.Log("èäóvéûä‘" + time.ToString("n2") + "ïb");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("BlockStart");
        }
    }
}
