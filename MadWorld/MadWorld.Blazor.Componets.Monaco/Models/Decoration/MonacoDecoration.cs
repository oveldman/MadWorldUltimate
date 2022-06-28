using System;
namespace MadWorld.Blazor.Componets.Monaco.Models.Decoration
{
	public class MonacoDecoration
	{
        public string test { get; set; }

        public int startLineNumber { get; set; }
        public int startColumnNumber { get; set; }
        public int endLineNumber { get; set; }
        public int endColumnNumber { get; set; }

        public bool isWholeLine { get; set; }
        public string glyphMarginClassName { get; set; } = string.Empty;
        public string linesDecorationsClassName { get; set; } = string.Empty;
    }
}

