using Microsoft.Extensions.Configuration;

namespace Without.Systems.DeepLTranslate.Test;

public class Tests
{
    private static readonly IOSDeepL _actions = new OSDeepL();

    private string DeepLAPIKey;

    [SetUp]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<Tests>()
            .AddEnvironmentVariables()
            .Build();
        
        DeepLAPIKey = configuration["DeepLAPIKey"] ?? throw new InvalidOperationException();
    }

    [Test]
    public void Translate_HelloWorld()
    {
        List<string> texts = new List<string> { "Ich möchte einmal gemeinsam mit dir die Welt bereisen"};
        string language = "en-us";
        string expected = "I would like to travel the world with you one day";

        var result = _actions.TranslateText(DeepLAPIKey, texts, language);
        
        Assert.That(result.FirstOrDefault().Text, Is.EqualTo(expected));
    }

    [Test]
    public void Translate_Document()
    {
        var inputDocument = File.ReadAllBytes(@"docs\AGB.pdf");
        var result = _actions.TranslateDocument(DeepLAPIKey, inputDocument, "agb.pdf", "de", "en-us", null, "default");

        File.WriteAllBytes(@"c:\dev\AGB_US.pdf", result);
    }
}