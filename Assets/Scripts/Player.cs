using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameActor {

    // Use this for initialization
    KeyboardInputHandler keyboardInput;

    void Start () {
        keyboardInput = new KeyboardInputHandler();
        keyboardInput.KeyA = new JumpCommand();
        keyboardInput.KeyD = new FireCommand();
        keyboardInput.KeyW = new MoveForwadCommand();
    }
    //添加特有指令
    public class MoveForwadCommand : Command
    {
        public override void Execute(GameActor actor)
        {
            actor.MoveForward();
        }
    }
    // Update is called once per frame
    void Update () {
        Command playerCommand = keyboardInput.HandleInput();
        if (playerCommand != null)
        {
            playerCommand.Execute(this);
        }
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
}
