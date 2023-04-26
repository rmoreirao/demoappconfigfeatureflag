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
            FeatureFlagEnabledMessage = $"Consuming API Version ";
            // Check if the feature flag is enabled.
            if (_featureManager.IsEnabledAsync(FeatureName).Result)
            {
                FeatureFlagEnabledMessage = FeatureFlagEnabledMessage + "V1";
            }
            else
            {
                FeatureFlagEnabledMessage = FeatureFlagEnabledMessage + "V2";
            }   
        }
    }
}
