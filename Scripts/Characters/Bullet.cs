using Godot;
using System;

public partial class Bullet : Area3D
{
    [ExportCategory("Bullet Properties")]
    [Export]
    private Vector3 _direction = Vector3.Forward;

    [Export]
    private float _speed = 30.0f;



    public override void _PhysicsProcess(double delta)
    {
        Position += _direction * _speed * (float)delta;
    }
}
