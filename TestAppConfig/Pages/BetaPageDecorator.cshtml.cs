using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement.Mvc;

namespace TestAppConfig.Pages
{
    // Beta page is accessible only when the Beta feature flag is enabled. If the Beta feature flag isn't enabled, the page will return 404 Not Found.
    [FeatureGate("BetaPageDecorator")]
    public class BetaPageDecoratorModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
