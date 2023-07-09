using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : InteractionAbstract

{
    public Weapon weapon;
    public float moveSpeed = 5f;
    private GameObject playerObject;
    Vector2 playerPosition;
    public Rigidbody2D rb;
    NavMeshAgent agent;
    private float fireCooldown = 0.1f;
    private float lastFireTime = 0f;
    private bool active = true;
    public int minDistance;
    public int fixedDistance;
    public float speed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameManager.Instance.playerObject;
        StartCoroutine(GetAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerObject.transform.position;

        if (Time.time >= lastFireTime + fireCooldown)
        {
            weapon.Fire();
            lastFireTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        Vector2 aimDirection = playerPosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
        if (Vector2.Distance(transform.position, playerObject.transform.position) <= minDistance)
        {
            Vector2 direction = transform.position - playerObject.transform.position;
            //transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position + direction.normalized * fixedDistance, speed * Time.deltaTime);
            agent.SetDestination(direction);
        }

    }
    
    public override void Interact()
    {
        GameManager.Instance.AddScore(1);
        GameManager.Instance.HealPlayer(10);
        Destroy(gameObject);
    }

    

    public IEnumerator GetAttackCooldown()
        {
            while (active)
            {
                yield return new WaitForSeconds(0.5f);
                fireCooldown = GameManager.Instance.FireCooldown;
            }
        }
    public override void Interact2()
    {

    }
}
