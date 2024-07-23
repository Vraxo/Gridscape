namespace Gridscape;

class LabeledCircleCheckBox : Label
{
    public CircleCheckBox CheckBox;

    public override void Ready()
    {
        OriginPreset = OriginPreset.CenterLeft;

        base.Update();

        CheckBox = new()
        {
            OriginPreset = OriginPreset.CenterLeft,
        };

        AddChild(CheckBox, "CheckBox");
    }

    public override void Update()
    {
        UpdateCheckBoxPosition();
        base.Update();
    }

    private void UpdateCheckBoxPosition()
    {
        CheckBox.Position = new(CheckBox.Radius * -2, 0);
    }
}