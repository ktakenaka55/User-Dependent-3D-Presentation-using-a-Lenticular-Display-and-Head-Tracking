using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart_Block : MonoBehaviour
{
    //private GameObject GameMenuController;
    //GameMenuControll gamemenucontroll;
    public static int gamemenu = -1;

    // Start is called before the first frame update
    void Start()
    {
        //GameMenuController = GameObject.Find("GameMenuController");
        //gamemenucontroll = GameMenuController.gameObject.GetComponent<GameMenuControll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            gamemenu = 0;
            //SceneManager.sceneLoaded += GameSceneLoaded();
            SceneManager.LoadScene("MentalBlock");
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            gamemenu = 1;
            //SceneManager.sceneLoaded += GameSceneLoaded();
            SceneManager.LoadScene("MentalBlock");
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            gamemenu = 2;
            //SceneManager.sceneLoaded += GameSceneLoaded();
            SceneManager.LoadScene("MentalBlock");
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            gamemenu = 3;
            //SceneManager.sceneLoaded += GameSceneLoaded();
            SceneManager.LoadScene("MentalBlock");
        }
    }

    ////static�ϐ��͂��̂܂܃O���[�o���ɎQ�Ɖ\
    //public static int getGameMenu()
    //{
    //    return gamemenu;
    //}

    ////�V�[���J�ڂƓ����ɕϐ��󂯓n���i���܂������Ȃ��I�H�j
    //void GameSceneLoaded(Scene next, LoadSceneMode mode)
    //{
    //    var gamemenucontroll = GameObject.FindWithTag("GameMenuController").GetComponent<GameMenuControll>();
    //    gamemenucontroll.menu = gamemenu;
    //    SceneManager.sceneLoaded -= GameSceneLoaded();
    //}
}
