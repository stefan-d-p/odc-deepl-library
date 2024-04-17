namespace Without.Systems.DeepLTranslate.Extensions;

internal static class DeepLExtensions
{
    public static Structures.DeepLGlossaryInfo ToDeepLGlossaryInfo(this DeepL.Model.GlossaryInfo info) =>
        new Structures.DeepLGlossaryInfo(
            info.GlossaryId, info.Ready, info.Name,
            info.SourceLanguageCode, info.TargetLanguageCode, info.CreationTime, info.EntryCount
        );

    public static Structures.DeepLAccountUsage ToDeepLAccountUsage(this DeepL.Model.Usage usage) =>
        new Structures.DeepLAccountUsage(usage.Character?.Count,
            usage.Character?.Limit,
            usage.Document?.Limit,
            usage.Document?.Count);

}