using Godot;
using Godot.Collections;
using System;
using System.Linq;

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
    private Path3D _enemyPath;

    private Array<Node> _enemies;



    // Game Loop Methods---------------------------------------------------------------------------
    public override void _Ready()
    {
        ShotInterval.Timeout += OnShotInterval_Timeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        _enemies = _enemyPath.GetChildren();
        Enemy lastEnemy = _enemies.Last() as Enemy;

        LookAt(lastEnemy.GlobalPosition, Vector3.Up, true);
    }

    // Signal Methods------------------------------------------------------------------------------
    private void OnShotInterval_Timeout()
    {
        _newBullet = BulletScene.Instantiate() as Bullet;
        AddChild(_newBullet);

        _newBullet.GlobalPosition = BulletFirePosition.GlobalPosition;
    }

    // Setters and Getters-------------------------------------------------------------------------

    public Path3D EnemyPath { set => _enemyPath = value; }
}
