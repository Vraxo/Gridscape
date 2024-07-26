namespace Gridscape;

partial class TopPanel : Panel
{
    public override void Build()
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
        }, "ZoomTextBox");

        AddChild(new Label
        {
            Position = new(110, Size.Y / 2),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "Map X:",
        });

        AddChild(new TextBox
        {
            Position = new(165, Size.Y / 2),
            Size = new(75, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "320",
            DefaultText = "0",
            MaxCharacters = 7,
            AllowedCharacters = CharacterSet.Numbers
        }, "MapXTextBox");

        AddChild(new Label
        {
            Position = new(250, Size.Y / 2),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "Map X:",
        });

        AddChild(new TextBox
        {
            Position = new(305, Size.Y / 2),
            Size = new(75, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "320",
            DefaultText = "0",
            MaxCharacters = 7,
            AllowedCharacters = CharacterSet.Numbers
        }, "MapYTextBox");

        AddChild(new Label
        {
            Position = new(390, Size.Y / 2),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "Grid X:",
        });
        
        AddChild(new TextBox
        {
            Position = new(445 + 11, Size.Y / 2),
            Size = new(75, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "320",
            DefaultText = "0",
            MaxCharacters = 7,
            AllowedCharacters = CharacterSet.Numbers
        }, "GridXTextBox");

        AddChild(new Label
        {
            Position = new(540, Size.Y / 2),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "Grid Y:",
        });

        AddChild(new TextBox
        {
            Position = new(595 + 11, Size.Y / 2),
            Size = new(75, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "320",
            DefaultText = "0",
            MaxCharacters = 7,
            AllowedCharacters = CharacterSet.Numbers
        }, "GridYTextBox");

        AddChild(new CircleCheckBox
        {
            Position = new(700, Size.Y / 2),
            Checked = true
        }, "ShowGridCheckBox");

        AddChild(new Label
        {
            Position = new(715, Size.Y / 2),
            Text = "Show Grid"
        });

        AddChild(new CircleCheckBox
        {
            Position = new(810, Size.Y / 2),
            Checked = true
        }, "SnapToGridCheckBox");

        AddChild(new Label
        {
            Position = new(825, Size.Y / 2),
            Text = "Snap To Grid"
        });

        AddChild(new ProjectSaver());

        AddChild(new Button
        {
            Position = new(875 + 85, Size.Y / 2),
            Size = new(50, 20),
            OriginPreset = OriginPreset.Center,
            Text = "Save",
            Layer = ClickableLayer.PanelButtons
        }, "SaveButton");

        AddChild(new ProjectExporter());

        AddChild(new Button
        {
            Position = new(975 + 50, Size.Y / 2),
            Size = new(50, 20),
            OriginPreset = OriginPreset.Center,
            Text = "Export",
            Layer = ClickableLayer.PanelButtons
        }, "ExportButton");
    }
}