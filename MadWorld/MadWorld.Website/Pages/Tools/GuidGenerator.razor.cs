using System;
using MadWorld.Blazor.Componets.Monaco.Pages;

namespace MadWorld.Website.Pages.Tools
{
	public partial class GuidGenerator
	{
		private MonacoEditor _editor;

		private async Task GenerateGuid()
        {
			string guid = Guid.NewGuid().ToString();
			string guid2 = Guid.NewGuid().ToString();
			string editorValue = $"{guid}{Environment.NewLine}{guid2}";
			await _editor.SetValue(editorValue);
        }
	}
}

