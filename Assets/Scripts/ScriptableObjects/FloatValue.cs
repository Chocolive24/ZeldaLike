using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private float _initialValue;

    [NonSerialized]
    private float _runTimeValue;
    
    public float RunTimeValue { get { return _runTimeValue; } }

    public void SetValue(float newValue) { _runTimeValue = newValue;}
    public void AddValue(float value) { _runTimeValue += value;}
    public void SubstractValue(float value) { _runTimeValue -= value;}

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        _runTimeValue = _initialValue;
    }
}
