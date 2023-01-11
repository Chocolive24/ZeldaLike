using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAndSlabRoom : MonoBehaviour
{
    [SerializeField] private GameObject _keyPrefab;
    [SerializeField] private Slab _slab;
    [SerializeField] private GameObject _roomPrefab;
    
    private Vector3 _roomCenter;
    
    private bool _keyCreated = false;
    
    private AudioSource _SecretSound;

    // Start is called before the first frame update
    void Start()
    {
        _roomCenter = _roomPrefab.GetComponent<Transform>().position;
        _SecretSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CreateKey();
    }

    private void CreateKey()
    {
        if (_slab.IsActive && !_keyCreated)
        {
            Instantiate(_keyPrefab, _roomCenter, Quaternion.identity);
            _keyCreated = true;
            _SecretSound.Play();
        }
    }
}
