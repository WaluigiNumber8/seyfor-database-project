using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class CloseContentBrowserCommand : CommandBase
    {
        private readonly IServiceContentBrowser _browserService;

        public CloseContentBrowserCommand(IServiceContentBrowser browserService)
        {
            _browserService = browserService;
        }

        public override void Execute(object? parameter)
        {
            _browserService.Close();
        }
    }
}