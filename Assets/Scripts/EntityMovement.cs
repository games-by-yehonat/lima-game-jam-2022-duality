using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EntityMovement : MonoBehaviour
{
    internal bool isActive;
    internal Vector2 newPosition;

    internal int x;
    internal int y;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            x = -Mathf.RoundToInt(other.transform.position.x - transform.position.x);
            y = -Mathf.RoundToInt(other.transform.position.y - transform.position.y);
            DetectNewPosition();
        }
    }

    internal virtual void DetectNewPosition(){}
}
