# OutSystems Developer Cloud DeepL External Logic Connector Library

DeepL is based on the official .net SDK by [DeepL](https://www.deepl.com). It wraps the following features

* **Translate Text** - translates one or more given texts to a specified target language
* **Translate Document** - translates a given Microsoft Office or PDF document to a specified target language
* **Manage glossaries** - several actions to create and manage language pair glossaries.

## Actions
The library exposes the following actions

### GetAccountUsage
Retrieves account usage metrics of the DeepL account

**Input parameters**

* `authKey` - DeepL API Key

**Result**

* `DeepLAccountUsage` - Structure with usage metrics

### TranslateText

Translate text to a specified and supported target language

**Input parameters**

* `authKey` - DeepL API Key
* `texts` - Array of texts to be translated. Each input array item results in one output array item of translated text.
* `sourceLang` - Optional. The source language code of the input texts. See [Deepl API Documentation](https://developers.deepl.com/docs) for possible values.
* `targetLang` - The target language to which the texts should be translated to. See [Deepl API Documentation](https://developers.deepl.com/docs) for possible values.
* `glossaryId` - Optional. The identifier of a glossary to use during translation.
* `preserveFormatting` - Sets whether the translation engine should respect the original formatting, even if it would usually correct some aspects.
* `formality` - Sets whether the translated text should lean towards formal or informal language. Only works with some target languages.
* `tagHandling` - Sets which kind of tags should be handled. Xml and Html supported.

**Result**

* `List of DeepLTextTranslation` - List of DeepLTextTranslation structure with translated text and detected source language.

### TranslateDocument

Translate a document to a specified and supported target language

* `authKey` - DeepL API Key
* `inputFile` - Binary data of the document to be translated.
* `inputFileName` - Original filename of the document to be translated.
* `sourceLang` - Optional. The source language code of the input texts. See [Deepl API Documentation](https://developers.deepl.com/docs) for possible values.
* `targetLang` - The target language to which the texts should be translated to. See [Deepl API Documentation](https://developers.deepl.com/docs) for possible values.
* `glossaryId` - Optional. The identifier of a glossary to use during translation.
* `formality` - Sets whether the translated text should lean towards formal or informal language. Only works with some target languages.

**Result**

* `translatedDocument` - Translated document binary data.

Create a new glossary

**Input parameters**

* `authKey` - DeepL API Key
* `name` - Name of the glossary
* `sourceLang` - The language in which the source texts in the glossary are specified
* `targetLang` - The language in which the target texts in the glossary are specified
* `entries` - A structure with a source language entry and an associated target language entry

**Result**

* `glossaryInfo` - A structure containing details of the created glossary

### DeleteGlossary

Permanently deletes a glossary

**Input parameters**

* `authKey` - DeepL API Key
* `glossaryId` - Identifier of the glossary to delete

### GetGlossaryDetails

Retrieve details of a glossary

**Input parameters**

* `authKey` - DeepL API Key
* `glossaryId` - Identifier of the glossary to delete

**Result**

* `glossaryInfo` - A structure containing details of the requested glossary

### GetGlossaryEntries

Retrieve the glossary entries of a glossary


**Input parameters**

* `authKey` - DeepL API Key
* `glossaryId` - Identifier of the glossary to delete

**Result**

* `glossaryEntries` - List of glossary entries

### ListGlossaries

Retrieve all glossaries in the account


**Input parameters**

* `authKey` - DeepL API Key

**Result**

* `glossaries` - List of glossary details

### GetSourceLanguages

Returns supported languages as source

**Input parameters**

* `authKey` - DeepL API Key

**Result**

* `sourceLanguages` - List of available languages as source with language code and name

### GetTargetLanguages

Returns supported languages as target

**Input parameters**

* `authKey` - DeepL API Key

**Result**

* `targetLanguages` - List of available languages as target with language code, name and support for formality option

Check the demo application on how to apply the features in your application.

# Run Tests

To run the nUnit tests you first have to provide your DeepL API Key as a secret

* Open a command prompt in the test project and run

```powershell
dotnet user-secrets init
dotnet user-secrets set DeepLAPIKey "<your api key>"
```

You can also set the DeepLAPIKey as an environment variable

