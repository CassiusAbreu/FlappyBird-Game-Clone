using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pipe;
    public float maxTime;
    private float timer;
    public static List<GameObject> pipes = new List<GameObject>();
    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    // Update is called once per frame
    void Update()
    {
        if (Bird.gameOver)
        {
            StopCoroutine(SpawnPipe());
        }
    }
    
    public IEnumerator SpawnPipe()
    {
        GameObject newPipe = Instantiate(pipe);
        pipes.Add(newPipe);
        newPipe.transform.position = transform.position + new Vector3(0,Random.Range(-0.41f, 0.64f),0);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnPipe());
    }
}
