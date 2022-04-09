using System;
namespace MadWorld.Blazor.Componets.Monaco.Interop
{
	public interface IMonacoJs
	{
		ValueTask<string> Init(string divID);
		ValueTask<string> SetValue(string text);
		ValueTask DisposeAsync();
	}
}

