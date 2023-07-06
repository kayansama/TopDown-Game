using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Firepoint;
    public float fireforce = 20f;
    public void Fire()
    {
        GameObject bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(Firepoint.up * fireforce, ForceMode2D.Impulse);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
