using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipes : MonoBehaviour
{

    public float speed = 1f;

    private SpawnManager _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
        
        if(this.gameObject.transform.position.x < -1f)
            Destroy(this.gameObject);
    }
}
