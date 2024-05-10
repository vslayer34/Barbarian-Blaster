using Godot;
using System;

public partial class Base : Node3D
{
    public void TakeDamage()
    {
        GD.Print("I'm damaged :(");
    }
}