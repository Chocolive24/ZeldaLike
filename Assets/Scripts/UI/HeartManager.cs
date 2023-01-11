using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _fullHeart;
    [SerializeField] private Sprite _halfFullHeart;
    [SerializeField] private Sprite _emptyHeart;
    [SerializeField] private FloatValue _heartContainers;
    [SerializeField] private FloatValue _playerCurrentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }
    
    public void InitHearts()
    {
        for (int i = 0; i < _heartContainers.RunTimeValue; i++)
        {
            _hearts[i].gameObject.SetActive(true);
            _hearts[i].sprite = _fullHeart;
        }
    }
    
    public void UpdateHearts()
    {
        float tmpHealth = _playerCurrentHealth.RunTimeValue / 2;

        for (int i = 0; i < _heartContainers.RunTimeValue; i++)
        {
            if (i <= tmpHealth - 1)
            {
                //Full heart.
                _hearts[i].sprite = _fullHeart;
            }
            else if (i >= tmpHealth)
            {
                //Empty heart.
                _hearts[i].sprite = _emptyHeart;
            }
            else
            {
                // Half full heart.
                _hearts[i].sprite = _halfFullHeart;
            }
        }
    }
}
