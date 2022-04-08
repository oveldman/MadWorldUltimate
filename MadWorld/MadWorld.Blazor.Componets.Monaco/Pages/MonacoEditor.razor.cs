using Microsoft.AspNetCore.Components;

namespace MadWorld.Blazor.Componets.Monaco.Pages
{
	public partial class MonacoEditor
	{
        [Parameter]
        public string Height { get; set; } = "400";

        private string EditorID = string.Empty;
        private string HeightPixels {
            get
            {
                return Height + "px";
            }
        }

        protected override void OnInitialized()
        {
            EditorID = "MonacoEditor" + Guid.NewGuid().ToString().Replace("-", "");
        }

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                await _monacoJS.Init(EditorID);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
	}
}

