using Godot;
using System;

namespace BarbarianBlasterMono.Scripts.Characters;
public partial class Turret : Node3D
{
    [ExportGroup("Child Nodes")]
    [Export]
    public Marker3D BulletFirePosition;
    [ExportGroup("")]

    
    [ExportCategory("Stats")]
    [Export]
    public PackedScene BulletScene { get; private set; }

    
    private Bullet _newBullet;



    public override void _Ready()
    {
        _newBullet = BulletScene.Instantiate() as Bullet;
        _newBullet.Position = BulletFirePosition.Position;

        AddChild(_newBullet);
    }
}
