using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : EntityMovement
{
    protected Animator m_animator;
    private SpriteRenderer m_renderer;

    protected bool m_rigth = true;

    internal override void Awake()
    {
        m_renderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        
        base.Awake();
    }

    internal override void Update()
    {
        if (isReady)
        {
            // Vector2 direction;
            m_animator.SetBool("horizontal", false);
            m_animator.SetBool("up", false);
            m_animator.SetBool("down", false);

            direction.x = (int)(Input.GetAxisRaw("Horizontal"));
            direction.y = (int)(Input.GetAxisRaw("Vertical"));
            
            if (Mathf.Abs(direction.y) == Mathf.Abs(direction.x))
            {
                direction = Vector2.right * direction;
            }

            // RaycastHit2D ray;
            ray = Physics2D.Raycast(transform.position, direction, 1);
            if (ray.collider == null)
            {
                Move();
            }
            if (ray.collider && !ray.collider.CompareTag("Wall"))
            {
                if (ray.collider.GetComponent<EntityMovement>() && ray.collider.GetComponent<EntityMovement>().CanMove(direction))
                {
                    Move();
                }
                if (!ray.collider.GetComponent<EntityMovement>())
                {
                    Move();
                }
                if (ray.collider.isTrigger)
                    Move();
            }


            // else if(ray.collider.CompareTag("Wall")){

            // }


        }
        else
        {
            // m_rigth = true;
            // m_animator.SetBool("horizontal", false);
        }

        base.Update();
    }

    void Move()
    {
        isReady = false;
        currentSpeed = 0;
        Vector3 dir = direction;
        newPosition = transform.position + dir;
        Debug.Log(dir);
        if ((dir.x > 0))
        {
            if (!m_rigth)
            {
                m_renderer.flipX = false;
                m_rigth = true;
            }
            
            m_animator.SetBool("horizontal", true);
        }
        if ((dir.x < 0))
        {
            if (m_rigth)
            {
                m_renderer.flipX = true;
                m_rigth = false;
            }
            
            m_animator.SetBool("horizontal", true);
        }
        if ((dir.y > 0))
        {
            m_animator.SetBool("up", true);
        }
        if ((dir.y < 0))
        {
            m_animator.SetBool("down", true);
        }
    }

    internal override void OnCollisionEnter2D(Collision2D other)
    {

    }

    public void Teleport(Vector3 _pos)
    {
        transform.position = _pos;
        newPosition = _pos;
    }
}
