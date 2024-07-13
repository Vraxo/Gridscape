using Raylib_cs;

namespace Gridscape;

class TextBoxShape : Node2D
{
    public TextBoxStyle Style;

    private TextBox parent;

    public override void Start()
    {
        parent = GetParent<TextBox>();
    }

    public override void Update()
    {
        DrawShape();
        base.Update();
    }

    private void DrawShape()
    {
        Rectangle rectangle = new()
        {
            Position = GlobalPosition - Origin,
            Size = Size
        };

        DrawRectangle(rectangle);
        DrawOutline(rectangle);
    }

    private void DrawRectangle(Rectangle rectangle)
    {
        Raylib.DrawRectangleRounded(
            rectangle,
            Style.Current.Roundedness,
            (int)Size.Y,
            Style.Current.FillColor);
    }

    private void DrawOutline(Rectangle rectangle)
    {
        if (parent.Style.Current.OutlineThickness > 0)
        {
            Raylib.DrawRectangleRoundedLines(
                rectangle,
                Style.Current.Roundedness,
                (int)Size.Y,
                Style.Current.OutlineThickness,
                Style.Current.OutlineColor);
        }
    }
}