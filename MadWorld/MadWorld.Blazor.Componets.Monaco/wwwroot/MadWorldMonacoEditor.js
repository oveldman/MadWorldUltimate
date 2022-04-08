
if (!require.getConfig().paths.vs)  // for lte v1.2.0
	require.config({ paths: { 'vs': '_content/MadWorld.Blazor.Componets.Monaco/lib/monaco/min/vs' } });

export function init(divID) {
	monaco.editor.create(document.getElementById(divID), {
		value: "",
		language: 'json',
		theme: 'vs-dark'
	});
}
