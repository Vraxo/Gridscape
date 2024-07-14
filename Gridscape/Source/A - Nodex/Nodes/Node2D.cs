namespace Gridscape;

class Node2D : Node
{
    public Vector2 Position = Vector2.Zero;
    public OriginPreset OriginPreset = OriginPreset.Center;
    public bool InheritPosition = true;
    public bool InheritsOrigin = false;
    public int Layer = -1;

    private Vector2 _size = Vector2.Zero;
    public Vector2 Size
    {
        get => _size;

        set
        {
            //UpdateOrigin();
            _size = value;
        }
    }

    private Vector2 _globalPosition = Vector2.Zero;
    public Vector2 GlobalPosition
    {
        get
        {
            if (Parent is not null)
            {
                if (InheritPosition)
                {
                    return (Parent as Node2D).GlobalPosition + Position;
                }

                return _globalPosition;
            }
            else
            {
                return Position;
            }
        }

        set
        {
            _globalPosition = value;
        }
    }

    private Vector2 _origin = Vector2.Zero;
    public Vector2 Origin
    {
        get
        {
            if (InheritsOrigin)
            {
                if (Parent is not null)
                {
                    return (Parent as Node2D).Origin;
                }
            }
            
            return _origin;
        }

        set
        {
            _origin = value;
        }
    }

    public override void Update()
    {
        UpdateLayer();
        UpdateOrigin();
    }

    private void UpdateOrigin()
    {
        Origin = OriginPreset switch
        {
            OriginPreset.Center => Size / 2,
            OriginPreset.CenterLeft => new(0, Size.Y / 2),
            OriginPreset.CenterRight => new(Size.X, Size.Y / 2),
            OriginPreset.TopLeft => new(0, 0),
            OriginPreset.TopRight => new(Size.X, 0),
            OriginPreset.TopCenter => new(Size.X / 2, 0),
            OriginPreset.BottomLeft => new(0, Size.Y),
            OriginPreset.BottomRight => Size,
            OriginPreset.BottomCenter => new(Size.X / 2, Size.Y),
        };
    }

    private void UpdateLayer()
    {
        foreach (Node child in Children)
        {
            Node2D? node2DChild = child as Node2D;

            if (node2DChild is not null)
            {
                if (node2DChild.Layer == -1)
                {
                    node2DChild.Layer = Layer + 1;
                }
            }
        }
    }
}