using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
