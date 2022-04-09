
if (!require.getConfig().paths.vs)  // for lte v1.2.0
	require.config({ paths: { 'vs': '_content/MadWorld.Blazor.Componets.Monaco/lib/monaco/min/vs' } });

var editor;

export function init(divID) {
	editor = monaco.editor.create(document.getElementById(divID), {
		value: "",
		language: 'plaintext',
		theme: 'vs-dark'
	});
}

export function setValue(text) {
	editor.getModel().setValue(text);
}
