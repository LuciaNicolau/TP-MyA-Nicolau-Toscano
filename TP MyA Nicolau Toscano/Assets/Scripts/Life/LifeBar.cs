using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour, IObserver
{
    public Image lifeBar;
    IObservable _playerToCopy;
    private void Start()
    {
        _playerToCopy.Subscribe(this);
    }

    void BarUpdate(float _life, float _maxLife)
    {
        lifeBar.fillAmount = (_life / _maxLife);
    }

    public void Notify(float value, float maxValue)
    {
        BarUpdate(value, maxValue);
    }
}
