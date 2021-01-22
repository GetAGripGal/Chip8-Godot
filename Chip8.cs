using Godot;
using System;
using Chip8Emulator;

public class Chip8 : Node2D
{
    private Renderer _renderer;

    public Cpu ComputeModule;

    public override void _Ready()
    {
        _renderer = GetNode<Renderer>("../Renderer");
        ComputeModule = new Cpu(_renderer);
    }

    public override void _Input(InputEvent @event)
    {
        if (ComputeModule.NextKeyEvent != null && @event is InputEventKey key)
        {
            ComputeModule.NextKeyEvent(key.ToString());
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        ComputeModule.Cycle();
    }
    
}
