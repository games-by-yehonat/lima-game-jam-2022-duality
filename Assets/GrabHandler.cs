using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHandler : MonoBehaviour
{
    public void SetParent(Transform parent)
    {
        if (m_canParent)
        {
            return;
        }
        
        transform.parent = parent;
    }

    public void SetOnGrabFloorArea(Transform parent)
    {
        SetParent(parent);
        transform.position = parent.position;
        m_canParent = true;
    }
    
    public void PushItem(Vector2 direction)
    {
        transform.parent = null;
        
        m_direction = direction;
        m_speed = 0.015f;
    }

    private void Update()
    {
        // m_speed -= m_decelerate * Time.deltaTime;
        m_speed = Mathf.Max(m_speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col);
        m_speed = 0;
        m_direction = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
        m_speed = 0;
        m_direction = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (transform.parent != null)
        {
            return;
        }
        
        transform.Translate(m_direction * m_speed);
    }

    private void Start()
    {
        m_decelerate = 0.015f;
    }

    private Vector2 m_direction = Vector2.zero;
    private float m_speed = 0.0f;
    private float m_decelerate;
    private bool m_canParent;
}
