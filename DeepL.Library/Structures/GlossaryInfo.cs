﻿using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.DeepL.Structures;

/// <summary>
/// Glossary Info Structure
/// </summary>
[OSStructure(Description = "Glossary Info Structure")]
public struct GlossaryInfo
{
    [OSStructureField(
        Description = "Identifier of the glossary",
        DataType = OSDataType.Text)]
    public string Id;
    
    [OSStructureField(
        Description = "True if glossary is ready to use",
        DataType = OSDataType.Boolean)]
    public bool Ready;
    
    [OSStructureField(
        Description = "Name of the glossary",
        DataType = OSDataType.Text)]
    public string Name;
    
    [OSStructureField(
        Description = "Source Language Code",
        DataType = OSDataType.Text)]
    public string SourceLang;
    
    [OSStructureField(
        Description = "Target Language Code",
        DataType = OSDataType.Text)]
    public string TargetLang;
    
    [OSStructureField(
        Description = "Date and time of creation",
        DataType = OSDataType.DateTime)]
    public DateTime CreatedOn;
    
    [OSStructureField(
        Description = "Entry Count",
        DataType = OSDataType.Integer)]
    public int Count;
}