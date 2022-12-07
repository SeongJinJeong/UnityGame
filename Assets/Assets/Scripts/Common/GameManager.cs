using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum SceneEnum{
        LOADING_SCENE,
        STAGE
    }
    public static Dictionary<object, string> SceneNameDic = new Dictionary<object, string>()
    {
        {SceneEnum.LOADING_SCENE , "LoadingScene" },
        {SceneEnum.STAGE, "Stage" },
    };
    private static int currStage = 0;
    public static int CurrStage
    {
        get
        {
            print("GET CURRENT STAGE");
            return currStage; 
        }
        set
        {
            currStage = value;
        }
    }

    public static GameManager instance;
    public static GameManager getInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            if(instance != this) {
                Destroy(gameObject);
            }
        }
    }

    public void onGameStart()
    {
        SceneManager.LoadScene(SceneNameDic[SceneEnum.LOADING_SCENE]);
    }
}
