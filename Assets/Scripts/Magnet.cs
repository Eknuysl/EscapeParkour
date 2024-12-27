using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    PlayerController playerController;
    Transform playerBox;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerBox = GameObject.Find("Player/Cube").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.transform.tag == "Magnet")
        {
            Destroy(other.gameObject);

            playerController.magnet = true;

            Invoke("goNormal", 10);

        }

    }
    void goNormal()
    {
        playerController.magnet = false;
    }


}
