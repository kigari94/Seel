using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
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
    }
}