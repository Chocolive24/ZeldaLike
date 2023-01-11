using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private Image[] _keys;
    [SerializeField] private Sprite _goldenKey;
    
    [SerializeField] private FloatValue _keyContainer;
    [SerializeField] private FloatValue _playerKeys;
    
    // Start is called before the first frame update
    void Start()
    {
        InitKeys();
    }
    
    public void InitKeys()
    {
        for (int i = 0; i < _keyContainer.RunTimeValue; i++)
        {
            _keys[i].gameObject.SetActive(true);
            _keys[i].sprite = _goldenKey;
            _keys[i].gameObject.GetComponent<Image>().enabled = false;
        }
    }
    
    public void UpdateKeys()
    {
        float tmpKeys = _playerKeys.RunTimeValue;

        for (int i = (int)_keyContainer.RunTimeValue - 1; i >= 0; i--)
        {
            if (i < (int)tmpKeys)
            {
                _keys[i].gameObject.GetComponent<Image>().enabled = true;
            }

            else
            {
                _keys[i].gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }
}
