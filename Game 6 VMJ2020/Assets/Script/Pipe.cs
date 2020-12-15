using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float Speed;
    public float MaxYpos, MinYpos;

    void Start()
    {
        transform.position = new Vector3(transform.localPosition.x, Random.Range(MinYpos, MaxYpos), transform.localPosition.z);
    }

    void Update()
    {
        transform.position = new Vector3(transform.localPosition.x - Speed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);

        if (transform.localPosition.x <= -11)
        {
            Destroy(gameObject);
        }
    }
}
