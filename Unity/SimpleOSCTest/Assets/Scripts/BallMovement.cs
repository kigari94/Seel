using System.Collections;
using System.Collections.Generic;
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
        if(hitCounter * extraSpeed <= 0)
        {
            hitCounter++;
            BallMove();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionObject = collision.gameObject.name;

        switch (collisionObject)
        {
            case "Player":
                IncreaseHitCounter();
                break;
            // ToDo: Punkte von der Y-Position der Bricks abhängig machen
            case "BrickTopOne":
                Destroy(collision.gameObject);
                // add points
                // decrease Speed if y < 0 (Coroutine) oder State via Setter
                break;
            case "BrickBottomOne":
                Destroy(collision.gameObject);
                break;
            case "BrickTopTwo":
                Destroy(collision.gameObject);
                break;
            case "BrickBottomTwo":
                Destroy(collision.gameObject);
                break;
            case "BrickTopThree":
                Destroy(collision.gameObject);
                break;
            case "BrickBottomThree":
                Destroy(collision.gameObject);
                break;
            case "BrickTopFour":
                Destroy(collision.gameObject);
                break;
            case "BrickBottomFour":
                Destroy(collision.gameObject);
                break;
            case "OuterWallTop":
                scorePlayerOne += 50;
                // end game
                break;
            case "OuterWallBottom":
                scorePlayerTwo += 50;
                // end game
                break;
        }
    }
}
