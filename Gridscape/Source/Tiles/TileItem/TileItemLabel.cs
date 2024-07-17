using Raylib_cs;

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
        float availableWidth = (Parent as TileItem).Button.Size.X - 50;
        float characterWidth = GetTextWidth(" ");
        int numFittingCharacters = (int)(availableWidth / characterWidth);

        // Ensure numFittingCharacters does not exceed the length of originalText
        if (numFittingCharacters > originalText.Length)
        {
            numFittingCharacters = originalText.Length;
        }

        string trimmedText = originalText.Substring(0, numFittingCharacters);
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
        string trimmedText = input.Substring(0, input.Length - 3);
        return trimmedText + "...";
    }
}