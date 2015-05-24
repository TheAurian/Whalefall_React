using UnityEngine;
using System.Collections;

public class EnemyController : ActorController
{

    public Transform spawnLocation;
    public float attackRate;

    Vector3 currentDirection;
    public Transform player;
    Vector3 movement; //Vector to store direction of player's movement
    NavMeshAgent navMeshAgent;
    public float speed; //speed that player will move at
    float turnSpeed;
    float attackTimer;
    public float attackRange = 10; //range that enemy can attack in
    float hoverDist; //distance that enemy will hover before attacking 


    void Awake()
    {
        //get player character components
        thisRigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();


        //speed = 6f;
        turnSpeed = 20f;
        bIsDead = false;
        attackTimer = 0;
        currentHealth = initialHealth;

        //position data
        transform.position = spawnLocation.position;


        //nav data
        navMeshAgent.stoppingDistance = 5;
    }

	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {


        float distToPlayer = Vector3.Distance(player.position, this.transform.position);

        if(distToPlayer > attackRange){
            Debug.Log("Not in range");
            this.Move();
        }else{
            Debug.Log("PLAYER IS IN RANGE TO BE ATTACKED");
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
