using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickActions : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public bool once = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" && once)
        {
            var emission = collisionParticleSystem.emission;
            var duration = collisionParticleSystem.duration;

            emission.enabled = true;
            collisionParticleSystem.Play();

            once = false;
            Invoke(nameof(DestroyObject), duration);
            
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
