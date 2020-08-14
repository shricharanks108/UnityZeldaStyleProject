using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D myRigidBody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                anim.SetFloat("moveX", -(transform.position.x - target.position.x));
                anim.SetFloat("moveY", -(transform.position.y - target.position.y));
                myRigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }

    //private void SetAnimFloat(Vector2 setVector)
    //{
    //    anim.SetFloat("moveX", setVector.x);
    //    anim.SetFloat("moveY", setVector.y);
    //}

    //private void changeAnim(Vector2 direction)
    //{
    //    direction = direction.normalized;
    //    anim.SetFloat("moveX", direction.x);
    //    anim.SetFloat("moveY", direction.y);
    //}

    private void ChangeState (EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
