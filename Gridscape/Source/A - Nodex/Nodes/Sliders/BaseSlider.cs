namespace Gridscape;

public abstract class BaseSlider : Node2D
{
    public float Value = 0;
    public float MaxPossibleValue = 0;
    public SliderStyle Style = new();
    public SliderButton MiddleButton;
    public Action<BaseSlider> OnUpdate = (slider) => { };
    public event EventHandler<float>? ValueChanged;

    public override void Ready()
    {
        MiddleButton = GetChild<SliderButton>("MiddleButton");
        GetChild<Button>("DecrementButton").LeftClicked += OnDecrementButtonLeftClicked;
        GetChild<Button>("IncrementButton").LeftClicked += OnIncrementButtonLeftClicked;
    }

    public override void Update()
    {
        UpdateValue();
        Draw();
        OnUpdate(this);
        base.Update();
    }

    private void OnDecrementButtonLeftClicked(object? sender, EventArgs e)
    {
        MoveMiddleButton(-1);
    }

    private void OnIncrementButtonLeftClicked(object? sender, EventArgs e)
    {
        MoveMiddleButton(1);
    }

    protected abstract void MoveMiddleButton(int direction);

    protected abstract void Draw();

    protected abstract void UpdateValue();

    protected void OnValueChanged()
    {
        ValueChanged?.Invoke(this, Value);
    }
}