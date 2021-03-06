using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    //public TextMeshProUGUI text;
    public GameObject pausedMenu;
    public Image cameraShutDown;
    public float speedFade;

    private void Start()
    {
        EventManager.Subscribe("GameOver", FadeOn);

        if (cameraShutDown != null)
            cameraShutDown.color = new Color(cameraShutDown.color.r, cameraShutDown.color.g, cameraShutDown.color.b, 0);
        
    }

    public void ActivePause()
    {
        pausedMenu.SetActive(true);
    }

    public void InactivePause()
    {
        pausedMenu.SetActive(false);
    }

    public void FadeOn(params object[] parameters)
    {
        StartCoroutine(FadeActive());
    }

    public IEnumerator FadeActive()
    {
        Color fade = cameraShutDown.color;
        fade.a = 1;

        while (cameraShutDown.color.a < 1)
        {
            cameraShutDown.color = Color.Lerp(cameraShutDown.color, fade, speedFade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
