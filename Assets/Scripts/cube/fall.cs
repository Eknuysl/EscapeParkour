using UnityEngine;
using UnityEngine.UIElements;

public class FallingObstacle : MonoBehaviour
{
    public float fallSpeed = 5.0f; // Düşüş hızı
    public float range = 3.0f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
  
    transform.position = initialPosition + new Vector3(0, Mathf.Sin(Time.time * fallSpeed) * range, 0);

    }


    


}
