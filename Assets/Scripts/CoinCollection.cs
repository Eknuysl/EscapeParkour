using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public int DelayAmount = 1;
    private float timer = 0f;
    private int Score = 0;
    PlayerController playerController;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI highScoreText;
    private void Start()
    {
        playerController = GameObject.Find("Magnet").GetComponent<PlayerController>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        coinText.text = "Score: " + Score.ToString();
        if (timer >= DelayAmount)
        {
            timer = 0f;
            Score++;
        }

       
    }
    private void OnTriggerEnter(Collider other)

    {
        if (other.transform.tag =="Coin")
        {
            Score=Score+2;
           
            Destroy(other.gameObject);
        }

    }
    

}
