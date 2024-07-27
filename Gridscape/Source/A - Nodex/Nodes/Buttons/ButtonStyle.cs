namespace Gridscape;

public class ButtonStyle
{
    public ButtonStyleState Current = new();

    public ButtonStyleState Default = new();

    public ButtonStyleState Hover = new()
    {
        FillColor = new(101, 101, 101, 255),
        OutlineColor = new(71, 71, 71, 255)
    };

    public ButtonStyleState Pressed = new()
    {
        FillColor = new(71, 114, 179, 255),
        OutlineColor = new(61, 61, 61, 255),
    };

    public float Roundness
    {
        set
        {
            Current.Roundness = value;
            Hover.Roundness = value;
            Pressed.Roundness = value;
            Default.Roundness = value;
        }
    }

    public float OutlineThickness
    {
        set
        {
            Hover.OutlineThickness = value;
            Pressed.OutlineThickness = value;
            Default.OutlineThickness = value;
        }
    }

    public float FontSize
    {
        set
        {
            Hover.FontSize = value;
            Pressed.FontSize = value;
            Default.FontSize = value;
        }
    }

    public Font Font
    {
        set
        {
            Hover.Font = value;
            Pressed.Font = value;
            Default.Font = value;
        }
    }

    public Color TextColor
    {
        set
        {
            Hover.TextColor = value;
            Pressed.TextColor = value;
            Default.TextColor = value;
        }
    }

    public Color FillColor
    {
        set
        {
            Hover.FillColor = value;
            Pressed.FillColor = value;
            Default.FillColor = value;
        }
    }

    public Color OutlineColor
    {
        set
        {
            Hover.OutlineColor = value;
            Pressed.OutlineColor = value;
            Default.OutlineColor = value;
        }
    }
}