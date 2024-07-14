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
                slider.Size = new(Raylib.GetScreenWidth() - Position.X - 60, slider.Size.Y);
                //slider.MaxPossibleValue = GetNode<TileMap>().Size.X;
                slider.MaxPossibleValue = GetNode<TileMapCamera>().ExtraMapSize.X;
            }
        }, 
        "Slider");
    }
}