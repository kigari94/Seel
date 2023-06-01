using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float extraSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float gravity = 1.0f;
    
    private float hitCounter = 0;
    private int scorePlayerOne = 0;
    private int scorePlayerTwo = 0;

    List<string> lastHit = new List<string>();

    private Rigidbody2D rigidBody;
    public TextMeshProUGUI scoreTxtPlayerOne;
    public TextMeshProUGUI scoreTxtPlayerTwo;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (transform.position.y > 0) {
            rigidBody.gravityScale = 0.5f + (gravity * transform.position.y) * 0.3f;
        } else {
            rigidBody.gravityScale = -0.5f + (-gravity * -transform.position.y) * 0.3f;
        }
    }

    public void BallMove()
    {
        float ballSpeedFaster = startSpeed + hitCounter * extraSpeed;
        rigidBody.velocity *= ballSpeedFaster;
        //Debug.Log("Velocity: " + rigidBody.velocity);
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

    public void DecreaseHitCounter(string wall)
    {
        if(lastHit.Count == 0)
        {
            return;
        }

        if(hitCounter * extraSpeed >= startSpeed && lastHit.First() != wall)
        {
            hitCounter--;
            BallMove();
            //Debug.Log("Last hit: " + lastHit.First() + "Current hit: " + wall);
        }

        lastHit.RemoveAt(0);
    }

    public void UpdateScore(string player, int score)
    {
        if(player == "PlayerOne")
        {
            scorePlayerOne += score;
            scoreTxtPlayerOne.text = "Score: " + scorePlayerOne.ToString("0000");
        }
        else
        {
            scorePlayerTwo += score;
            scoreTxtPlayerTwo.text = "Score: " + scorePlayerTwo.ToString("0000");
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionObject = collision.gameObject.tag;
        
        //string lastHit;
        //Debug.Log(collisionObject);

        switch (collisionObject)
        {
            case "Player":
                IncreaseHitCounter();
                break;
            case "BrickTopOne":
                Destroy(collision.gameObject);
                UpdateScore("PlayerOne", 5);
                DecreaseHitCounter("top");
                lastHit.Add("top");
                break;
            case "BrickBottomOne":
                Destroy(collision.gameObject);
                UpdateScore("PlayerTwo", 5);
                DecreaseHitCounter("bottom");
                lastHit.Add("bottom");
                break;
            case "BrickTopTwo":
                Destroy(collision.gameObject);
                UpdateScore("PlayerOne", 10);
                DecreaseHitCounter("top");
                lastHit.Add("top");
                break;
            case "BrickBottomTwo":
                Destroy(collision.gameObject);
                UpdateScore("PlayerTwo", 10);
                DecreaseHitCounter("bottom");
                lastHit.Add("bottom");
                break;
            case "BrickTopThree":
                Destroy(collision.gameObject);
                UpdateScore("PlayerOne", 15);
                DecreaseHitCounter("top");
                lastHit.Add("top");
                break;
            case "BrickBottomThree":
                Destroy(collision.gameObject);
                UpdateScore("PlayerTwo", 15);
                DecreaseHitCounter("bottom");
                lastHit.Add("bottom");
                break;
            case "BrickTopFour":
                Destroy(collision.gameObject);
                UpdateScore("PlayerOne", 20);
                DecreaseHitCounter("top");
                lastHit.Add("top");
                break;
            case "BrickBottomFour":
                Destroy(collision.gameObject);
                UpdateScore("PlayerTwo", 20);
                DecreaseHitCounter("bottom");
                lastHit.Add("bottom");
                break;
            case "OuterWallTop":
                UpdateScore("PlayerOne", 50);
                //PauseGame();
                // end game
                break;
            case "OuterWallBottom":
                UpdateScore("PlayerTwo", 50);
                //PauseGame();
                // end game
                break;
        }
    }
}
