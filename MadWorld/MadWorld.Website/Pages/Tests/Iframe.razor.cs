using MadWorld.Website.Parts;
using MadWorld.Website.Parts.Models;

namespace MadWorld.Website.Pages.Tests;

public partial class Iframe
{
    private string _url = string.Empty;
    private bool _showIFrame;
    private bool _showUrlError;
    
    private AlertStatus Status = new();
    private BootstrapAlerts _bootstrapAlerts = new();

    private void OpenIFrame()
    {
        _bootstrapAlerts.Reset();
        var validUrl = Uri.IsWellFormedUriString(_url, UriKind.Absolute);
        _showIFrame = validUrl;
        Status.ShowMessage = !validUrl;
        if (Status.ShowMessage)
        {
            Status.ErrorMessage = "Given url is not valid. ";   
        }
    }
}