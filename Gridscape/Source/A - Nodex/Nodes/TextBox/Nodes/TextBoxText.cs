using Raylib_cs;

namespace Gridscape;

class TextBoxText : Node2D
{
    public TextBoxStyle Style;

    private TextBox parent;

    public override void Start()
    {
        parent = GetParent<TextBox>();
    }

    public override void Update()
    {
        Draw();
    }

    private void Draw()
    {
        Raylib.DrawTextEx(
            Style.Current.Font,
            parent.Text,
            GetPosition(),
            Style.Current.FontSize,
            1,
            Style.Current.TextColor);
    }

    private Vector2 GetPosition()
    {
        Vector2 position = new(GetX(), GetY());
        return position;
    }

    private int GetX()
    {
        int x = (int)(GlobalPosition.X - parent.Origin.X + Style.Current.Padding);
        return x;
    }

    private int GetY()
    {
        int halfFontHeight = GetHalfFontHeight();
        int y = (int)(GlobalPosition.Y + (parent.Size.Y / 2) - halfFontHeight - parent.Origin.Y);
        return y;
    }

    private int GetHalfFontHeight()
    {
        Font font = Style.Current.Font;
        string text = parent.Text;
        uint fontSize = Style.Current.FontSize;

        int halfFontHeight = (int)(Raylib.MeasureTextEx(font, text, fontSize, 1).Y / 2);
        return halfFontHeight;
    }
}