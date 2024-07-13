namespace Gridscape;

class TextBoxStyle
{
    public TextBoxSubStyle Current = new();
    
    public TextBoxSubStyle Selected = new()
    {
        FillColor = new(34, 34, 34, 255),
        OutlineColor = new(71, 114, 179, 255),
    };

    public TextBoxSubStyle Deselected = new();
}