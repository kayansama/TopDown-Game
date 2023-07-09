using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Color color;
    public SpriteRenderer sprite;
    public float hp = 100;
    private bool calledLostGame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        { if (calledLostGame == false)
            {
                GameManager.Instance.LostGame();
                calledLostGame = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            GameManager.Instance.TakeDamage(sprite, color);
            ReduceHP(10);
        }if (collision.gameObject.CompareTag("Enemy Bullet") )
        {
            GameManager.Instance.TakeDamage(sprite, color);
            ReduceHP(30);
        }
        
    }
    private void ReduceHP(int hpToReduce)
    {
        hp -= hpToReduce;
    }
    public void IncreaseHP(float hpToIncease)
    {
        if (hp < 100)
        {
            hp += hpToIncease;
        }
        if (hp >= 100)
        {
            hp = 100;
        }
    }
}
