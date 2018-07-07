using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class ButtonAction
{
    public static void AddEventListen<T>(this Button btn, T value, Action<T> OnClick)
    {
        btn.onClick.AddListener(delegate
        {
            OnClick(value);
        });
    }
}
public class UIMrg : MonoBehaviour {
    private UIMrg() { }
    public static UIMrg instance;
    public GameObject Panel;
    public Button Jump;
    public Button Fire;
    public Button MoveForward;
    public Button keyA;
    public Button keyS;
    public Button keyD;
    public Button keyW;
    private Command playerCommand;
    private void Awake()
    {
        instance = this;
        ButtonAction.AddEventListen(Jump, new JumpCommand(), SetCommand);
        ButtonAction.AddEventListen(Fire, new FireCommand(), SetCommand);
        ButtonAction.AddEventListen(MoveForward, new MoveForwadCommand(), SetCommand);
        ButtonAction.AddEventListen(keyA, KeyCode.A, SetKeyCommand);
        ButtonAction.AddEventListen(keyS, KeyCode.S, SetKeyCommand);
        ButtonAction.AddEventListen(keyD, KeyCode.D, SetKeyCommand);
        ButtonAction.AddEventListen(keyW, KeyCode.W, SetKeyCommand);
    }

    public void SetCommand(Command playerCommand)
    {
        this.playerCommand = playerCommand;
        Panel.SetActive(true);
    }

    public void SetKeyCommand(KeyCode keycode)
    {
        NPCMrg.instance.player.SetKeyCommand(keycode, playerCommand);
        Panel.SetActive(false);
    }
}
