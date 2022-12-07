using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingController : MonoBehaviour
{
    int stage = GameManager.CurrStage;
    TextMeshPro loadingText;
    string defaultText = "LOADING GAME . . .";

    private void Awake()
    {
        loadingText = GameObject.Find("LoadingText").GetComponent<TextMeshPro>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("getSceneAsync");
    }

    IEnumerator getSceneAsync() {
        string sceneName = GameManager.SceneNameDic[GameManager.SceneEnum.STAGE] + stage.ToString();
        AsyncOperation loadConfig = SceneManager.LoadSceneAsync(sceneName);

        if (!loadConfig.isDone)
        {
            string changeText = defaultText + ((int)loadConfig.progress).ToString();
            loadingText.text = changeText;
            yield return null;
        } else
        {

        }
    }
}
