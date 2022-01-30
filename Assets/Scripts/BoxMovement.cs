using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : EntityMovement
{
    internal override void DetectNewPosition()
    {
        RaycastHit2D ray;
        ray = Physics2D.Raycast(transform.position, direction);
        if (ray.collider == null)
        {   
            // isReady = true;
            return;
        }
        float _distance = Vector2.Distance(transform.position, ray.point);
        if (_distance < 0.6f)
        {   
            // isReady = true;
            return;
        }
        if(ray.collider.tag == "Ball")
        {
            return;
        }
        // isReady = true;
        Vector3 dir = direction;
        newPosition = transform.position + dir;

    }

}
