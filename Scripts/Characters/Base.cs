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
        CurrentHealth = _maxHealth;
    }

    // Member Methods------------------------------------------------------------------------------
    
    /// <summary>
    /// Decrease the base health by one and update its label
    /// </summary>
    public void TakeDamage()
    {
        GD.Print("I'm damaged :(");
        CurrentHealth--;
    }

    private void UpdateBaseLabel()
    {
        Color red = Colors.Red;
        Color white = Colors.White;

        BaseLabel.Text = $"{_currentHealth} / {_maxHealth}";
        BaseLabel.Modulate = red.Lerp(white, (float)_currentHealth / _maxHealth);
    }

    // Setters & Getters---------------------------------------------------------------------------

    /// <summary>
    /// Setthe current health and update the UI for the change
    /// </summary>
    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            
            _currentHealth = value;
            UpdateBaseLabel();

            if (_currentHealth < 1)
            {
                GetTree().ReloadCurrentScene();
            }
        }
    }
}