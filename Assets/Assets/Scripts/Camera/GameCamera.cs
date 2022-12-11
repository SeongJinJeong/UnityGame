using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    float DefaultCameraMovement = 18.5f;
    Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GameObject.Find("Player/Player").transform.position;
        if(pos.x != playerPos.x & transform.position.x >= 0 & pos.x >= 0)
        {
            transform.position = new Vector3(pos.x, transform.position.y);
            playerPos = pos;
        }
    }

    void changeCameraPos(Vector3 viewPort)
    {
        Vector3 pos = new Vector3(playerPos.x + playerPos.x / 2, Camera.main.transform.position.y);
        Camera.main.transform.position = pos;
    }
}
