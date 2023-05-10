using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float extraSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Vector2 direction;

    private float hitCounter = 0;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(1);
        MoveBall(direction);
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeedFaster = startSpeed + hitCounter * extraSpeed;

        rigidBody.velocity = direction * ballSpeedFaster;
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed <= 0)
        {
            hitCounter++;
        }
    }

    public void DecreaseHitCounter()
    {
        if(hitCounter * extraSpeed >= startSpeed)
        {
            hitCounter--;
        }
    }
}
