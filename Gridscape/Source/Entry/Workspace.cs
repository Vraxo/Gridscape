﻿namespace Gridscape;

class Workspace : Node2D
{
    //private static readonly int leftPanelIndex = 2;
    //private static readonly int tileMapIndex = 7;

    //public override void Ready()
    //{
    //    AddChild(new TileFilePathsContainer());
    //    AddChild(new ClickManager());  // 1
    //    AddChild(new LeftPanel());     // 2
    //    AddChild(new TopPanel());      // 3
    //    AddChild(new BottomPanel());   // 4
    //    AddChild(new RightPanel());    // 5
    //    AddChild(new TileMapCamera()); // 6
    //    AddChild(new TileMap());       // 7
    //    AddChild(new ProjectLoader()); // 8
    //
    //    Children.Swap(leftPanelIndex, tileMapIndex);
    //}

    public override void Ready()
    {
        AddChild(new TileFilePathsContainer());
        AddChild(new TileMap());
        AddChild(new ClickManager());  // 1
        AddChild(new LeftPanel());     // 2
        AddChild(new TopPanel());      // 3
        AddChild(new BottomPanel());   // 4
        AddChild(new RightPanel());    // 5
        AddChild(new TileMapCamera()); // 6
        AddChild(new ProjectLoader()); // 8
    }
}