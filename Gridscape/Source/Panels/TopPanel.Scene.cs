namespace Gridscape;

public partial class TopPanel : Panel
{
    public override void Build()
    {
        AddChild(new Label
        {
            Position = new(10, 18),
            Text = "Zoom: "
        });

        AddChild(new TextBox
        {
            Position = new(55, 18),
            Size = new(50, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Editable = false,
        }, "ZoomTextBox");

        AddChild(new Label
        {
            Position = new(110, 18),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "Map X:",
        });

        AddChild(new TextBox
        {
            Position = new(165, 18),
            Size = new(75, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Layer = ClickableLayer.PanelButtons,
            Text = "320",
            DefaultText = "0",
            MaxCharacters = 7,
            AllowedCharacters = CharacterSet.Numbers
        }, "MapXTextBox");

        AddChild(new Label
        {
            Position = new(250, 18),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "Map Y:",
        });

        AddChild(new TextBox
        {
            Position = new(305, 18),
            Size = new(75, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Layer = ClickableLayer.PanelButtons,
            Text = "320",
            DefaultText = "0",
            MaxCharacters = 7,
            AllowedCharacters = CharacterSet.Numbers
        }, "MapYTextBox");

        AddChild(new Label
        {
            Position = new(390, 18),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "Grid X:",
        });
        
        AddChild(new TextBox
        {
            Position = new(445 + 11, 18),
            Size = new(75, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Layer = ClickableLayer.PanelButtons,
            Text = "320",
            DefaultText = "0",
            MaxCharacters = 7,
            AllowedCharacters = CharacterSet.Numbers
        }, "GridXTextBox");

        AddChild(new Label
        {
            Position = new(540, 18),
            OriginPreset = OriginPreset.CenterLeft,
            Text = "Grid Y:",
        });

        AddChild(new TextBox
        {
            Position = new(595 + 11, 18),
            Size = new(75, 26 * 0.75F),
            OriginPreset = OriginPreset.CenterLeft,
            Layer = ClickableLayer.PanelButtons,
            Text = "320",
            DefaultText = "0",
            MaxCharacters = 7,
            AllowedCharacters = CharacterSet.Numbers
        }, "GridYTextBox");

        AddChild(new CheckBox
        {
            Position = new(700, 18),
            Checked = true,
            Layer = ClickableLayer.PanelButtons,
        }, "ShowGridCheckBox");

        AddChild(new Label
        {
            Position = new(715, 18),
            Text = "Show Grid"
        });

        AddChild(new CheckBox
        {
            Position = new(810, 18),
            Checked = true,
            Layer = ClickableLayer.PanelButtons,
        }, "SnapToGridCheckBox");

        AddChild(new Label
        {
            Position = new(825, 18),
            Text = "Snap To Grid"
        });

        AddChild(new ProjectSaver());

        AddChild(new Button
        {
            Position = new(875 + 85, 18),
            Size = new(50, 20),
            OriginPreset = OriginPreset.Center,
            Layer = ClickableLayer.PanelButtons,
            Text = "Save",
        }, "SaveButton");

        AddChild(new ProjectExporter());

        AddChild(new Button
        {
            Position = new(975 + 50, 18),
            Size = new(50, 20),
            OriginPreset = OriginPreset.Center,
            Layer = ClickableLayer.PanelButtons,
            Text = "Export",
        }, "ExportButton");
    }
}