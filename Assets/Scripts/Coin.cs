using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
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
        if (playerController.magnet == true)
        {

            distance = Vector3.Distance(transform.position, playerBox.position);

            if (distance <= 10)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerBox.position, Time.deltaTime * 20.0f);
            }
        }
    }
}
