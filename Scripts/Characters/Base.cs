using Godot;
using System;

public partial class Base : Node3D
{
    [ExportGroup("Child Nodes")]
    [Export]
    public Label3D BaseLabel { get; private set; }

    [ExportGroup("")]

    [ExportCategory("Base Stats")]
    [Export]
    private int _maxHealth = 5;

    
    private int _currentHealth;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        _currentHealth = _maxHealth;
        UpdateBaseLabel();
    }

    // Member Methods------------------------------------------------------------------------------
    
    /// <summary>
    /// Decrease the base health by one and update its label
    /// </summary>
    public void TakeDamage()
    {
        GD.Print("I'm damaged :(");
        _currentHealth--;

        UpdateBaseLabel();
    }

    private void UpdateBaseLabel() => BaseLabel.Text = $"{_currentHealth}";
}