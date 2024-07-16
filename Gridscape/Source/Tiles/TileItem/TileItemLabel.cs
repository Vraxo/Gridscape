﻿using Raylib_cs;

namespace Gridscape;

public class TileItemLabel : Label
{
    private string originalText;

    public override void Ready()
    {
        originalText = Text;
    }

    public override void Update()
    {
        float avaiableSpace = (Parent as TileItem).Button.Size.X - 50;
        float characterWidth = GetTextWidth(" ");
        float numFittingCharacters = avaiableSpace / characterWidth;

        string trimmedText = originalText.Substring(0, (int)numFittingCharacters);

        Text = ReplaceLastThreeWithDots(trimmedText);

        base.Update();
    }

    private float GetTextWidth(string text)
    {
        float width = Raylib.MeasureTextEx(
            Font,
            text,
            FontSize,
            1).X;

        return width;
    }

    private static string ReplaceLastThreeWithDots(string input)
    {
        return input.Substring(0, input.Length - 3) + "...";
    }
}