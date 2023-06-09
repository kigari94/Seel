using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float extraSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float gravity = 1.0f;
    [SerializeField] private float maxScore = 10;
    
    private float hitCounter = 0;
    static int scorePlayerOne = 0;
    static int scorePlayerTwo = 0;

    private AudioSource source;

    List<string> lastHit = new List<string>();

    private Vector2 direction;
    private Rigidbody2D rigidBody;
    public TextMeshProUGUI scoreTxtPlayerOne;
    public TextMeshProUGUI scoreTxtPlayerTwo;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        direction = CreateVector2ByDegree(45);
    }

    void FixedUpdate() 
    {
        //SwitchGravity();
        Vector2 movement = direction * startSpeed;
        rigidBody.velocity = movement;
    }

    private Vector2 CreateVector2ByDegree(float degrees)
    {
        var angle = degrees * Mathf.Deg2Rad;
        var x = Mathf.Cos(angle);
        var y = Mathf.Sin(angle);

        return new Vector2(x, y);
    }

    private void SwitchGravity()
    {
        if (transform.position.y > 0)
        {
            rigidBody.gravityScale = 0.5f + (gravity * transform.position.y) * 0.3f;
        }
        else
        {
            rigidBody.gravityScale = -0.5f + (-gravity * -transform.position.y) * 0.3f;
        }
    }

    public void BallSpeed()
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
            BallSpeed();
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
            BallSpeed();
            //Debug.Log("Last hit: " + lastHit.First() + "Current hit: " + wall);
        }

        lastHit.RemoveAt(0);
    }

    public void UpdateScore(string player, int score)
    {
        if(player == "PlayerOne")
        {
            if(scorePlayerOne >= maxScore)
            {
                SceneManager.LoadScene(3);
            }
            scorePlayerOne += score;
            scoreTxtPlayerOne.text = "Score: " + scorePlayerOne.ToString("0000");
        }
        else
        {
            if(scorePlayerTwo >= maxScore)
            {
                SceneManager.LoadScene(3);
            }
            scorePlayerTwo += score;
            scoreTxtPlayerTwo.text = "Score: " + scorePlayerTwo.ToString("0000");
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static int[] getScores() {
        int[] scores = new int[2];
        scores[0] = scorePlayerOne;
        scores[1] = scorePlayerTwo;
        return scores;
    }

    public static void resetScores() {
        scorePlayerOne = 0;
        scorePlayerTwo = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        Vector2 reflection = Vector2.Reflect(direction, normal);
        direction = reflection;
        string collisionObject = collision.gameObject.tag;
        
        //string lastHit;
        //Debug.Log(collisionObject);

        source.Play();

        switch (collisionObject)
        {
            case "Player":
                IncreaseHitCounter();
                break;
            case "BrickTopOne":
                UpdateScore("PlayerOne", 5);
                DecreaseHitCounter("top");
                lastHit.Add("top");
                break;
            case "BrickBottomOne":
                UpdateScore("PlayerTwo", 5);
                DecreaseHitCounter("bottom");
                lastHit.Add("bottom");
                break;
            case "BrickTopTwo":
                UpdateScore("PlayerOne", 10);
                DecreaseHitCounter("top");
                lastHit.Add("top");
                break;
            case "BrickBottomTwo":
                UpdateScore("PlayerTwo", 10);
                DecreaseHitCounter("bottom");
                lastHit.Add("bottom");
                break;
            case "BrickTopThree":
                UpdateScore("PlayerOne", 15);
                DecreaseHitCounter("top");
                lastHit.Add("top");
                break;
            case "BrickBottomThree":
                UpdateScore("PlayerTwo", 15);
                DecreaseHitCounter("bottom");
                lastHit.Add("bottom");
                break;
            case "BrickTopFour":
                UpdateScore("PlayerOne", 20);
                DecreaseHitCounter("top");
                lastHit.Add("top");
                break;
            case "BrickBottomFour":
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
