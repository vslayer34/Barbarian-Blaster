using Godot;
using System;

public partial class Bullet : Area3D
{
    [ExportGroup("Child Nodes")]
    [Export]
    public Timer BulletLifeSpan { get; private set; }
    [ExportGroup("")] 


    [ExportCategory("Bullet Properties")]
    [Export]
    private Vector3 _direction = Vector3.Forward;

    [Export]
    private float _speed = 30.0f;



    // Game Loop Methods---------------------------------------------------------------------------
    public override void _Ready()
    {
        BulletLifeSpan.Timeout += OnBulletLifeSpan_Timeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        Position += _direction * _speed * (float)delta;
    }


    // Signal Methods------------------------------------------------------------------------------
    /// <summary>
    /// Remove the bullet from the scene after amount of time
    /// </summary>
    private void OnBulletLifeSpan_Timeout()
    {
        QueueFree();
    }
}
