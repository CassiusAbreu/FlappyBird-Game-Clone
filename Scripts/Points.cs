using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    private Bird _bird;
    private void Start()
    {
        _bird = GameObject.Find("Bird").GetComponent<Bird>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        _bird.AddPoints();
    }
}
