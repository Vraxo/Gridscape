﻿using Raylib_cs;

namespace Gridscape;

class TileMapCamera : Node2D
{
    public float Zoom = 1;

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
        base.Update();
    }

    private void UpdateX()
    {
        float panelsWidth = leftPanel.Size.X + rightPanel.Size.X;
        float availableMapWidth = Raylib.GetScreenWidth() - panelsWidth;
        float extraMapWidth = (tileMap.Size.X * 1 /* Zoom */) - availableMapWidth;

        Position.X = extraMapWidth > 0 ?
                     extraMapWidth * horizontalSlider.Value :
                     0;

    }

    private void UpdateY()
    {
        float panelsHeight = bottomPanel.Size.Y - topPanel.Size.Y;
        float availableMapHeight = Raylib.GetScreenHeight() - panelsHeight;
        float extraMapHeight = tileMap.Size.Y - availableMapHeight;

        Position.Y = extraMapHeight > 0 ?
                     extraMapHeight * verticalSlider.Value :
                     0;
    }

    private void UpdateZoom()
    {
        if (!tileMap.IsMouseOver())
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