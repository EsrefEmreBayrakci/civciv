
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.Cinemachine;

public class CatController : MonoBehaviour
{
    [Header("References")]
    public catStateController stateController;
    public Transform player;
    public playerContrroller playerFloor;
    public NavMeshAgent agent;
    private Animator anim;

    [Header("Visual")]
    public Transform catVisual;
    public float rotationSpeed = 8f;

    [Header("Attack Settings")]
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    private bool canAttack = true;

    [Header("Settings")]
    public float wanderRadius = 8f;
    public Vector2 idleTimeRange = new Vector2(1.5f, 3f);
    public float arriveThreshold = 0.5f;

    [Header("Speeds")]
    public float walkSpeed = 1.5f;
    public float runSpeed = 3.5f;

    private Vector3 homePos;
    private bool isIdling;

    private Vector3 lastPosition;
    private bool freezePosition = false;

    public bool isPaused = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        anim = GetComponentInChildren<Animator>();
        if (!stateController) stateController = GetComponent<catStateController>();

        homePos = transform.position;
    }

    private void Start()
    {
        changeState(catState.Walking);
    }

    private void Update()
    {
        if (freezePosition)
        {
            transform.position = lastPosition;
            return;
        }

        if (isPaused)
        {

            agent.isStopped = true;
            return;
        }

        if (playerFloor != null)
        {
            if (playerFloor.IsOnFloor || playerFloor.zipladiMi == false)
            {

                float dist = Vector3.Distance(transform.position, player.position);
                if (dist <= attackRange && canAttack)
                {
                    changeState(catState.Attacking);
                }
                else
                {
                    if (stateController.getCurrentState() != catState.Attacking)
                        changeState(catState.Running);
                }
            }
            else
            {

                if (stateController.getCurrentState() == catState.Running || stateController.getCurrentState() == catState.Attacking)
                {
                    changeState(catState.Walking);
                }
            }
        }
        else if (stateController.getCurrentState() == catState.Running || stateController.getCurrentState() == catState.Attacking)
        {

            changeState(catState.Walking);
        }

        // State Machine
        switch (stateController.getCurrentState())
        {
            case catState.Idle:
                if (!isIdling) StartCoroutine(IdleRoutine());
                break;

            case catState.Walking:
                agent.speed = walkSpeed;
                handleWander();
                break;

            case catState.Running:
                agent.speed = runSpeed;
                chasePlayer();
                break;

            case catState.Attacking:
                agent.ResetPath();
                HandleAttack();
                break;
        }

        HandleVisualRotation();
    }

    void HandleVisualRotation()
    {
        if (catVisual == null) return;

        Vector3 velocity = agent.velocity;
        velocity.y = 0f;

        if (velocity.sqrMagnitude > 0.01f)
        {


            Quaternion targetRot = Quaternion.LookRotation(velocity, Vector3.up) * Quaternion.Euler(0, 90, 0);

            catVisual.rotation = Quaternion.Slerp(catVisual.rotation, targetRot, Time.deltaTime * rotationSpeed);
        }
    }


    void handleWander()
    {
        if (!agent.hasPath || agent.remainingDistance < arriveThreshold)
        {
            changeState(catState.Idle);
        }
    }

    IEnumerator IdleRoutine()
    {
        isIdling = true;
        agent.ResetPath();

        float wait = Random.Range(idleTimeRange.x, idleTimeRange.y);
        yield return new WaitForSeconds(wait);

        pickNewDestination();
        changeState(catState.Walking);

        isIdling = false;
    }

    void pickNewDestination()
    {
        Vector3 rand = Random.insideUnitSphere * wanderRadius;
        rand.y = 0f;
        Vector3 target = homePos + rand;

        if (NavMesh.SamplePosition(target, out NavMeshHit hit, 2f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    void chasePlayer()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    void HandleAttack()
    {
        if (!canAttack) return;
        changeState(catState.Attacking);

        HealthManager.Instance.FullDamage();
        AudioManager.Instance.Play(SoundType.CatSound);

        CameraShakeController.Instance.Shake(new Vector3(-1f, -1f, 0f), 3f, 2f, CinemachineImpulseDefinition.ImpulseShapes.Rumble);


        lastPosition = transform.position;
        freezePosition = true;

    }



    public void changeState(catState newState)
    {
        stateController.changeState(newState);
    }
}

