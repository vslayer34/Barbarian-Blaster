using Godot;
using System;

namespace BarbarianBlasterMono.Scripts.Managers;
public partial class TurretManager : Node3D
{
    [Export]
    public PackedScene TurretScene { get; private set; }



    // Member Methods------------------------------------------------------------------------------

    /// <summary>
    /// Take a position and build a new turret on that position
    /// </summary>
    /// <param name="turretPosition">the position of the cell</param>
    public void BuildTurret(Vector3 turretPosition)
    {
        var newTurret = TurretScene.Instantiate() as Node3D;
        AddChild(newTurret);
        newTurret.GlobalPosition = turretPosition;
    }
}
