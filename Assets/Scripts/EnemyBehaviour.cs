using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region public cvladebi
    public Rigidbody2D playerTarget;
    public Transform rayCast;
    public Transform playerS;
    public Transform triggerArea;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    #endregion
    Collider2D mCollider;
    Vector3 mPoint;
#region private cvladebi
    private RaycastHit2D hit;
    public GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
#endregion
    
    private void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
        playerTarget = target.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, rayCastMask);
        }
        if (hit.collider != null)
        { 
            
            EnemyLogic();

        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }

    }
    //ras aketebs enemy
    void EnemyLogic()
    {
        // distance = Vector2.Distance(transform.position, target.transform.position);
        // if (distance > attackDistance)
        // {
            Move();
        //     StopAttack();
        // }
        // else if (distance < attackDistance)
        // {
        //     Attack();

        // }

    }


    //dartymis animacia da dartyma
    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    //dartymis gachereba
    void StopAttack()
    {
   
        attackMode = false;
        anim.SetBool("Attack", false);
    }
    //enemys modzraoba
    void Move()
    {
        // anim.SetBool("canWalk", true);
        // if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        // {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D trig)
    { //tushevida player datrigerdes
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
        if (triggerArea.GetComponent<BoxCollider2D>().bounds.Contains(playerS.position))
        {
            print("point is inside collider" + playerS.position);
            inRange = true;
      
        }


    }


}
