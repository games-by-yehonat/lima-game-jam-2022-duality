using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public string type;
    
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
        transform.position = parent.position;
    }
}
