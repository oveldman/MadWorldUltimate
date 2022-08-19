using System;
using MadWorld.Blazor.Components.Monaco.Models;
using MadWorld.Blazor.Components.Monaco.Models.Decoration;
using Microsoft.JSInterop;

namespace MadWorld.Blazor.Components.Monaco.Interop
{
    public class MonacoJs : IAsyncDisposable, IMonacoJs
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        private string[] _oldDecorations = Array.Empty<string>();

        public MonacoJs(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/MadWorld.Blazor.Components.Monaco/js/MadWorldMonacoEditor.js").AsTask());
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

        public async ValueTask SetDecorations(MonacoDecoration[] newDecorations)
        {
            var module = await moduleTask.Value;

            _oldDecorations = await module.InvokeAsync<string[]>("setDecorations", _oldDecorations, newDecorations);
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

                GC.SuppressFinalize(this);
            }
        }
    }
}

