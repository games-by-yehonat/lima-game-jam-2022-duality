using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : EntityMovement
{
    
    internal override void DetectNewPosition()
    {
        RaycastHit2D ray;
        ray = Physics2D.Raycast(transform.position, direction);
        if (ray.collider == null)
        {
            return;
        }
        if (ray.collider.tag == "Ball")
        {
            ray = Physics2D.Raycast(ray.transform.position, direction);
            if (ray.collider == null)
            {
                return;
            }
        }
        CalculateNewPosition(ray);

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
                    m_isHole = true;
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
