namespace TestAccountability;

/// <summary>
/// Decorate your test methods with this attribute to indicate that the test is verifying a specific issue.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class IssueAttribute : AccountabilityAttribute
{

	/// <summary>
	/// Initializes a new instance of the <see cref="IssueAttribute"/> class.
	/// </summary>
	/// <param name="issue">The issue number.</param>
	public IssueAttribute(string issue)
	{
		Issue = issue;
	}

	/// <summary>
	/// The unique identifier of the issue/bug that this test is verifying.
	/// </summary>
	public string Issue { get; }

	/// <summary>
	/// The issue tracker that is being used to track the issue.
	/// </summary>
	public KnownIssueTracker IssueTracker { get; set; }

	/// <summary>
	/// The URL to the issue tracker that is being used to track the issue.
	/// </summary>
	public string? IssueTrackerUrl { get; set; }

}
