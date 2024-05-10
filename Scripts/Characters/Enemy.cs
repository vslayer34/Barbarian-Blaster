using Godot;
using System;

public partial class Enemy : PathFollow3D
{
    [ExportCategory("Properties")]
    [Export]
    private float _speed = 2.5f;



    public override void _Process(double delta)
    {
        Progress += (float)delta * _speed;
    }
}