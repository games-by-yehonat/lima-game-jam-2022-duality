using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : EntityMovement
{
<<<<<<< HEAD

    

=======
    
>>>>>>> 9d6808c1ea6211ec103e2bc53cf0bb5fd7ab83bc
    internal override void DetectNewPosition()
    {
        // RaycastHit2D ray;
        // ray = Physics2D.Raycast(transform.position, direction);
        // if (ray.collider == null)
        // {
        //     return;
        // }
        // if (ray.collider.tag == "Ball")
        // {
        //     ray = Physics2D.Raycast(ray.transform.position, direction);
        //     if (ray.collider == null)
        //     {
        //         return;
        //     }
        // }
        if (CanMove(direction))
        {
            CalculateNewPosition(ray);

        }

    }

    public override bool CanMove(Vector2 _dir)
    {
        // RaycastHit2D ray;
        direction = _dir;
        ray = Physics2D.Raycast(transform.position, direction);
        if (ray.collider == null)
        {   
            Debug.Log("no - coll");
            return false;
        }
        if (ray.collider.tag == "Ball")
        {
            ray = Physics2D.Raycast(ray.transform.position, direction);
            if (ray.collider == null)
            {   
                Debug.Log("no - second ball");
                return false;
            }
        }
        Debug.Log("yes");
        return base.CanMove(direction);
    }

    private void CalculateNewPosition(RaycastHit2D other)
    {

        switch (other.transform.tag)
        {
            case "Hole":
                {
                    newPosition = other.point + (direction / 2);
                    isReady = false;
                    GetComponent<Collider2D>().isTrigger = true;
                    other.collider.enabled = false;
                    transform.parent = null;
                    break;
                }
            default:
                {
                    newPosition = other.point - (direction / 2);
                    break;
                }
        }

    }
}
