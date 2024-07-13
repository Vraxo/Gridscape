using Raylib_cs;

namespace Gridscape;

partial class BottomPanel : Panel
{
    public override void Build()
    {
        AddChild(new HorizontalSlider
        {
            Position = new(30, Size.Y / 2),
            OnUpdate = (slider) =>
            {
                slider.Position.Y = Size.Y / 2;
                slider.Size.X = Raylib.GetScreenWidth() - Position.X - 60;
                slider.MaxPossibleValue = GetNode<TileMapCamera>("TileMapCamera").Position.X;
            }
        }, 
        "Slider");
    }
}