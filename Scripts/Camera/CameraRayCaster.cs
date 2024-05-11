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


        if (RayCastNode.IsColliding())
        {
            var collider = RayCastNode.GetCollider();

            if (collider is GridMap gridMap)
            {
                var collisionPoint = RayCastNode.GetCollisionPoint();
                var cellPosition = gridMap.LocalToMap(collisionPoint);
                
                
                // Check if we have a cell with index 0 in the grid map
                if(gridMap.GetCellItem(cellPosition) == 0)
                {
                    gridMap.SetCellItem(cellPosition, 1);
                }
            }
        }
    }
}
