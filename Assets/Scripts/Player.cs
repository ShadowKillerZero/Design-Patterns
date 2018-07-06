using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//添加特有指令
public class MoveForwadCommand : Command
{
    public override void Execute(GameActor actor)
    {
        actor.MoveForward();
    }
}
public class Player : GameActor {

    // Use this for initialization
    KeyboardInputHandler keyboardInput;

    public override void Start () {
        base.Start();

        keyboardInput = new KeyboardInputHandler();
        keyboardInput.KeyA = new JumpCommand();
        keyboardInput.KeyD = new FireCommand();
        keyboardInput.KeyW = new MoveForwadCommand();

    }

    // Update is called once per frame
    void Update () {
        Command playerCommand = keyboardInput.HandleInput();
        if (playerCommand != null)
        {
            playerCommand.Execute(this);
        }
	}

    public void ChangeKeyCommand()
    {
        
    }

    public override void Jump()
    {
        Debug.Log("jump");
    }

    public override void Fire()
    {
        Debug.Log("fire");
    }

    public override void MoveForward()
    {
        Debug.Log("move forwad");
    }
    public override void SetKeyCommand(KeyCode keyCode, Command command)
    {
        switch (keyCode)
        {
            case KeyCode.A:
                this.keyboardInput.KeyA = command;
                break;
            case KeyCode.D:
                this.keyboardInput.KeyD = command;
                break;
            case KeyCode.W:
                this.keyboardInput.KeyW = command;
                break;
            case KeyCode.S:
                this.keyboardInput.KeyS = command;
                break;
        }
        
    }
}
