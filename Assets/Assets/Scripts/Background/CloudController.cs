using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private static bool isInit = true;
    float Default_Cloud_Move_Speed = 2f;
    List<float> Cloud_Pos_Y = new List<float> {
        2.5f,
        2f,
        1.5f,
        1.0f
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        int randomIndex = (int)Mathf.Floor(Random.value * Cloud_Pos_Y.Count);
        float xPos = Camera.main.transform.position.x + 10;
        transform.position = new Vector3(xPos, Cloud_Pos_Y[randomIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - Default_Cloud_Move_Speed * Time.deltaTime, transform.position.y);
        checkCloudOutOfCamera();
    }

    void checkCloudOutOfCamera()
    {
        Vector3 viewPort = Camera.main.WorldToViewportPoint(transform.position);
        if(viewPort.x < -0.1)
        {
            resetCloud();
        }
    }

    void resetCloud()
    {
        gameObject.SetActive(false);

        Invoke("spawnCloud", 1);
    }

    void spawnCloud()
    {
        for(int i=0; i< transform.parent.childCount; i++)
        {
            if(transform.parent.GetChild(i).gameObject.activeInHierarchy == false)
            {
                transform.parent.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }
}
