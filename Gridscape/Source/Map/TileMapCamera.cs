using Raylib_cs;

namespace Gridscape;

public class TileMapCamera : Node2D
{
    public float Zoom = 1;
    public Vector2 ExtraMapSize = Vector2.Zero;

    private TileMap tileMap;
    private TextBox zoomTextBox;
    private TopPanel topPanel;
    private LeftPanel leftPanel;
    private RightPanel rightPanel;
    private BottomPanel bottomPanel;
    private VerticalSlider verticalSlider;
    private HorizontalSlider horizontalSlider;

    public override void Ready()
    {
        Position = Vector2.Zero;

        tileMap = GetNode<TileMap>("TileMap");
        zoomTextBox = GetNode<TextBox>("TopPanel/ZoomTextBox");

        topPanel = GetNode<TopPanel>("TopPanel");
        leftPanel = GetNode<LeftPanel>("LeftPanel");
        rightPanel = GetNode<RightPanel>("RightPanel");
        bottomPanel = GetNode<BottomPanel>("BottomPanel");

        horizontalSlider = GetNode<HorizontalSlider>("BottomPanel/Slider");
        verticalSlider = GetNode<VerticalSlider>("RightPanel/Slider");
    }

    public override void Update()
    {
        UpdateX();
        UpdateY();
        UpdateZoom();
        UpdateTextBox();
    }

    private void UpdateX()
    {
        float panelsWidth = leftPanel.Size.X + rightPanel.Size.X;
        float availableMapWidth = Raylib.GetScreenWidth() - panelsWidth;
        ExtraMapSize.X = (tileMap.Size.X * 1 /* Zoom */) - availableMapWidth;

        Position.X = ExtraMapSize.X > 0 ?
                     ExtraMapSize.X * horizontalSlider.Percentage :
                     0;
    }

    private void UpdateY()
    {
        float panelsHeight = bottomPanel.Size.Y + topPanel.Size.Y;
        float availableMapHeight = Raylib.GetScreenHeight() - panelsHeight;
        ExtraMapSize.Y = tileMap.Size.Y - availableMapHeight;

        Position.Y = ExtraMapSize.Y > 0 ?
                     ExtraMapSize.Y * verticalSlider.Percentage :
                     0;
    }

    private void UpdateZoom()
    {
        bool isTileMapOnTop = tileMap.Layer >= GetNode<ClickManager>().MinLayer;

        if (!tileMap.IsMouseOver() || !isTileMapOnTop)
        {
            return;
        }

        float mouseWheelMovement = Raylib.GetMouseWheelMove();

        if (mouseWheelMovement != 0)
        {
            if (mouseWheelMovement > 0)
            {
                if (Zoom < 4)
                {
                    Zoom += 0.25F;
                }
            }
            else
            {
                if (Zoom > 0.25)
                {
                    Zoom -= 0.25F;
                }
            }
        }
    }

    private void UpdateTextBox()
    {
        zoomTextBox.Text = Zoom.ToString();
    }
}