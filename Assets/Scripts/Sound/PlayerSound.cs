using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource _swordSound;
    [SerializeField] private AudioSource _keySound;
    [SerializeField] private AudioSource _treasureSound;
    [SerializeField] private AudioSource _damageSound;
    
    public AudioSource SwordSound { get { return _swordSound; } }
    public AudioSource KeySound { get { return _keySound; } }
    public AudioSource TreasureSound { get { return _treasureSound; } }
    public AudioSource DamageSound { get { return _damageSound; } }
}
