using System;
using Radzen;

namespace MadWorld.Website.Pages.Admin.Info
{
	public partial class EditStory
	{
		private string _body { get; set; } = string.Empty;

        private void OnPaste(HtmlEditorPasteEventArgs args)
        {
            Console.WriteLine($"Paste: {args.Html}");
        }

        private void OnChange(string html)
        {
            Console.WriteLine($"Change: {html}");
        }

        private void OnExecute(HtmlEditorExecuteEventArgs args)
        {
            Console.WriteLine($"Execute: {args.CommandName}");
        }
    }
}

