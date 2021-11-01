using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCliff : MonoBehaviour
{
    private Animator animateur;
    private Rigidbody2D rb;

    private void Awake()
    {
        animateur = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector2.left);
    }
}
