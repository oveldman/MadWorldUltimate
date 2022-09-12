using System.Net;
using HtmlAgilityPack;
using MadWorld.Blazor.Components.Monaco.Models;
using MadWorld.Blazor.Components.Monaco.Pages;

namespace MadWorld.Website.Pages.Tools
{
	public partial class HtmlValidator
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
				Language = "html"
			};

			base.OnInitialized();
		}

		private async Task EncodeHtml()
		{
			Reset();
			string htmlText = await _editor.GetValue();
			string encodedHtml = WebUtility.HtmlEncode(htmlText);
			await _editor.SetValue(encodedHtml);
		}

		private async Task DecodeHtml()
		{
			Reset();
			string htmlText = await _editor.GetValue();
			string decodedHtml = WebUtility.HtmlDecode(htmlText);
			await _editor.SetValue(decodedHtml);
		}

		private async Task ValidateHtml()
		{
			Reset();
			string htmlText = await _editor.GetValue();

			var htmlDoc = new HtmlDocument()
			{
				BackwardCompatibility = false
			};

			htmlDoc.LoadHtml(htmlText);

			if (htmlDoc.ParseErrors.Any())
            {
				ShowError(htmlDoc.ParseErrors);
				return;
            }

			showSuccess = true;
		}

		private void Reset()
		{
			showSuccess = false;
			showError = false;
		}

		private void ShowError(IEnumerable<HtmlParseError> errors)
		{
			if (errors is null)
            {
				return;
            }

			var firstError = errors.First();

			showError = true;
			errorMessage = $"{firstError.Reason}. (Line {firstError.Line}, Position {firstError.LinePosition})";
		}
	}
}

