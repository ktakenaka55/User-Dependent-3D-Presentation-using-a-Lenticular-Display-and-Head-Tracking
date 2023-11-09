using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuControll : MonoBehaviour
{
    private GameObject practice;
    private GameObject easy;
    private GameObject moderate;
    private GameObject difficult;
    private GameObject obj_practice;
    private GameObject obj_easy;
    private GameObject obj_moderate;
    private GameObject obj_difficult;
    string practice_name;
    string easy_name;
    string moderate_name;
    string difficult_name;
    int menu = -1;
    int obj_num;
    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        practice = GameObject.Find("practice");
        easy = GameObject.Find("easy");
        moderate = GameObject.Find("moderate");
        difficult = GameObject.Find("difficult");
    }

    // Update is called once per frame
    void Update()
    {
        menu = GameStart_Block.gamemenu; //getGameMenu();
        GameStart_Block.gamemenu = -1;
        if (menu == 0)
        {
            obj_num = rnd.Next(1, 5);
            practice_name = "obj_p" + obj_num.ToString();
            obj_practice = practice.transform.Find(practice_name).gameObject;
            obj_practice.SetActive(true);
            menu = -1;
        }
        else if (menu == 1)
        {
            obj_num = rnd.Next(1, 5);
            easy_name = "obj_e" + obj_num.ToString();
            Debug.Log($"objobjobj{easy_name}");
            obj_easy = easy.transform.Find(easy_name).gameObject;
            obj_easy.SetActive(true);
            menu = -1;
        }
        else if (menu == 2)
        {
            obj_num = rnd.Next(1, 5);
            moderate_name = "obj_m" + obj_num.ToString();
            obj_moderate = moderate.transform.Find(moderate_name).gameObject;
            obj_moderate.SetActive(true);
            menu = -1;
        }
        else if (menu == 3)
        {
            obj_num = rnd.Next(1, 5);
            difficult_name = "obj_d" + obj_num.ToString();
            obj_difficult = difficult.transform.Find(difficult_name).gameObject;
            obj_difficult.SetActive(true);
            menu = -1;
        }
        else
        {

        }
    }
}
