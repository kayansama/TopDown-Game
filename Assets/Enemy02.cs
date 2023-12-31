using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy02 : InteractionAbstract
{
    public Color color;
    public SpriteRenderer sprite;
    NavMeshAgent agent;
    GameObject playerGameObject;
    public float rotationSpeed = 100f;
    private int hp = 100;
    public GameObject explosionParticle;
    public override void Interact()
    {
        if (hp <= 0)
        {
            Vector3 Position = transform.position;
            explosionParticle.gameObject.SetActive(true);
            GameManager.Instance.AddScore(1);
            GameManager.Instance.HealPlayer(10);
            Instantiate(explosionParticle, Position, Quaternion.identity);
            
            Destroy(gameObject); 
        }
        if (hp > 1)
        {
            hp -= 100;
            GameManager.Instance.TakeDamage(sprite, color);
        }
    }
    private void Start()
    {
        playerGameObject = GameManager.Instance.playerObject;

        StartCoroutine(FollowPlayer());
    }
    private IEnumerator FollowPlayer()
    {
        agent.SetDestination(playerGameObject.transform.position);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FollowPlayer());
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    public override void Interact2()
    {

    }
}
