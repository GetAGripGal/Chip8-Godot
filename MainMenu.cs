using Godot;
using System;

public class MainMenu : Control
{
    private FileDialog _romPicker;
    private Control _mainMenu;
    private RichTextLabel _fileLabel;

    private Chip8 _chip8;
    
    public override void _Ready()
    {
        _mainMenu = GetNode<Control>("MainMenu");
        _romPicker = _mainMenu.GetNode<FileDialog>("FileDialog");
        _fileLabel = _mainMenu.GetNode<RichTextLabel>("SelectedFile");
    }

    public override void _Process(float delta)
    {
        if (_romPicker.CurrentFile == "")
        {
            _fileLabel.Text = "No file selected.";
            return;
        }

        _fileLabel.Text = _romPicker.CurrentFile;
    }

    public void OpenRom()
    {
        _romPicker.Popup_();
    }

    public void Run()
    {
        if (_romPicker.CurrentFile == "") return;
        _mainMenu.Hide();
        
        var emuScene = GD.Load<PackedScene>("res://Emulator.tscn").Instance();
        AddChild(emuScene);
        
        var chip8 = GetNode<Chip8>("Emulator/Chip8");
        chip8.Position = Vector2.Zero;
        chip8.ComputeModule.Init(_romPicker.CurrentPath);
        GD.Print(_romPicker.CurrentPath);
    }
}
