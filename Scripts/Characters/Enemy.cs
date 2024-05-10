using BarbarianBlasterMono.Scripts.Helper;
using Godot;
using System;

public partial class Enemy : PathFollow3D
{
    [ExportCategory("Properties")]
    [Export]
    private float _speed = 2.5f;


    private Base _baseNode;



    public override void _Ready()
    {
        // Get a reference to the base node
        _baseNode = GetTree().GetFirstNodeInGroup(GroupName.BASE) as Base;
    }


    public override void _Process(double delta)
    {
        Progress += (float)delta * _speed;

        if (ProgressRatio >= 1.0f)
        {
            _baseNode.TakeDamage();
            SetProcess(false);
        }
    }
}