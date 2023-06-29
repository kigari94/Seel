using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private int player;
    [SerializeField] private bool tracking = false;
    private float y = 0;
    private float z = 0;

    void Awake()
    {
        y = transform.position.y;
        z = transform.position.z;
    }

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if(tracking)
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        transform.Translate(kinectValue, 0, 0);
    }
}