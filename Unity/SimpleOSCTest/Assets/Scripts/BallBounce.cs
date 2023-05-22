//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallBounce : MonoBehaviour
//{
//    [SerializeField] public BallMovement ballMovement;

//    private void Bounce(Collision2D collision)
//    {
//        Vector2 ballPosition = transform.position;
//        Vector2 racketPosition = collision.transform.position;
//        float racketHeight = collision.collider.bounds.size.y;
//        float positionY;

//        if (collision.gameObject.name == "Player")
//        {
//            positionY = 1;
//        } 
        
//        else

//        {
//            positionY = -1;
//        }

//        float positionX = (ballPosition.x - racketPosition.x) / racketHeight;

//        //if(collision.gameObject.name == "Brick")
//        //{
//        //    ballMovement.DecreaseHitCounter();
//        //}

//        ballMovement.IncreaseHitCounter();
//        ballMovement.MoveBall(new Vector2(positionX, positionY));
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if(collision.gameObject.name == "Player")
//        {
//            Bounce(collision);
//        }
//    }
//}
