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
        resultText.text = "所要時間" + time.ToString("n2") + "秒";
        Debug.Log("所要時間" + time.ToString("n2") + "秒");
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
