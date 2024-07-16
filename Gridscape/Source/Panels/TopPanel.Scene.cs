namespace Gridscape;

partial class TopPanel : Panel
{
    public override void Build()
    {
        Size = new(0, 35);

        leftPanel = GetNode<LeftPanel>("LeftPanel");

        AddZoomController();

        AddLabeledTextBox("MapX", 10 + 100, "Map X: ", "320");
        AddLabeledTextBox("MapY", 150 + 100, "Map Y: ", "320");

        AddLabeledTextBox("GridX", 290 + 100, "Grid Y: ", "32");
        AddLabeledTextBox("GridY", 440 + 100, "Grid Y: ", "32");

        AddLabeledCircleCheckBox("ShowGrid", 625 + 100, "Show Grid");
        AddLabeledCircleCheckBox("SnapToGrid", 750 + 100, "Snap To Grid");

        AddProjectSaverNodes();
        AddProjectExporterNodes();
    }
    
    private void AddZoomController()
    {
        AddChild(new Label
        {
            Position = new(10, Size.Y / 2),
            Text = "Zoom: "
        });

        AddChild(new TextBox
        {
            Position = new(55, Size.Y / 2),
            Size = new(50, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Editable = false,
        },
        "ZoomTextBox");
    }

    private void AddLabeledTextBox(string name, float x, string labelText, string textBoxText)
    {
        LabeledTextBox labeledTextBox = new()
        {
            Position = new(x, Size.Y / 2),
            Text = labelText
        };

        AddChild(labeledTextBox, name);

        labeledTextBox.TextBox.Size = new(75, 26 * 0.75F);
        labeledTextBox.TextBox.Text = textBoxText;
        labeledTextBox.TextBox.DefaultText = "0";
        labeledTextBox.TextBox.MaxCharacters = 7;
        labeledTextBox.TextBox.AllowedCharacters = CharacterSet.Numbers;
    }

    private void AddLabeledCircleCheckBox(string name, float x, string labelText)
    {
        LabeledCircleCheckBox2 labeledCircleCheckBox = new()
        {
            Position = new(x, Size.Y / 2),
        };

        AddChild(labeledCircleCheckBox, name);
        
        labeledCircleCheckBox.Label.Text = labelText;
        labeledCircleCheckBox.CheckBox.Checked = true;
    }

    private void AddProjectSaverNodes()
    {
        projectSaver = new();
        AddChild(projectSaver);

        AddButton("Save", 875 + 85, OnSaveButtonLeftClicked);
    }

    private void AddProjectExporterNodes()
    {
        projectExporter = new();
        AddChild(projectExporter);

        AddButton("Export", 975 + 50, OnExportButtonLeftClicked);
    }

    private void AddButton(string text, float x, EventHandler eventHandler)
    {
        Button button = new()
        {
            Position = new(x, Size.Y / 2),
            Size = new(50, 20),
            OriginPreset = OriginPreset.CenterLeft,
            Text = text,
            Layer = (int)ClickableLayer.PanelButtons,
        };

        button.LeftClicked += eventHandler;

        AddChild(button);
    }
}