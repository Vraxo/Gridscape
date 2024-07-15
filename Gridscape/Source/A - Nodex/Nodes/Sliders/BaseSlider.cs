namespace Gridscape;

public abstract class BaseSlider : Node2D
{
    public float Value = 0;
    public float MaxPossibleValue = 0;
    public SliderStyle Style = new();
    public SliderButton MiddleButton;
    public Action<BaseSlider> OnUpdate = (slider) => { };
    public event EventHandler<float>? ValueChanged;

    public override void Start()
    {
        MiddleButton = GetChild<SliderButton>("MiddleButton");
    }

    public override void Update()
    {
        UpdateValue();
        Draw();
        OnUpdate(this);
        base.Update();
    }

    protected abstract void MoveMiddleButton(int direction);

    protected abstract void Draw();

    protected abstract void UpdateValue();
}
