using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSlab : MonoBehaviour
{
    [SerializeField] private Block _block;
    
    public void Activate()
    {
        _block.ResestPos();
    }
}
