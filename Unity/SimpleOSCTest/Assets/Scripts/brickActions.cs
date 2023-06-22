using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickActions : MonoBehaviour
{
    
    public bool once = true;
    private ParticleSystem collisionParticleSystem;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;

    
    private void Start()
    {
        collisionParticleSystem = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" && once)
        {
            var emission = collisionParticleSystem.emission;
            var duration = collisionParticleSystem.duration;

            emission.enabled = true;
            collisionParticleSystem.Play();

            once = false;

            sprite.enabled = false;
            collider.enabled = false;

            Invoke(nameof(DestroyObject), duration);
            
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
