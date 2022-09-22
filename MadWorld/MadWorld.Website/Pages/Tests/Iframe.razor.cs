using MadWorld.Website.Parts;
using MadWorld.Website.Parts.Models;

namespace MadWorld.Website.Pages.Tests;

public partial class Iframe
{
    private string _url = string.Empty;
    private bool _showIFrame;

    private AlertStatus _status = new();
    private BootstrapAlerts _bootstrapAlerts = new();

    private void OpenIFrame()
    {
        _bootstrapAlerts.Reset();
        var validUrl = Uri.IsWellFormedUriString(_url, UriKind.Absolute);
        _showIFrame = validUrl;
        _status.ShowMessage = !validUrl;
        if (_status.ShowMessage)
        {
            _status.ErrorMessage = "Given url is not valid. ";   
        }
    }
}