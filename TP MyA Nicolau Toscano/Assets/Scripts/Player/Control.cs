using System;
using System.Collections.Generic;
using UnityEngine;

public class Control
{
    Movement _movement;
    private Player player;
    private Vector3 _movementInput;


    Action controlsMethod;

    public Control(Player controller, Movement m)
    {
        _movement = m;
        player = controller;
        controlsMethod = NormalControls;
    }

    public void OnUpdate()
    {
        _movementInput.x = Input.GetAxis("Horizontal");
        _movementInput.y = Input.GetAxis("Vertical");

        controlsMethod();

        if (_movementInput.x != 0)
            _movement.Move(_movementInput.x);
        if (_movementInput.y >= 1)
            _movement.Jump();
    }

    void NormalControls()
    {
        player.UImanager.InactivePause();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pausa");
            Time.timeScale = 0f;
            controlsMethod = PausedControls;
            player.UImanager.ActivePause();
        }

    }

    void PausedControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            controlsMethod = NormalControls;
            player.UImanager.InactivePause();
        }

    }
}
