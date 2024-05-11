using Godot;
using System;

public partial class TurretManager : Node3D
{
    [Export]
    public PackedScene TurretScene { get; private set; }



    public override void _Ready()
    {
        var newTurret = TurretScene.Instantiate();
        AddChild(newTurret);
    }
}
