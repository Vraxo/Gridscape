namespace Gridscape;

public class TextBoxStyle
{
    public TextBoxStyleState Current = new();
    
    public TextBoxStyleState Selected = new()
    {
        FillColor = new(34, 34, 34, 255),
        OutlineColor = new(71, 114, 179, 255),
    };

    public TextBoxStyleState Deselected = new();
}