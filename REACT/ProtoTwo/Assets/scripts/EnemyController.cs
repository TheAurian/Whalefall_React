using UnityEngine;
using System.Collections;

public class EnemyController : ActorController
{

    public Transform spawnLocation;
    public float attackRate;
    public float turnSpeed;


    Vector3 currentDirection;
    Transform player;
    Vector3 movement; //Vector to store direction of player's movement
    NavMeshAgent navMeshAgent;
    public float speed; //speed that player will move at
    float attackTimer;
    public float attackRange = 5; //range that enemy can attack in
    float hoverDist; //distance that enemy will hover before attacking 


    void Awake()
    {
        //get player character components
        thisRigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();


        //speed = 6f;
        //turnSpeed = 20f;
        bIsDead = false;
        attackTimer = 0;
        currentHealth = initialHealth;
        attackRange = Random.Range(5, 15);

        //position data
        //transform.position = spawnLocation.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;


        //nav data
        navMeshAgent.stoppingDistance = attackRange;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


        float distToPlayer = Vector3.Distance(player.position, this.transform.position);

        if(distToPlayer > attackRange){
            Debug.Log("Not in range");
            anim.SetBool("bIsWalking", true);
            this.Move();
        }else{
            Debug.Log("PLAYER IS IN RANGE TO BE ATTACKED");
            anim.SetBool("bIsWalking", false);

        }

	}

    void FixedUpdate()
    {
        ///check for colision
        ///if colision is player weapon
    }

    void Move(){
        //transform.position = Vector3.Lerp(transform.position, )
        navMeshAgent.SetDestination(player.position);

    }

    void Turn()
    {

    }

}
