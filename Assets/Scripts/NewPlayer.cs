using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : EntityMovement
{

    internal override void Update()
    {
        if (isReady)
        {
            // Vector2 direction;

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
                if(!ray.collider.GetComponent<EntityMovement>()){
                    Move();
                }
            }


            // else if(ray.collider.CompareTag("Wall")){

            // }


        }

        base.Update();
    }

    void Move()
    {
        isReady = false;
        currentSpeed = 0;
        Vector3 dir = direction;
        newPosition = transform.position + dir;
    }

    internal override void OnCollisionEnter2D(Collision2D other)
    {

    }
}
