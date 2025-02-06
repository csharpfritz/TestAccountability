namespace Sample.CalculatorApp;

public class Calculator
{

	public static int Sum(params int[] nums)
	{

		int sum = 0;
		foreach (int i in nums)
		{
			sum += i;
		}

		return sum;

	}

}
