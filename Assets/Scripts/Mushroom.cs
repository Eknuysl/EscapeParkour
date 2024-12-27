using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mushroom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.transform.tag == "Mushroom")
        {
            Destroy(other.gameObject);

            PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

            playerController._runningSpeed = playerController._runningSpeed * 1.05f;


        }

    }
}
