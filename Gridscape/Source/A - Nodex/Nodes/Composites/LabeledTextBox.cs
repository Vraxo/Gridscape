namespace Gridscape;

class LabeledTextBox : Label
{
    public TextBox TextBox;

    public override void Ready()
    {
        OriginPreset = OriginPreset.CenterLeft;

        TextBox = new()
        {
            Position = new(Size.X, 0),
            OriginPreset = OriginPreset.CenterLeft,
        };

        AddChild(TextBox);
    }

    public override void Update()
    {
        TextBox.Position = new(Size.X, 0);
        base.Update();
    }
}