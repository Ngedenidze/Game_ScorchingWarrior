using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attackRange = 0.5f;
    public int playerDamage = 20;
    public int playerHitPoints = 100;
    public float attackRate = 2f;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeBtwAttack)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                AttackMove();

                timeBtwAttack = Time.time + 1f / attackRate;
;            }



            
        }
        else if (timeBtwAttack > 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void AttackMove()
    {

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

        foreach(Collider2D enemy in enemiesToDamage)
        {
            Debug.Log("Hit!");
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
