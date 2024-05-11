using Godot;
using System;

namespace BarbarianBlasterMono.Scripts.Camera;
public partial class CameraRayCaster : Camera3D
{
    [ExportGroup("Child Nodes")]
    [Export]
    public RayCast3D RayCastNode { get; private set; }

    
    private Vector2 _mousePosition;
    private float _rayDistance = 100.0f;



    public override void _Process(double delta)
    {
        _mousePosition = GetViewport().GetMousePosition();
        
        RayCastNode.TargetPosition = ProjectLocalRayNormal(_mousePosition) * _rayDistance;
        RayCastNode.ForceRaycastUpdate();

        GD.PrintS(
            $"Ray interacted with: {RayCastNode.GetCollider()}", 
            $"Ray collision position: {RayCastNode.GetCollisionPoint()}"
        );
        GD.Print();
    }
}
