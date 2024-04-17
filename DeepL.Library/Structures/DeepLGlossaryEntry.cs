using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.DeepLTranslate.Structures;

/// <summary>
/// Glossary Entry Structure
/// </summary>
[OSStructure(Description = "Single glossary entry")]
public struct DeepLGlossaryEntry
{
    
    /// <summary>
    /// Source Language Entry
    /// </summary>
    [OSStructureField(
        Description = "Source Language Entry",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Source;

    /// <summary>
    /// Target Language Entry
    /// </summary>
    [OSStructureField(
        Description = "Target Language Entry",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Target;

    public DeepLGlossaryEntry(string source, string target)
    {
        Source = source;
        Target = target;
    }
}