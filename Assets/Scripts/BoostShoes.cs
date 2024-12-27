using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BoostShoes : MonoBehaviour
{
    private float timer = 0;
    public int DelayAmount = 1;
    public float a = 0;
    // Start is called before the first frame update

    private void Update()
    {
        timer += Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)

    {
        if (other.transform.tag == "Shoes")
        {
            Destroy(other.gameObject);

            PlayerController playerController=GameObject.FindWithTag("Player").GetComponent<PlayerController>();

             playerController._jumpForce= playerController._jumpForce * 1.12f;

            Invoke("standardJump", 10);            

        }

    }


    void standardJump()
    {
        PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController._jumpForce = playerController._jumpForce / 1.12f;
    }
}
