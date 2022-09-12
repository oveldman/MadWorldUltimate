using System.Text.Json;
using System.Xml.Linq;
using MadWorld.Blazor.Components.Monaco.Models;
using MadWorld.Blazor.Components.Monaco.Pages;

namespace MadWorld.Website.Pages.Tools;

public partial class XmlValidator
{
    		private MonacoEditor _editor = new();
    		private MonacoSettings _settings = new();
    
    		private bool showSuccess = false;
    		private bool showError = false;
    		private string errorMessage = string.Empty;
    
            protected override void OnInitialized()
            {
    			_settings = new MonacoSettings
                {
    				Language = "xml"
    			};
    
                base.OnInitialized();
            }
    
            private async Task FormatXml()
            {
    			Reset();
    			var xmlText = await _editor.GetValue();
    
    			if (!IsXmlValid(xmlText, out var xmlFormatted))
    			{
    				return;
                }
    
    			if (string.IsNullOrEmpty(xmlText)) return;
                
                await _editor.SetValue(xmlFormatted);
    		}

            private async Task ValidateXml()
            {
    			Reset();
    			var xmlText = await _editor.GetValue();
    			IsXmlValid(xmlText, out _);
    		}
    
    		private bool IsXmlValid(string xmlText, out string xmlFormatted)
            {
    			try
    			{
	                xmlFormatted = XDocument.Parse(xmlText).ToString();
    				showSuccess = true;
    				return true;
    			}
    			catch (Exception xmlException)
    			{
    				ShowError(xmlException);
                    xmlFormatted = string.Empty;
    				return false;
    			}
    		}
    
    		private void Reset()
            {
    			showSuccess = false;
    			showError = false;
            }
    
    		private void ShowError(Exception exception)
            {
    			showError = true;
    			errorMessage = exception.Message;
    		}

            private async Task Test()
            {
    			await _editor.SetDecorations();
            }
}