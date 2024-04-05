using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.DeepL;

public class DeepL : IDeepL
{
    public string Echo(string message)
    {
        return message;
    }
}