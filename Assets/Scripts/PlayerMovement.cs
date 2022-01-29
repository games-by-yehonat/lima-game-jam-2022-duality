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
    }

    private void FixedUpdate()
    {
	    m_body.MovePosition(m_body.position + m_movement * speed * Time.fixedDeltaTime);
    }
    
    private Rigidbody2D m_body;
    private Vector2 m_movement;
}
