namespace Gridscape;

public abstract class BaseSlider : Node2D
{
    public float Percentage = 0;
    public float MaxExternalValue = 0;
    public float Value => Percentage * MaxExternalValue;
    public SliderStyle Style = new();
    public BaseSliderButton MiddleButton;
    public Action<BaseSlider> OnUpdate = (slider) => { };
    public event EventHandler<float>? PercentageChanged;

    private float _externalValue = 0;
    public float ExternalValue
    {
        get => _externalValue;

        set
        {
            if (_externalValue != value)
            {
                _externalValue = value;

                //float minPos = GlobalPosition.Y - Origin.Y;
                //float maxPos = minPos + Size.Y;

                //float y = ExternalValue / MaxExternalValue * maxPos;

                //MiddleButton.GlobalPosition = new(MiddleButton.GlobalPosition.X, y);
            }
        }
    }

    public override void Ready()
    {
        MiddleButton = GetChild<BaseSliderButton>("MiddleButton");
        GetChild<Button>("DecrementButton").LeftClicked += OnDecrementButtonLeftClicked;
        GetChild<Button>("IncrementButton").LeftClicked += OnIncrementButtonLeftClicked;
    }

    public override void Update()
    {
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

    public abstract void UpdatePercentageBasedOnMiddleButton();

    protected void OnPercentageChanged()
    {
        PercentageChanged?.Invoke(this, Percentage);
    }
}