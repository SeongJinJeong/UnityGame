using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    bool isLobby = false;

    Camera cam;
    List<GameObject> backgrounds;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        backgrounds = new List<GameObject>(GameObject.FindGameObjectsWithTag("Background"));
        gameObject.transform.position = new Vector3(0, 0);
    }

    void Update()
    {
        moveAllBackground();
        checkBackgroundCameraOut();
    }

    void moveAllBackground()
    {
        float xPos = transform.position.x - Time.deltaTime * moveSpeed;
        this.transform.position = new Vector3(xPos, 0);
    }

    private void checkBackgroundCameraOut()
    {
        backgrounds.ForEach((gameObject) =>
        {
            Vector3 view = cam.WorldToViewportPoint(gameObject.transform.position);
            if(view.x < -0.6)
            {
                moveBackground(gameObject);
            }
        });
    }

    private void moveBackground(GameObject gObject) {
        float lastObjectPos = 0f;
        backgrounds.ForEach((gameObject) =>
        {
            float curPos = gameObject.transform.position.x;
            if(curPos > lastObjectPos)
            {
                lastObjectPos = curPos;
            }
        });

        float bgWidth;
        if (isLobby)
        {
            bgWidth = gObject.GetComponent<SpriteRenderer>().size.x;
        } else
        {
            bgWidth = gObject.transform.Find("Hills").GetComponent<SpriteRenderer>().bounds.size.x;
        }
        float pos = bgWidth + lastObjectPos;
        gObject.transform.position = new Vector3(pos, 0);
    }
}
