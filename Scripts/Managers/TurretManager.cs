using BarbarianBlasterMono.Scripts.Characters;
using Godot;
using System;

namespace BarbarianBlasterMono.Scripts.Managers;
public partial class TurretManager : Node3D
{
    [Export]
    public PackedScene TurretScene { get; private set; }

    [Export]
    public Path3D EnemyPath { get; private set; }



    // Member Methods------------------------------------------------------------------------------

    /// <summary>
    /// Take a position and build a new turret on that position
    /// </summary>
    /// <param name="turretPosition">the position of the cell</param>
    public void BuildTurret(Vector3 turretPosition)
    {
        Turret newTurret = TurretScene.Instantiate() as Turret;
        newTurret.EnemyPath = EnemyPath;
        AddChild(newTurret);
        newTurret.GlobalPosition = turretPosition;
    }
}
