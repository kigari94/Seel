using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrapper : MonoBehaviour
{
    public enum Select { Left, Right };
    [SerializeField] Select selection = Select.Left;

    private float worldWidth = 0;

    private bool triggered = false;
    private Collider2D edgeCollider;

    void Start()
    {
        GameObject sceneCamObj = GameObject.Find("SceneCamera");
        Camera cam = sceneCamObj.GetComponent<Camera>();
        float aspect = (float)cam.pixelRect.width / cam.pixelRect.height;
        float worldHeight = cam.orthographicSize * 2;
        worldWidth = worldHeight * aspect;
        edgeCollider = GetComponent<Collider2D>();
    }

    void FixedUpdate() {
        if (triggered) {
            Debug.Log("Triggered");
            triggered = false;
            edgeCollider.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameObject ball = GameObject.FindWithTag("Ball");
            int translation = (selection == Select.Left) ? 25 : -25;
            edgeCollider.enabled = false;
            ball.transform.Translate(translation, 0, 0);
            triggered = true;
        }
    }
}
