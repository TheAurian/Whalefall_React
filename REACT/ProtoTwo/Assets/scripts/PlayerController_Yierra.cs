using UnityEngine;
using System.Collections;

public class PlayerController_Yierra : ActorController {

    public Transform spawnLocation;
    public float attackRate;

    Vector3 currentDirection;
    Vector3 movement; //Vector to store direction of player's movement
    public float speed; //speed that player will move at
    float turnSpeed;
    float attackTimer;
    InputController input;
    CapsuleCollider weapon;
    public float circumRangeToToroa;
    int killableMask;
    NavMeshAgent navMeshAgent;

    //player_toroa data
    GameObject player;

    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.

    float timer;

    void Awake()
    {
        //get player character components
        thisRigidBody = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        //input = GetComponent<InputController>();
        //weapon = spear.GetComponent<CapsuleCollider>();

        //speed = 6f;
        turnSpeed = 20f;
        bIsDead = false;
        attackTimer = 0;
        killableMask = LayerMask.GetMask("Killable");

        //get player data
        player = GameObject.FindGameObjectWithTag("Player");

        //get navmesh data
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

	// Use this for initialization
	void Start () {

        Transform transform = GetComponent<Transform>();
        transform.position = spawnLocation.position;
	}


	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        float distToPlayer = Vector3.Distance(player.transform.position, this.transform.position);

        //if (distToPlayer > circumRangeToToroa)
        //{
        //    Debug.Log("Not in range ===============     " + distToPlayer);
        //    //anim.SetBool("bIsWalking", true);
        //    this.Move();
        //}else
        //{
        //    //navMeshAgent.Stop();
        //    Debug.Log("YIERRA IS IN POSITION");
        //    //anim.SetBool("bIsWalking", false);
        //}

        this.Move();

	}

    void FixedUpdate()
    {

        //player attacks with a rate
        attackTimer += Time.deltaTime;

        //if get input for shooting, shoot
        //if (input.GetSweep_R() && attackTimer >= attackRate)
        //{
        //    Debug.Log("Toroa sweeping right!");
        //    anim.SetTrigger("tSweepRight");
        //    attackTimer = 0;

        //}


    }

    void LateUpdate()
    {
    }

    void Move()
    {
        //set movement vector based on input axis
        //movement.Set(h, 0f, v);

        //movement = movement.normalized * speed * Time.deltaTime;

        ////add movment vector to current position
        //thisRigidBody.MovePosition(transform.position + movement);
        if (navMeshAgent.hasPath)
        {
            navMeshAgent.Resume();
        }

        Vector3 navPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - circumRangeToToroa ); 

        navMeshAgent.SetDestination(navPos);

    }

    //TODO: use coroutine to finish rotation?
    void Turn(float h, float v)
    {

    }

    void Shoot()
    {
        Debug.Log("Toroa has attacked!");
    }
}
