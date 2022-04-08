using System;
using Microsoft.JSInterop;

namespace MadWorld.Blazor.Componets.Monaco.Interop
{
    public class MonacoJs : IAsyncDisposable, IMonacoJs
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public MonacoJs(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/MadWorld.Blazor.Componets.Monaco/MadWorldMonacoEditor.js").AsTask());
        }

        public async ValueTask<string> Init(string divID)
        {
            var module = await moduleTask.Value;

            return await module.InvokeAsync<string>("init", divID);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}

