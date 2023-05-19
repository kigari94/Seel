using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWrapper : MonoBehaviour
{
    private float worldWidth = 0;
    private float worldHeight = 0;

    void Start()
    {
        Camera cam = GameObject.Find("SceneCamera").GetComponent<Camera>();
        float aspect = (float)cam.pixelRect.width / cam.pixelRect.height;
        worldHeight = cam.orthographicSize * 2;
        worldWidth = worldHeight * aspect;
    }

    void Update()
    {
        if (gameObject.transform.position.x < -worldWidth / 2) // left 
        { 
            Vector3 currentPos = gameObject.transform.position;
            Vector3 newPos = new Vector3((worldWidth / 2) - 0.01f, currentPos.y, currentPos.z);
            gameObject.transform.position = newPos;
        }
        else if (gameObject.transform.position.x > worldWidth / 2) // right
        { 
            Vector3 currentPos = gameObject.transform.position;
            Vector3 newPos = new Vector3((-worldWidth / 2) + 0.01f, currentPos.y, currentPos.z);
            gameObject.transform.position = newPos;
        }
    }
}
