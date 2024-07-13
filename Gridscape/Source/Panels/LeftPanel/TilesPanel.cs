using Raylib_cs;

namespace Gridscape;

class TilesPanel : Node2D
{
    private int startingIndex = 0;
    private int maxItemsShownAtOnce;

    public int StartingIndex
    {
        get => startingIndex;

        set
        {
            if (value < startingIndex)
            {
                if (startingIndex > 0)
                {
                    startingIndex = value;
                }
            }
            else
            {
                if (startingIndex < Children.Count - maxItemsShownAtOnce - 1)
                {
                    startingIndex = value;
                }
            }
        }
    }

    public override void Ready()
    {
        Parent.GetChild<VerticalSlider>("Slider").ValueChanged += OnSliderValueChanged;
    }

    public override void Update()
    {
        CheckForScrolling();
    }

    private void OnSliderValueChanged(object? sender, float e)
    {
        UpdateListBasedOnScroller();
    }

    private void UpdateListBasedOnScroller()
    {
        UpdateList(GetStartingIndexBasedOnSliderValue());
    }

    private void AdjustStartingIndex()
    {
        while (startingIndex > Children.Count - maxItemsShownAtOnce - 1)
        {
            startingIndex --;
        }
    }

    private void UpdateMaxItemsShownAtOnce()
    {
        int availableHeight = (int)(Raylib.GetScreenHeight() - 50 - TileItem.Height);
        maxItemsShownAtOnce = (int)(availableHeight / TileItem.Height);
    }

    private int GetStartingIndexBasedOnSliderValue()
    {
        float sliderValue = GetNode<VerticalSlider>("LeftPanel/Slider").Value;
        int numItemsBesideTheFirstPage = TileFilePathsContainer.Instance.TileFilePaths.Count - maxItemsShownAtOnce;
        return (int)Math.Floor(sliderValue * numItemsBesideTheFirstPage);
    }

    private void UpdateChildrenActivationAndPosition()
    {
        int j = 0;

        for (int i = 0; i < Children.Count; i++)
        {
            if (i >= StartingIndex && i <= StartingIndex + maxItemsShownAtOnce)
            {
                Children[i].Activate();
                (Children[i] as Node2D).Position.Y = 50 + j * TileItem.Height;
                j++;
            }
            else
            {
                Children[i].Deactivate();
            }
        }
    }

    private void CheckForScrolling()
    {
        if (!(Parent as Panel).IsMouseOver())
        {
            return;
        }

        float mouseWheelMovement = Raylib.GetMouseWheelMove();
        
        if (mouseWheelMovement > 0)
        {
            UpdateList(startingIndex - 1);
        }
        else if (mouseWheelMovement < 0)
        {
            UpdateList(startingIndex + 1);
        }
    }

    private void UpdateList(int newStartingIndex)
    {
        AdjustStartingIndex();
        UpdateMaxItemsShownAtOnce();

        StartingIndex = newStartingIndex; 

        UpdateChildrenActivationAndPosition();
    }
}