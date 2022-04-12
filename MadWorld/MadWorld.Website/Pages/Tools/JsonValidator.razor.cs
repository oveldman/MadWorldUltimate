using System;
using System.Text.Json;
using MadWorld.Blazor.Componets.Monaco.Models;
using MadWorld.Blazor.Componets.Monaco.Pages;

namespace MadWorld.Website.Pages.Tools
{
	public partial class JsonValidator
	{
		private MonacoEditor _editor;
		private MonacoSettings _settings = new();

		private bool showSuccess = false;
		private bool showError = false;
		private string errorMessage = string.Empty;

        protected override void OnInitialized()
        {
			_settings = new()
			{
				Language = "json"
			};

            base.OnInitialized();
        }

        private async Task FormatJson()
        {
			Reset();
			string jsonText = await _editor.GetValue();

			if (string.IsNullOrEmpty(jsonText)) return;

			JsonDocument jsonDoc = JsonDocument.Parse(jsonText);
			string formattedJson = JsonSerializer.Serialize(jsonDoc, new JsonSerializerOptions { WriteIndented = true });
			await _editor.SetValue(formattedJson);
		}

		private async Task ValidateJson()
        {
			Reset();
			string jsonText = await _editor.GetValue();

			try
			{
				JsonDocument.Parse(jsonText);
				showSuccess = true;
			}
			catch (JsonException jsonException)
			{
				ShowError(jsonException);
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
	}
}

