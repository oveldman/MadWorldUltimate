using System;
using MadWorld.Blazor.Componets.Monaco.Models;
using MadWorld.Blazor.Componets.Monaco.Models.Decoration;

namespace MadWorld.Blazor.Componets.Monaco.Interop
{
	public interface IMonacoJs
	{
		ValueTask Init(string divID, MonacoSettings settings);
		ValueTask<string> GetValue();
		ValueTask SetDecorations(MonacoDecoration[] newDecorations);
        ValueTask SetValue(string text);
		ValueTask DisposeAsync();
	}
}

