using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    GameObject CoinPoolObject;
    // Start is called before the first frame update
    void Start()
    {
        CoinPoolObject = transform.Find("CoinObjectPool").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnCoinObject (GameObject coin)
    {
        if (coin.activeSelf == true)
            coin.SetActive(false);

        coin.transform.SetParent(CoinPoolObject.transform);
    }
}
