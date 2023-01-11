using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSound : MonoBehaviour
{
    [SerializeField] private AudioSource _switchOnSound;
    [SerializeField] private AudioSource _switchOffSound;
    
    public AudioSource SwitchOnSound { get { return _switchOnSound; } }
    public AudioSource SwitchOffSound { get { return _switchOffSound; } }
}
