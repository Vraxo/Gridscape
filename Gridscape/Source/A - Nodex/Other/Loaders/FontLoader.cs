using Raylib_cs;

namespace Gridscape;

class FontLoader
{
    public Dictionary<string, Font> Fonts = [];

    private static FontLoader? instance;

    public static FontLoader Instance
    {
        get
        {
            instance ??= new();
            return instance;
        }
    }

    private FontLoader()
    {
        Fonts.Add("RobotoMono 32", Raylib.LoadFontEx("Resources/RobotoMono.ttf", 32, null, 0));
        Raylib.SetTextureFilter(Fonts["RobotoMono 32"].Texture, TextureFilter.Bilinear);
    }
}