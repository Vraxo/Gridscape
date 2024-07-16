namespace Gridscape;

public class Node
{
    public string Name = "";
    public Node? Parent = null;
    public List<Node> Children = [];
    public Program Program = null;
    public bool Active { get; private set; } = true;

    private bool started = false;

    // Public

    public virtual void Build() { }

    public virtual void Start() { }

    public virtual void Ready() { }

    public virtual void Update() { }

    public virtual void Destroy()
    {
        List<Node> childrenToDestroy = new(Children);

        foreach (Node child in childrenToDestroy)
        {
            child.Destroy();
        }

        Parent?.Children.Remove(this);
    }

    public void Tick()
    {
        if (!Active)
        {
            return;
        }

        if (!started)
        {
            Ready();
            started = true;
        }

        Update();

        for (int i = 0; i < Children.Count; i++)
        {
            Children[i].Tick();
        }
    }

    public void PrintChildren(string indent = "")
    {
        Console.WriteLine(indent + "-" + Name);

        foreach (var child in Children)
        {
            child.PrintChildren(indent + "-");
        }
    }

    // (De)Activation

    public virtual void Activate()
    {
        Active = true;

        foreach (Node child in Children)
        {
            child.Activate();
        }
    }

    public virtual void Deactivate()
    {
        Active = false;

        foreach (Node child in Children)
        {
            child.Deactivate();
        }
    }

    // Get special nodes

    public T GetParent<T>() where T : Node
    {
        if (Parent != null)
        {
            return (T)Parent;
        }

        return (T)this;
    }

    // Get node from the root

    public T GetNode<T>(string path) where T : Node
    {
        if (path == "")
        {
            return (T)Program.RootNode;
        }

        string[] nodeNames = path.Split('/');

        Node currentNode = Program.RootNode;

        for (int i = 0; i < nodeNames.Length; i++)
        {
            currentNode = currentNode.GetChild(nodeNames[i]);
        }

        return (T)currentNode;
    }

    public T GetNode<T>() where T : Node
    {
        string typeName = typeof(T).Name;
        return GetNode<T>(typeName);
    }

    public Node GetNode(string path)
    {
        if (path == "")
        {
            return Program.RootNode;
        }

        string[] nodeNames = path.Split('/');

        Node currentNode = Program.RootNode;

        for (int i = 0; i < nodeNames.Length; i++)
        {
            currentNode = currentNode.GetChild(nodeNames[i]);
        }

        return currentNode;
    }

    // Get child

    public T? GetChild<T>(string name) where T : Node
    {
        foreach (Node child in Children)
        {
            if (child.Name == name)
            {
                return (T)child;
            }
        }

        return null;
    }

    public T? GetChild<T>() where T : Node
    {
        foreach (Node child in Children)
        {
            if (child.GetType() == typeof(T))
            {
                return (T)child;
            }
        }

        return null;
    }

    public Node? GetChild(string name)
    {
        foreach (Node child in Children)
        {
            if (child.Name == name)
            {
                return child;
            }
        }

        return null;
    }

    // Add child

    public void AddChild(Node node, string name, bool start = true)
    {
        node.Name = name;
        node.Program = Program;
        node.Parent = this;

        node.Build();

        if (start)
        {
            node.Start();
        }

        Children.Add(node);
    }

    public void AddChild(Node node, bool start = true)
    {
        Console.WriteLine("- - - - - -");

        node.Name = node.GetType().Name;
        Console.WriteLine("set node name");

        node.Program = Program;
        Console.WriteLine("set node program");

        node.Parent = this;
        Console.WriteLine("set node parent");

        node.Build();
        Console.WriteLine("built node");

        if (start)
        {
            node.Start();
            Console.WriteLine("started node");
        }

        Children.Add(node);
        Console.WriteLine("fully added child");

    }

    // Change scene

    public void ChangeScene(Node node)
    {
        //Program.ResetView();
        Program.RootNode.Destroy();
        Program.RootNode = node;

        node.Name = node.GetType().Name;
        node.Program = Program;
        node.Start();
    }
}