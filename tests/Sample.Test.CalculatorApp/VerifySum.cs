using Sample.CalculatorApp;
using TestAccountability;

namespace Sample.Test.CalculatorApp;

public class VerifySum
{

	[Fact]
	[Feature("123", FeatureTracker = KnownFeatureTracker.GitHubIssues)]
	public void AddsTwoNumbers()
	{

		var addend1 = Random.Shared.Next();
		var addend2 = Random.Shared.Next();

		Assert.Equal(addend1+addend2, Calculator.Sum(addend1, addend2));

	}
}
