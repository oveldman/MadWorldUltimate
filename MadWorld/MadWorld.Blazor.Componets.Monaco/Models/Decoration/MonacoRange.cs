using System;
namespace MadWorld.Blazor.Componets.Monaco.Models.Decoration
{
	public record struct MonacoRange(int StartLineNumber, int StartColumnNumber, int EndLineNumber, int EndColumnNumber);
}

