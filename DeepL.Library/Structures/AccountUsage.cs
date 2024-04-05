using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.DeepL.Structures;

/// <summary>
/// Account Usage Structure
/// </summary>
[OSStructure(
    Description = "Account Usage Structure")]
public struct AccountUsage
{
    [OSStructureField(
        Description = "Characters translated so far in the current billing period",
        DataType = OSDataType.Integer)]
    public int CharacterCount;

    [OSStructureField(
        Description = "Current maximum number of characters that can be translated per billing period",
        DataType = OSDataType.Integer)]
    public int CharacterLimit;

    [OSStructureField(
        Description = "Documents translated so far in the current billing period",
        DataType = OSDataType.Integer)]
    public int DocumentLimit;
    
    [OSStructureField(
        Description = "Current maximum number of documents that can be translated per billing period",
        DataType = OSDataType.Integer)]
    public int DocumentCount;
}