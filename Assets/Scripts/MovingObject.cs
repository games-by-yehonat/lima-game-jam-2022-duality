using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class MovingObject : MonoBehaviour
{
    public float moveTime = 0.1f; 
    public LayerMask blockingLayer;
    
    protected bool m_turn = true;
    
    private BoxCollider2D m_boxCollider;
    private Rigidbody2D m_rb2D;
    private float m_inverseMoveTime;
    
    protected virtual void Start ()
    {
        m_boxCollider = GetComponent <BoxCollider2D> ();
        m_rb2D = GetComponent <Rigidbody2D> ();
        m_inverseMoveTime = 1f / moveTime;
    }
    
    protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2 (xDir, yDir);
        
        // m_boxCollider.enabled = false;
        
        hit = Physics2D.Linecast (start, end, blockingLayer);
        
        // m_boxCollider.enabled = true;
        
        if(hit.transform == null)
        {
            m_turn = false;
            StartCoroutine (SmoothMovement (end));
            return true;
        }

        m_turn = true;
        return false;
    }
    
    protected IEnumerator SmoothMovement (Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while(sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPostion = Vector3.MoveTowards(m_rb2D.position, end, m_inverseMoveTime * Time.deltaTime);
            m_rb2D.MovePosition (newPostion);

            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        m_turn = true;
    }
    
    protected virtual void AttemptMove <T> (int xDir, int yDir) where T : Component
    {
        RaycastHit2D hit;

        bool canMove = Move (xDir, yDir, out hit);

        if (hit.transform == null)
        {
            return;
        }
        
        T hitComponent = hit.transform.GetComponent <T> ();

        if (!canMove && hitComponent != null)
        {
            OnCantMove (hitComponent);
        }
    }
    
    protected abstract void OnCantMove <T> (T component) where T : Component;
}
