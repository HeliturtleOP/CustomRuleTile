using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [Range(0,100)]
    public float speed = 50, attack = 50, dexterity = 50, health = 50;

    public GameObject projectile;

    private SpriteRenderer sprite;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float hor = Input.GetAxisRaw("Horizontal")*1f, vert = Input.GetAxisRaw("Vertical")*1f;

        Vector3 dir = new Vector3(hor, 0, vert);

        

        dir = dir.normalized;

        Animate(dir);

        transform.Translate(dir * (speed/20) * Time.deltaTime);

        
    }

    void Attack()
    {

        GameObject fresh = Instantiate(projectile, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity, transform);

        if (sprite.flipX == true)
        {
            fresh.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (sprite.flipX == false)
        {
            fresh.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

    }

    void Animate(Vector3 Movement)
    {

        if (Movement.x > 0)
        {
            sprite.flipX = false;
        }else if (Movement.x < 0)
        {
            sprite.flipX = true;
        }

        if (Movement.magnitude > 0.01f)
        {
            animator.SetBool("Running", true);
            animator.SetFloat("Attack_Blend", 1);
        }else
        {
            animator.SetBool("Running", false);
            animator.SetFloat("Attack_Blend", 0);
        }


        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Hit");
        }

    }


}
