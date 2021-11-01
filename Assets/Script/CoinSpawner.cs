using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    
    private float timer;
    public float Pause;
    [SerializeField]
    private GameObject prefab;

    public void Update()
    {

        timer += Time.deltaTime;

        if (timer > Pause)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            Pause = Pause * 2;
            timer = 0;
        }
    }
}
