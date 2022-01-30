using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : EntityMovement
{

    public float speed = 0;


    void Update()
    {
        speed += Time.deltaTime;
    }

    void LateUpdate()
    {
        if (newPosition != Vector2.zero)
            transform.position = Vector3.Lerp(transform.position, newPosition, speed);
    }

    internal override void DetectNewPosition()
    {
        RaycastHit2D ray;
        ray = Physics2D.Raycast(transform.position, new Vector2(x, y));
        if (ray.collider == null)
        {
            return;
        }
        CalculateNewPosition(ray);

    }

    private void CalculateNewPosition(RaycastHit2D other)
    {
        speed = 0;
        switch (other.transform.tag)
        {
            case "Hole":
                {
                    newPosition = other.point + (new Vector2(x, y) / 2);
                    isActive = false;
                    break;
                }
            default:
                {
                    newPosition = other.point - (new Vector2(x, y) / 2);
                    break;
                }
        }

    }
}
