namespace Gridscape;

public class ButtonStyleState
{
    public float Roundness = 0F;
    public float OutlineThickness = 0;
    public float FontSize = 15;
    public Font Font = FontLoader.Instance.Fonts["RobotoMono 32"];
    public Color TextColor = Color.White;
    public Color FillColor = new(84, 84, 84, 255);
    public Color OutlineColor = new(61, 61, 61, 255);
}