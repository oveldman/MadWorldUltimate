using System;
using MadWorld.Blazor.Components.Monaco.Models;
using MadWorld.Blazor.Components.Monaco.Models.Decoration;

namespace MadWorld.Blazor.Components.Monaco.Interop
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

