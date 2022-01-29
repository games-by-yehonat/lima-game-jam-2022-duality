using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5.0f;
	
	private void Awake()
	{
		m_body = GetComponent<Rigidbody2D>();
	}
    
    private void Update()
    {
	    m_movement.x = Input.GetAxisRaw("Horizontal");
	    m_movement.y = Input.GetAxisRaw("Vertical");

	    if (Input.GetKey(KeyCode.G))
	    {
		    if (m_grab != null && !m_taken)
		    {
			    m_grab.transform.parent = transform;
			    m_taken = true;
		    }
	    }
	    else
	    {
		    if (m_grab != null)
		    {
			    m_grab.transform.parent = null;
			    m_grab = null;
			    m_taken = false;
		    }
	    }

	    if (Input.GetKeyDown(KeyCode.Q))
	    {
		    if (m_grab != null)
		    {
			    Vector2 dir;
			    var dirX = m_grab.transform.position.x - transform.position.x;
			    var dirY = m_grab.transform.position.y - transform.position.y;

			    var isHorizontal = Mathf.Abs(dirX) > Mathf.Abs(dirY);

			    if (isHorizontal)
			    {
				    dir = dirX > 0 ? Vector2.right : Vector2.left;
			    }
			    else
			    {
				    dir = dirY > 0 ? Vector2.up : Vector2.down;
			    }
			    
			    m_grab.PushItem(dir);
			    m_grab.transform.parent = null;
			    m_grab = null;
			    m_taken = false;
			    m_body.velocity = Vector2.zero;
		    }
	    }
    }

    private void FixedUpdate()
    {
	    var fixSpeed = m_taken ? speed * 0.5f : speed;
	    var velocity = fixSpeed * Time.fixedDeltaTime;
	    var newPosition = m_body.position + m_movement * velocity;
	    m_body.MovePosition(newPosition);
    }
    
    private void OnCollisionStay2D(Collision2D col)
    {
	    var grab = col.gameObject.GetComponent<GrabHandler>();

	    if (grab == null && !m_taken)
	    {
		    return;
	    }

	    m_grab = grab;
    }

    private Rigidbody2D m_body;
    private Vector2 m_movement;
    private GrabHandler m_grab;
    private bool m_taken;
}
