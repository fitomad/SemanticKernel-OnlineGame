namespace Intelligence;

public interface IIntelligenceClientBuilder
{
    public IIntelligenceClientBuilder WithOpenAIModel(string modelName);
    public IIntelligenceClientBuilder WithOpenAIApiKey(string apiKey);
    public IIntelligenceClientBuilder WithOpenAIApiKey(string apiKey, string organizationId);
    public IntelligenceClient Build();
}