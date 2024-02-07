using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        var apiKey = configuration["OpenAI:ApiKey"];
        var model = new Model(configuration["OpenAI:Model:GPT-4-Turbo"]);
        var temperature = Convert.ToDouble(configuration["OpenAI:Temperature"]);
        var systemMessage = configuration["OpenAI:SystemMessage"];
        // Set up your OpenAI API key
        var api = new OpenAIAPI(apiKey);
        var chat = api.Chat.CreateConversation();
        chat.Model = new Model(model);
        chat.RequestParameters.Temperature = temperature;
        chat.AppendSystemMessage(systemMessage); //getfromjson
        // Welcome message
        Console.WriteLine("Welcome to the chat program!");
        Console.WriteLine("Type 'exit' to quit.\n");
        // Start the conversation
        var userMessage = GetInputFromUser();

        while (userMessage.ToLower() != "exit")
        {
            if (string.IsNullOrEmpty(userMessage))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Empty string");
                Console.ResetColor();
            }
            else
            {
                chat.AppendUserInput(userMessage);
                // Generate response from OpenAI
                var response = OpenAIResponse(chat).GetAwaiter().GetResult();

                // Display the response
                Console.WriteLine("AI: " + response);
                Console.ResetColor();
            }
            // Get the next user input
            userMessage = GetInputFromUser();
        }

        Console.WriteLine("Goodbye!");
        foreach (ChatMessage msg in chat.Messages)
        {
            Console.WriteLine($"{msg.Role}: {msg.TextContent}");
        }
    }

    static string? GetInputFromUser()
    {
        Console.Write("You: ");
        return Console.ReadLine();
    }

    static async Task<string> OpenAIResponse(Conversation chat)
    {
        try
        {
            var response = await chat.GetResponseFromChatbotAsync();
            Console.ForegroundColor = ConsoleColor.Green;
            return response;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Unexpected error occurred:\n" + ex.Message;
        }
    }
}