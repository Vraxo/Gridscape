using Raylib_cs;

namespace Gridscape;

public partial class VerticalSlider : Node2D
{
    public float Value = 0;
    public float MaxPossibleValue = 0;
    public SliderStyle Style = new();
    public SliderButton MiddleButton;
    public Action<VerticalSlider> OnUpdate = (slider) => { };
    public event EventHandler<float>? ValueChanged;

    public VerticalSlider()
    {
        Size = new(10, 100);
        OriginPreset = OriginPreset.TopCenter;
    }

    public override void Ready()
    {
        MiddleButton = GetChild<SliderButton>("MiddleButton");

        GetChild<Button>("TopButton").LeftClicked += OnTopButtonLeftClicked;
        GetChild<Button>("BottomButton").LeftClicked += OnBottomButtonLeftClicked;
    }

    public override void Update()
    {
        UpdateValue();
        Draw();
        OnUpdate(this);
        base.Update();
    }

    private void OnTopButtonLeftClicked(object? sender, EventArgs e)
    {
        MoveMiddleButton(-1);
    }

    private void OnBottomButtonLeftClicked(object? sender, EventArgs e)
    {
        Console.WriteLine("Bottom button clicked.");
        MoveMiddleButton(1);
    }

    private void MoveMiddleButton(int direction)
    {
        if (MaxPossibleValue == 0)
        {
            return;
        }

        float x = MiddleButton.GlobalPosition.X;
        float y = MiddleButton.GlobalPosition.Y + direction * (Size.Y / MaxPossibleValue);

        MiddleButton.GlobalPosition = new(x, y);
    }

    private void Draw()
    {
        Rectangle rectangle = new()
        {
            Position = GlobalPosition - Origin,
            Size = Size
        };

        Raylib.DrawRectangleRounded(
            rectangle,
            0,
            (int)Size.Y,
            Color.Gray);
    }

    private void UpdateValue()
    {
        float currentPosition = MiddleButton.GlobalPosition.Y;
        float minPos = GlobalPosition.Y;
        float maxPos = minPos + Size.Y;

        float previousValue = Value;

        // Calculate the value relative to the slider's range
        Value = (currentPosition - minPos) / (maxPos - minPos);

        if (Value != previousValue)
        {
            ValueChanged?.Invoke(this, Value);
        }
    }
}