using Raylib_cs;

namespace Gridscape;

class TextureLoader
{
    public Dictionary<string, Texture2D> Textures = [];

    private static TextureLoader? instance;

    public static TextureLoader Instance
    {
        get
        {
            instance ??= new();
            return instance;
        }
    }

    private TextureLoader()
    {
        Textures.Add("DefaultTexture", Raylib.LoadTexture("Resources/DefaultTexture.png"));
    }
}