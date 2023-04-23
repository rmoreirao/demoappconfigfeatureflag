using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace TestAppConfig.Pages
{
    public class BetaPageIfStatementModel : PageModel
    {
        private readonly ILogger<BetaPageIfStatementModel> _logger;
        private readonly IFeatureManager _featureManager;
        const string FeatureName = "BetaPageIfStatement";

        public string? FeatureFlagEnabledMessage { get; set; }

        public BetaPageIfStatementModel(ILogger<BetaPageIfStatementModel> logger, IFeatureManager featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        public void OnGet()
        {
            // Check if the feature flag is enabled.
            if (_featureManager.IsEnabledAsync(FeatureName).Result)
            {
                FeatureFlagEnabledMessage = $"Feature flag {FeatureName} is enabled.";
            }
            else
            {
                FeatureFlagEnabledMessage = $"Feature flag {FeatureName} is disabled.";
            }   
        }
    }
}
