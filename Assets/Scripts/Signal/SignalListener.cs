using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    [SerializeField] private SignalSender _signalSender;
    [SerializeField] private UnityEvent _signalEvent;
    
    public void OnSignalRaise()
    {
        _signalEvent.Invoke();
    }

    private void OnEnable()
    {
        _signalSender.RegisterListener(this);
    }

    private void OnDisable()
    {
        _signalSender.DeregisterListener(this);
    }
}
