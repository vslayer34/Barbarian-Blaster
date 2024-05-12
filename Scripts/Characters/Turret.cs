using Godot;
using System;

namespace BarbarianBlasterMono.Scripts.Characters;
public partial class Turret : Node3D
{
    [ExportGroup("Child Nodes")]
    [Export]
    public Marker3D BulletFirePosition;

    [Export]
    public Timer ShotInterval { get; private set; }
    [ExportGroup("")]

    
    [ExportCategory("Stats")]
    [Export]
    public PackedScene BulletScene { get; private set; }

    
    private Bullet _newBullet;



    // Game Loop Methods---------------------------------------------------------------------------
    public override void _Ready()
    {
        ShotInterval.Timeout += OnShotInterval_Timeout;
    }


    // Member Methods------------------------------------------------------------------------------
    private void OnShotInterval_Timeout()
    {
        _newBullet = BulletScene.Instantiate() as Bullet;
        AddChild(_newBullet);

        _newBullet.GlobalPosition = BulletFirePosition.GlobalPosition;
    }

}
