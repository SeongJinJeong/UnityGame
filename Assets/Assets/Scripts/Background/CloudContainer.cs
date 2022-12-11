using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudContainer : MonoBehaviour
{
    List<GameObject> clouds = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<transform.childCount; i++)
        {
            clouds.Add(transform.GetChild(i).gameObject); 
        }

        StartCoroutine(SpawnCloud());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCloud()
    {
        while (true)
        {
            bool isSpawn = false;
            for (int i = 0; i < clouds.Count; i++)
            {
                if (clouds[i].activeInHierarchy == false)
                {
                    clouds[i].SetActive(true);
                    isSpawn = true;
                    yield return new WaitForSeconds(3.0f);
                }
            }

            if(isSpawn == false)
            {
                int randomIndex = (int)Mathf.Floor(Random.value * 2);
                GameObject cloudsPrefab = Resources.Load("Prefabs/Landscape/Background/Clouds/Cloud_" + randomIndex) as GameObject;
                Instantiate(cloudsPrefab);
                cloudsPrefab.transform.SetParent(transform);
                cloudsPrefab.SetActive(true);
                yield return new WaitForSeconds(3.0f);
            }
        }
    }
}
