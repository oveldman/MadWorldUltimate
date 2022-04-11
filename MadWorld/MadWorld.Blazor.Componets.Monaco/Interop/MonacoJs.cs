using System;
using MadWorld.Blazor.Componets.Monaco.Models;
using Microsoft.JSInterop;

namespace MadWorld.Blazor.Componets.Monaco.Interop
{
    public class MonacoJs : IAsyncDisposable, IMonacoJs
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public MonacoJs(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/MadWorld.Blazor.Componets.Monaco/js/MadWorldMonacoEditor.js").AsTask());
        }

        public async ValueTask Init(string divID, MonacoSettings settings)
        {
            var module = await moduleTask.Value;

            await module.InvokeVoidAsync("init", divID, settings.Language);
        }

        public async ValueTask<string> GetValue()
        {
            var module = await moduleTask.Value;

            return await module.InvokeAsync<string>("getValue");
        }

        public async ValueTask SetValue(string text)
        {
            var module = await moduleTask.Value;

            await module.InvokeVoidAsync("setValue", text);
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

