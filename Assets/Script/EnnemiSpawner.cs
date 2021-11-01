using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSpawner : MonoBehaviour
{
    private float timer;
    public float Pause;
    [SerializeField]
    private GameObject prefab;

    public void Update()
    {
        timer += Time.deltaTime;
        if (Pause == 1)
            Pause = 2;
        if (timer > Pause)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            Pause = Pause - 0.5f;
            timer = 0;
        }
    }
}
