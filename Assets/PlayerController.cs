using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Weapon weapon;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 moveDirection;
    Vector2 mousePosition;
    private float fireCooldown = 0.1f;
    private float lastFireTime = 0f;
    private bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetAttackCoolDown());
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0) && Time.time >= lastFireTime + fireCooldown)
        {
            weapon.Fire();
            lastFireTime = Time.time;
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed * Time.deltaTime, moveDirection.y * moveSpeed * Time.deltaTime);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
    public IEnumerator GetAttackCoolDown()
    {
        while (active)
        {
            yield return new WaitForSeconds(.5f);
            fireCooldown = GameManager.Instance.FireCooldown;
        }
    }
}
