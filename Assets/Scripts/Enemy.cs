using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform target;
    public Vector3 size = new Vector3(100, 1, 100);
    
    private NavMeshAgent navMeshAgent;
    private bool isFollowing = false;
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(Wander), 0, Random.Range(1, 3));
    }

    void Update()
    {
        if (target == null) return;
        
        if(Vector3.Distance(transform.position, target.position) < 30)
        {
            isFollowing = true;
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            isFollowing = false;
        }
        
        animator.SetFloat("speed", navMeshAgent.velocity.magnitude);
    }

    void Wander()
    {
        if (isFollowing) return;
        var randomPosition = new Vector3(Random.Range(-size.x, size.x),100, Random.Range(-size.z, size.z));
        //find earth position
        if(Physics.Raycast(randomPosition, Vector3.down, out var hit, 200))
        {
            randomPosition = hit.point;
        }
        navMeshAgent.SetDestination(randomPosition);
    }
}
