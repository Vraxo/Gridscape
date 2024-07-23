namespace Gridscape;

class LabeledCircleCheckBox2 : Node2D
{
    public Label Label;
    public CircleCheckBox CheckBox;

    public override void Ready()
    {
        AddLabel();
        AddCheckBox();
    }

    private void AddLabel()
    {
        Label = new()
        {
            OriginPreset = OriginPreset.CenterLeft
        };

        AddChild(Label, "Label");
    }

    private void AddCheckBox()
    {
        CheckBox = new()
        {
            OriginPreset = OriginPreset.CenterLeft,
            OnUpdate = (checkBox) =>
            {
                checkBox.Position = new(checkBox.Radius * -2, 0);
            }
        };

        AddChild(CheckBox, "CheckBox");
    }
}