using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool _areOpen = false;
    [SerializeField] private Animator _animator;
    private static readonly int AreOpen = Animator.StringToHash("areOpen");
    
    [SerializeField] private GameObject[] _locks;
    private int _nbrLock;
    
    private AudioSource _doorsSound;

    public int NbrLock
    {
        get { return _nbrLock; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _nbrLock = _locks.Length;
        _doorsSound = GetComponent<AudioSource>();
    }
    
    public void OpenTheDoors()
    {
        if (!_areOpen)
        {
            _animator.SetBool(AreOpen, true);
            _doorsSound.Play();
            _areOpen = true;
            
            for (int i = 0; i < _nbrLock; i++)
            {
                _locks[i].gameObject.GetComponent<Lock>().DestroySelf();
            }
        }
    }
}
