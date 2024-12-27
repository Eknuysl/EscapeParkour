using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float range = 3.0f; // Hareket aralığı
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        
    }

    void Update()
    {
        
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time * speed) * range,0,0);
    }

    
}
