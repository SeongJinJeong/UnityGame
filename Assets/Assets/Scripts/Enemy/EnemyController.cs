using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float Default_Enemy_Activate_Distance = 0f;
    GameObject player;
    List<GameObject> Enemies = new();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        for(int i=0; i<transform.childCount; i++)
        {
            Enemies.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerOnEnemy();
    }

    void checkPlayerOnEnemy()
    {
        float playerXPos = player.transform.position.x;
        Enemies.ForEach(delegate (GameObject enemy)
        {
            float xPos = enemy.transform.position.x;
            float distance = Mathf.Abs(playerXPos - xPos);
            if(distance <= Default_Enemy_Activate_Distance + 0.01)
            {
                enemy.SetActive(true);
            }
        });
    }
}
