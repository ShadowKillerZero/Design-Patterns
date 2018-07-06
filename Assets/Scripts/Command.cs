using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Dev
public abstract class GameActor : MonoBehaviour
{
    public virtual void Jump() { }
    public virtual void Fire() { }
    public virtual void MoveForward() { }
}

public abstract class Command {
    public abstract void Execute(GameActor actor);
    public virtual void Undo() { }
}

public class NullCommand : Command
{
    public override void Execute(GameActor actor) { }
}

public class JumpCommand : Command
{
    public override void Execute(GameActor actor)
    {
        actor.Jump();
    }
}

public class FireCommand : Command
{
    public override void Execute(GameActor actor)
    {
        actor.Fire();
    }
}

public class Unit
{

    private int x;
    private int y;
    public int X
    {
        get { return x; }
    }
    public int Y
    {
        get { return y; }
    }

    public void MoveTo(int x,int y)
    {
        this.x = x;
        this.y = y;
        //Move
    }

}

public class MoveUnitCommand : Command
{
    public MoveUnitCommand(Unit unit,int x,int y)
    {
        this.unit = unit;
        this.mx = x;
        this.my = y;
        this.xBefore = 0;
        this.yBefore = 0;
    }
    public override void Execute(GameActor actor)
    {
        xBefore = unit.X;
        yBefore = unit.Y;
        unit.MoveTo(mx, my);
    }

    private int xBefore, yBefore;

    private int mx, my;
    private Unit unit;
}

public abstract class InputHandler
{
    public abstract Command HandleInput();
}

public class KeyboardInputHandler : InputHandler
{
    Command keyA;
    Command keyS;
    Command keyW;
    Command keyD;
    NullCommand nullCommand;
    public KeyboardInputHandler()
    {
        keyA = nullCommand;
        keyS = nullCommand;
        keyW = nullCommand;
        keyD = nullCommand;
    }
    public Command KeyD
    {
        set { keyD = value; }
    }

    public Command KeyA
    {
        set { keyA = value; }
    }

    public Command KeyS
    {
        set { keyS = value; }
    }

    public Command KeyW
    {

        set { keyW = value; }
    }

    public override Command HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A)) return keyA;
        if (Input.GetKeyDown(KeyCode.S)) return keyS;
        if (Input.GetKeyDown(KeyCode.D)) return keyD;
        if (Input.GetKeyDown(KeyCode.W)) return keyW;
        return null;
    }
}
