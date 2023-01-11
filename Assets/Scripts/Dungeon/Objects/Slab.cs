using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slab : MonoBehaviour
{
    private bool _isActive = false;

    public bool IsActive
    {
        get { return _isActive; }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Block"))
        {
            _isActive = true;
        }
    }
}
