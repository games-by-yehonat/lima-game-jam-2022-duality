using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EntityMovement : MonoBehaviour
{
    [SerializeField]
    internal bool isReady = true;
    internal Vector2 newPosition;
    internal Vector2 direction;

    [SerializeField]
    internal float speed = 0;

    internal float currentSpeed = 0;

    internal virtual void Awake()
    {
        newPosition = transform.position;
    }

    internal virtual void Update()
    {
        if (isReady == true)
        {
            return;
        }
        currentSpeed += Time.deltaTime * speed;
        if (currentSpeed >= 1 || Vector3.Distance(transform.position, newPosition) <= 0.01f)
            isReady = true;
    }

    internal virtual void LateUpdate()
    {

        if (newPosition != Vector2.zero)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, currentSpeed);
        }
    }

    internal virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && isReady)
        {
            direction.x = -Mathf.RoundToInt(other.transform.position.x - transform.position.x);
            direction.y = -Mathf.RoundToInt(other.transform.position.y - transform.position.y);
            if (Mathf.Abs(direction.y) == Mathf.Abs(direction.x))
            {
                direction = Vector2.right * direction;
            }
            isReady = false;
            currentSpeed = 0;
            DetectNewPosition();
        }
    }
    
    public bool CanMove(int xDir, int yDir, LayerMask blockingLayer)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2 (xDir, yDir);
        
        RaycastHit2D hit = Physics2D.Linecast (start, end, blockingLayer);

        if (hit.transform == null)
        {
            return true;
        }
        
        return false;
    }

    internal virtual void DetectNewPosition() { }
}
