using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Game Over: " + collision.gameObject.name);


    }


}
