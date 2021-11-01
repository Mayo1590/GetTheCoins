using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{
    private float timer;
    private float pause = 2f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > pause)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
}
