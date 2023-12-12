using Intelligence;

namespace Intelligence.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        try 
        {
            var intelligence = new IntelligenceClientBuilder()
                .WithOpenAIModel("gpt-3.5-turbo")
                .WithOpenAIApiKey("sk...23")
                .Build();

            Assert.NotNull(intelligence);
        } 
        catch(IntelligenceException exIntelligence) 
        {
            Assert.Fail(exIntelligence.Message);
        }
    }
}