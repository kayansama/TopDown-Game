using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : InteractionAbstract
{
    NavMeshAgent agent;
    GameObject playerGameObject;
    public override void Interact()
    {
        GameManager.Instance.AddScore(1);
        Destroy(gameObject);
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

    public override void Interact2()
    {
        
    }
}
