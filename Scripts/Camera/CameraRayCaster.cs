using BarbarianBlasterMono.Scripts.Helper;
using BarbarianBlasterMono.Scripts.Managers;
using Godot;
using System;
using static Godot.Input;

namespace BarbarianBlasterMono.Scripts.Camera;
public partial class CameraRayCaster : Camera3D
{
    [ExportGroup("Child Nodes")]
    [Export]
    public RayCast3D RayCastNode { get; private set; }


    [ExportGroup("Required Nodes")]
    [Export]
    public TurretManager TurretManagerNode { get; private set; }
    
    private Vector2 _mousePosition;
    private Vector3 _cellGlobalPosition;
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
                var cellGridPosition = gridMap.LocalToMap(collisionPoint);
                
                
                // Check if we have a cell with index 0 in the grid map
                if(gridMap.GetCellItem(cellGridPosition) == 0)
                {
                    Input.SetDefaultCursorShape(CursorShape.PointingHand);

                    if (Input.IsActionJustPressed(InputActionNames.User.CLICK))
                    {
                        Input.SetDefaultCursorShape(CursorShape.Arrow);
                        gridMap.SetCellItem(cellGridPosition, 1);

                        _cellGlobalPosition = gridMap.MapToLocal(cellGridPosition);
                        TurretManagerNode.BuildTurret(_cellGlobalPosition);
                    }
                }
                else
                {
                    Input.SetDefaultCursorShape(CursorShape.Arrow);
                }
            }
        }
        else
        {
            Input.SetDefaultCursorShape(CursorShape.Arrow);   
        }
    }
}
