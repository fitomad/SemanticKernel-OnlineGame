namespace Intelligence;

public sealed class IntelligenceClientBuilder: IIntelligenceClientBuilder
{
    private Settings settings = new();

    public IIntelligenceClientBuilder WithOpenAIModel(string modelName)
    {
        settings.Model = modelName;
        return this;
    }

    public IIntelligenceClientBuilder WithOpenAIApiKey(string apiKey)
    {
        settings.ApiKey = apiKey;
        return this;
    }

    public IIntelligenceClientBuilder WithOpenAIApiKey(string apiKey, string organizationId)
    {
        settings.OrganizationId = organizationId;
        return this;
    }

    public IntelligenceClient Build() 
    {
        if(string.IsNullOrEmpty(settings.Model))
        {
            throw new IntelligenceException("You must set an OpenAI model name.");
        }

        if(string.IsNullOrEmpty(settings.ApiKey))
        {
            throw new IntelligenceException("You need an OpenAI valid api key.");
        }

        var client = new IntelligenceClient(settings: settings);
        return client;
    }
}