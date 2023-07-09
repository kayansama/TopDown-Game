using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionAbstract : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && this.gameObject.CompareTag("Enemy"))
        {
            
            Interact();
        }
        if (this.gameObject.CompareTag("Interactable") && collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Interactable"))
        {
            Interact2();
        }
    }

    public abstract void Interact();
    public abstract void Interact2();
}