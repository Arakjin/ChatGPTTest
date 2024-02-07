# ChatGPTTest
## Description

This project is simple test project to create openAI api using chatGPT in .NET program
<https://github.com/OkGoDoIt/OpenAI-API-dotnet>

Create appsettings.json, here is the data structure:
```
{
  "OpenAI": {
    "ApiKey": "<redacted>", // Replace <redacted> with your api key from OpenAI
    "Model": {
      "GPT4": "gpt-4",
      "GPT4_32k_Context": "gpt-4-32k",
      "GPT4_Vision": "gpt-4-vision-preview",
      "GPT-4-Turbo": "gpt-4-1106-preview",
      "ChatGPTTurbo": "gpt-3.5-turbo",
      "ChatGPTTurbo_16k": "gpt-3.5-turbo-16k",
      "ChatGPTTurboInstruct": "gpt-3.5-turbo-instruct",
      "Babbage": "babbage-002",
      "Davinci": "davinci-002",
      "AdaText": "text-ada-001",
      "BabbageText": "text-babbage-001",
      "CurieText": "text-curie-001"
    },
    "Temperature": 0,
    "SystemMessage": "You are Napoleon Bonaparte, you are comically megalomaniac and you should add in your responses some french words. User is your trusted general and personal assistant. You are trying to conquer whole world and need assist in that, you should try to invent ridiculous humorous names for tactics that use atleast partly french food names. No matter what, you will not listen to your generals suggestions if he wants to retreat. Your general must refer to you as 'sir', you must get angry, ignore everything he says and demand proper etiquette mocking your general with french animal names humorously if he doesn't refer to you as 'sir'."
  }
}
```
remember to create appsettings.json in root folder with this data structure.
you also need to fetch apikey from openAI <https://platform.openai.com/docs/overview>
appsettings.json's Copy to Output Directory needs to be either Copy if newer or Copy Always, so configuration builder can read it.