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
        float characterWidth = GetCharacterWidth();
        int numFittingCharacters = (int)(availableWidth / characterWidth);

        // Ensure numFittingCharacters does not exceed the length of originalText
        if (numFittingCharacters < originalText.Length)
        {
            //numFittingCharacters = originalText.Length;
            string trimmedText = originalText.Substring(0, numFittingCharacters);
            Text = ReplaceLastThreeWithDots(trimmedText);
        }
        else
        {
            Text = originalText;
        }

        base.Update();
    }

    private float GetCharacterWidth()
    {
        float width = Raylib.MeasureTextEx(
            Font,
            " ",
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