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
			string jsonText = await _editor.GetValue();
			JsonDocument jsonDoc = JsonDocument.Parse(jsonText);
			string formattedJson = JsonSerializer.Serialize(jsonDoc, new JsonSerializerOptions { WriteIndented = true });
			await _editor.SetValue(formattedJson);
		}
	}
}

