using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AI.TextToImage;
using Microsoft.Extensions.Logging;


using Intelligence.Plugins;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata.Ecma335;

namespace Intelligence;

public interface IIntelligenceClient
{
    public Task<string> Perform(string userPrompt, string history);
    public Task<string> GetDescription(string gameName, string genre);
    public Task<string> GetImage(string description);
}

public sealed class IntelligenceClient: IIntelligenceClient
{
    private Kernel kernel;
    private IKernelPlugin _gamePlugin;
    private IKernelPlugin _backpackPlugin;

    internal IntelligenceClient(Settings settings)
    {
        var builder = new KernelBuilder();

        builder.AddOpenAIChatCompletion(
            settings.Model, // OpenAI Model name
            settings.ApiKey // OpenAI API Key
        );

        #pragma warning disable SKEXP0012
        // Parece que antes de la versión 1.0 habrá cambios en esta función
        // en particular o en la forma de trabajar con DALL·E en general.
        builder.AddOpenAITextToImage(
            settings.ApiKey
        );

        builder.Services.AddLogging(loggerFactory => {
            loggerFactory
                .SetMinimumLevel(0)
                .AddDebug()
                .AddConsole();
        });

        kernel = builder.Build();
        
        // Import the semantic functions
        var pluginsDirectory = Directory.GetCurrentDirectory();
        pluginsDirectory = Path.Combine(pluginsDirectory, "Plugins");
        _gamePlugin = kernel.ImportPluginFromPromptDirectory(pluginsDirectory);
        // Import the native functions
        _backpackPlugin = kernel.ImportPluginFromType<Backpack>("BackpackPlugin");
    }

    public async Task<string> Perform(string userPrompt, string history)
    {
        var arguments = new KernelArguments();
        arguments["history"] = history;
        arguments["userPrompt"] = userPrompt;

        var result = await kernel.InvokeAsync(_gamePlugin["GameTurn"], arguments);
        
        return result.GetValue<string>() ?? "NADA";
    }

    public async Task<string> GetDescription(string gameName, string genre)
    {
        var arguments = new KernelArguments();
        arguments["gameName"] = gameName;
        arguments["gameGenre"] = genre;

        var result = await kernel.InvokeAsync(_gamePlugin["GameDescription"], arguments);
        return result.GetValue<string>() ?? "Descripción no disponible en este momento.";
    }

    public async Task<string> GetImage(string description)
    {
        #pragma warning disable SKEXP0002
        ITextToImageService dallE = kernel.GetRequiredService<ITextToImageService>();
        string image = await dallE.GenerateImageAsync(description, 512, 512);
        
        return image;
    }
}
