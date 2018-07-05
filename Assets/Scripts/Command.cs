using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这个是feature分支
public class GameActor
{
    public void Jump() { }
    public void Fire() { }
}

public abstract class Command {
    public abstract void Execute(GameActor actor);
    public virtual void Undo() { }
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
        get
        {
            return x;
        }
    }
    public int Y
    {
        get
        {
            return y;
        }
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

public class InputHandler
{
    public Command HandleInput()
    {
        return null;
    }
    Command buttonX_;
    Command buttonY_;
    Command buttonA_;
    Command buttonB_;
}
