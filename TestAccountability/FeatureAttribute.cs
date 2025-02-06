namespace TestAccountability;

/// <summary>
/// Decorate your test methods with this attribute to indicate that the test is verifying a specific feature.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class FeatureAttribute : AccountabilityAttribute
{

	/// <summary>
	/// Initializes a new instance of the <see cref="FeatureAttribute"/> class.
	/// </summary>
	/// <param name="featureId">The identifier for the feature</param>
	public FeatureAttribute(string featureId)
	{
		FeatureId = featureId;
	}

	/// <summary>
	/// The unique identifier of the feature that this test is verifying.
	/// </summary>
	public string FeatureId { get; }

	/// <summary>
	/// The project planning tool that is being used to track the feature.
	/// </summary>
	public KnownFeatureTracker FeatureTracker { get; set; }

	/// <summary>
	/// The URL to the feature tracker that is being used to track the feature.
	/// </summary>
	public string? FeatureTrackerUrl { get; set; }

}
