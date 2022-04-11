using System;
using MadWorld.Blazor.Componets.Monaco.Models;

namespace MadWorld.Blazor.Componets.Monaco.Interop
{
	public interface IMonacoJs
	{
		ValueTask Init(string divID, MonacoSettings settings);
		ValueTask<string> GetValue();
		ValueTask SetValue(string text);
		ValueTask DisposeAsync();
	}
}

