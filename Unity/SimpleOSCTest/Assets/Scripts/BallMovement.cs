using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float extraSpeed;
    [SerializeField] private float maxSpeed;
    
    private float hitCounter = 0;
    private int scorePlayerOne = 0;
    private int scorePlayerTwo = 0;
    private Rigidbody2D rigidBody;
    public TextMeshProUGUI scoreTxtPlayerOne;
    public TextMeshProUGUI scoreTxtPlayerTwo;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //StartCoroutine(Launch());
    }

    
    public void BallMove()
    {
        float ballSpeedFaster = startSpeed + hitCounter * extraSpeed;
        rigidBody.velocity *= ballSpeedFaster;
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed <= maxSpeed)
        {
            hitCounter++;
            BallMove();
            //Debug.Log(hitCounter);
        }
    }

    public void DecreaseHitCounter()
    {
        if(hitCounter * extraSpeed >= startSpeed)
        {
            hitCounter--;
            BallMove();
        }
    }

    public void UpdateScore(string player, int score)
    {
        if(player == "PlayerOne")
        {
            scorePlayerOne += score;
            scoreTxtPlayerOne.text = scorePlayerOne.ToString("0000");
        }
        else
        {
            scorePlayerTwo += score;
            scoreTxtPlayerTwo.text = scorePlayerTwo.ToString("0000");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionObject = collision.gameObject.tag;
        Debug.Log(collisionObject);

        switch (collisionObject)
        {
            case "Player":
                IncreaseHitCounter();
                break;
            case "BrickTopOne":
                Destroy(collision.gameObject);
                UpdateScore("PlayerOne", 5);
                // decrease Speed if y < 0 (Coroutine) oder State via Setter
                break;
            case "BrickBottomOne":
                Destroy(collision.gameObject);
                UpdateScore("PlayerTwo", 5);
                break;
            case "BrickTopTwo":
                Destroy(collision.gameObject);
                UpdateScore("PlayerOne", 10);
                break;
            case "BrickBottomTwo":
                Destroy(collision.gameObject);
                UpdateScore("PlayerTwo", 10);
                break;
            case "BrickTopThree":
                Destroy(collision.gameObject);
                UpdateScore("PlayerOne", 15);
                break;
            case "BrickBottomThree":
                Destroy(collision.gameObject);
                UpdateScore("PlayerTwo", 15);
                break;
            case "BrickTopFour":
                Destroy(collision.gameObject);
                UpdateScore("PlayerOne", 20);
                break;
            case "BrickBottomFour":
                Destroy(collision.gameObject);
                UpdateScore("PlayerTwo", 20);
                break;
            case "OuterWallTop":
                UpdateScore("PlayerOne", 50);
                // end game
                break;
            case "OuterWallBottom":
                UpdateScore("PlayerTwo", 50);
                // end game
                break;
        }
    }
}
