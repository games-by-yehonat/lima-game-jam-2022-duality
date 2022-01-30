using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : EntityMovement
{
    internal override void DetectNewPosition()
    {
        // isReady = true;

        if (CanMove(direction))
        {
            Vector3 dir = direction;
            newPosition = transform.position + dir;
            if (sound)
            sound.Play();

        }
    }

    public override bool CanMove(Vector2 _dir)
    {
        // RaycastHit2D ray;
        direction = _dir;
        ray = Physics2D.Raycast(transform.position, direction);
        if (ray.collider == null)
        {
            // isReady = true;
            Debug.Log("no -collider");
            return false;
        }
        float _distance = Vector2.Distance(transform.position, ray.point);
        if (_distance < 0.6f)
        {
            // isReady = true;
            Debug.Log("no - distance");
            return false;
        }
        if (ray.collider.tag == "Ball" || ray.collider.tag == "Box")
        {
            Debug.Log("no tag");
            return false;
        }
        Debug.Log("yes");
        return base.CanMove(direction);
    }
    
}
