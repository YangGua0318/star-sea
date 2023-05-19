using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float time;
    public float startTime;
    
    private Animator anim;
    private PolygonCollider2D collider2D;
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
        {
            if(Input.GetButtonDown("Attack"))
            {
                anim.SetTrigger("Attack");
                StartCoroutine(StartAttack());
            }
        }
        IEnumerator StartAttack()
        {
            yield return new WaitForSeconds(startTime);
            GetComponent<Collider2D>().enabled = true;
            StartCoroutine(disableHitBox());
        }

        IEnumerator disableHitBox()
        {
            yield return new WaitForSeconds(time);
            GetComponent<Collider2D>().enabled = false;
        }
}
