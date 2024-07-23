﻿using Raylib_cs;

namespace Gridscape;

public class TextBox : ClickableRectangle
{
    public string Text = "";
    public string DefaultText = "";
    public int MaxCharacters = int.MaxValue;
    public int MinCharacters = 0;
    public List<char> AllowedCharacters = [];
    public TextBoxStyle Style = new();
    public bool Selected = false;
    public bool Editable = true;
    public bool RevertToDefaultText = true;
    public bool TemporaryDefaultText = true;
    public Action<TextBox> OnUpdate = (textBox) => { };
    public event EventHandler<string>? TextChanged;
    public event EventHandler<string>? Confirmed;

    private const int minAscii = 32;
    private const int maxAscii = 125;
    private TextBoxCaret caret;

    public override void Ready()
    {
        AddChild(new TextBoxShape
        {
            Size = Size,
            Origin = Origin,
            OriginPreset = OriginPreset,
            Style = Style,
        });

        AddChild(new TextBoxText
        {
            Origin = Origin,
            OriginPreset = OriginPreset,
            Style = Style,
        });

        caret = new();
        AddChild(caret);
    }

    public override void Update()
    {
        HandleInput();
        PasteText();
        OnUpdate(this);
        base.Update();
    }

    //public override bool IsMouseOver()
    //{
    //    Vector2 mousePosition = Raylib.GetMousePosition();
    //
    //    bool isMouseOver = mousePosition.X > GlobalPosition.X - Origin.X &&
    //                       mousePosition.X < GlobalPosition.X + Size.X - Origin.X &&
    //                       mousePosition.Y > GlobalPosition.Y - Origin.Y &&
    //                       mousePosition.Y < GlobalPosition.Y + Size.Y - Origin.Y;
    //
    //    return isMouseOver;
    //}

    private void HandleInput()
    {
        if (!Editable)
        {
            return;
        }

        CheckForClicks();

        if (!Selected)
        {
            return;
        }

        GetTypedCharacters();
        DeleteLastCharacter();
        Confirm();
    }

    private void CheckForClicks()
    {
        if (IsMouseOver())
        {
            //Style.Current = Style.Hover;

            if (Raylib.IsMouseButtonDown(MouseButton.Left) && OnTopLeft)
            {
                Selected = true;
                Style.Current = Style.Selected;
            }
        }
        else
        {
            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                Selected = false;
                Style.Current = Style.Deselected;
            }
        }
    }

    private void GetTypedCharacters()
    {
        int key = Raylib.GetCharPressed();

        while (key > 0)
        {
            InsertCharacter(key);
            key = Raylib.GetCharPressed();
        }
    }

    private void InsertCharacter(int key)
    {
        bool isKeyInRange = key >= minAscii && key <= maxAscii;

        if (isKeyInRange && (Text.Length < MaxCharacters))
        {
            if (AllowedCharacters.Count > 0)
            {
                if (!AllowedCharacters.Contains((char)key))
                {
                    return;
                }
            }

            if (TemporaryDefaultText && Text == DefaultText)
            {
                Text = "";
            }

            if (caret.X < 0 || caret.X > Text.Length)
            {
                caret.X = Text.Length;
            }

            Text = Text.Insert(caret.X, ((char)key).ToString());
            caret.X ++;
            TextChanged?.Invoke(this, Text);
        }
    }

    private void DeleteLastCharacter()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Backspace))
        {
            if (Text.Length > 0 && caret.X > 0)
            {
                Text = Text.Remove(caret.X - 1, 1);
                caret.X --;
            }

            RevertTextToDefaultIfEmpty();

            TextChanged?.Invoke(this, Text);
        }
    }

    private void PasteText()
    {
        if (Raylib.IsKeyDown(KeyboardKey.LeftControl) && Raylib.IsKeyPressed(KeyboardKey.V))
        {
            char[] clipboardContent = [.. Raylib.GetClipboardText_()];

            foreach (char character in clipboardContent)
            {
                InsertCharacter(character);
            }
        }
    }

    private void Confirm()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Enter))
        {
            Selected = false;
            Style.Current = Style.Deselected;
            Confirmed?.Invoke(this, Text);
        }
    }

    private void RevertTextToDefaultIfEmpty()
    {
        if (Text.Length == 0)
        {
            Text = DefaultText;
        }
    }
}