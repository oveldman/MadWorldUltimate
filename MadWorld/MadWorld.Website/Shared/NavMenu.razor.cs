using System;
namespace MadWorld.Website.Shared
{
	public partial class NavMenu
	{
        private bool collapseNavMenu = true;
        private bool collapseToolMenu = true;
        private bool collapseAdminMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        private string? ToolMenuArrow => collapseToolMenu ? "left" : "down";
        private string? AdminMenuArrow => collapseAdminMenu ? "left" : "bottom";

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        private void ToggleToolsMenu()
        {
            collapseToolMenu = !collapseToolMenu;
        }

        private void ToggleAdminMenu()
        {
            collapseAdminMenu = !collapseAdminMenu;
        }
    }
}

