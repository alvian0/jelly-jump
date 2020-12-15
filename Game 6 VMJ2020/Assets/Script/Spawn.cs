using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Pipe;

    public float SpawnInterval = 1;

    float SpawnRate;

    void Start()
    {
        SpawnRate = SpawnInterval;
    }

    void Update()
    {
        if (SpawnRate <= 0)
        {
            Instantiate(Pipe, transform.localPosition, Quaternion.identity);
            SpawnRate = SpawnInterval;
        }

        else
        {
            SpawnRate -= Time.deltaTime;
        }
    }
}
