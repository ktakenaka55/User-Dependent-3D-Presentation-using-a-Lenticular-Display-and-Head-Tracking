using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer_Block : MonoBehaviour
{
	//[SerializeField] private int minute;
	private static float seconds;

	private float oldSeconds; //前のUpdateの時の秒数
	private TextMeshProUGUI timerText;   //タイマー表示用テキスト


	void Start()
	{
		//minute = 0;
		seconds = 0f;
		oldSeconds = 0f;
		timerText = GetComponentInChildren<TextMeshProUGUI>();
	}

	void Update()
	{
		seconds += Time.deltaTime;
		//if (seconds >= 60f)
		//{
		//	minute++;
		//	seconds = seconds - 60;
		//}
		//　値が変わった時だけテキストUIを更新
		if ((int)seconds != (int)oldSeconds)
		{

			//timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
			timerText.text = seconds.ToString("000");
			Debug.Log("所要時間" + seconds.ToString("n2") + "秒");
		}
		oldSeconds = seconds;

	}

	public static float GetTime()
	{
		return seconds;
	}
}
