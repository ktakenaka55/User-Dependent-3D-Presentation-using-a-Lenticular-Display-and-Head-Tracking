using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer_Block : MonoBehaviour
{
	//[SerializeField] private int minute;
	private static float seconds;

	private float oldSeconds; //�O��Update�̎��̕b��
	private TextMeshProUGUI timerText;   //�^�C�}�[�\���p�e�L�X�g


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
		//�@�l���ς�����������e�L�X�gUI���X�V
		if ((int)seconds != (int)oldSeconds)
		{

			//timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
			timerText.text = seconds.ToString("000");
			Debug.Log("���v����" + seconds.ToString("n2") + "�b");
		}
		oldSeconds = seconds;

	}

	public static float GetTime()
	{
		return seconds;
	}
}
