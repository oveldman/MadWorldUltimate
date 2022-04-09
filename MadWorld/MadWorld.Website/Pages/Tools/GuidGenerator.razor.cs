using System;
using MadWorld.Blazor.Componets.Monaco.Pages;

namespace MadWorld.Website.Pages.Tools
{
	public partial class GuidGenerator
	{
		private MonacoEditor _editor;

		private int amountOfGuids = 0;

		private async Task GenerateGuid()
        {
			ValidateAmountOfGuids();

			string newEditorValue = string.Empty;
			bool isFirstGuid = true;

			for (int i = 0; i < amountOfGuids; i++)
            {
				newEditorValue = AddNewGuidToString(newEditorValue, isFirstGuid);
				isFirstGuid = false;
			}

			await _editor.SetValue(newEditorValue);
        }

		private void ValidateAmountOfGuids()
        {
			if (amountOfGuids < 0)
            {
				amountOfGuids = 0;
            }

			if (amountOfGuids > 10000)
            {
				amountOfGuids = 10000;
            }
        }

		private string AddNewGuidToString(string value, bool isFirstGuid)
        {
			if (!isFirstGuid)
			{
				value += Environment.NewLine;
			}

			value += Guid.NewGuid().ToString();

			return value;
		}
	}
}

