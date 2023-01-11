using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TpController : MonoBehaviour
{
    [SerializeField] private Transform _tpPoint;
    
    public Transform TpPoint
    {
        get { return _tpPoint; }
    }
}
