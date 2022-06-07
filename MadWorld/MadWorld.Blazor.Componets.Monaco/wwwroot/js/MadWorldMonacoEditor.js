let MadWorldMonaco;
(function (MadWorldMonaco) {
    let MonacoEditor = /** @class */ (function () {
        function MonacoEditor() {
            return undefined; 
        }
        MonacoEditor.prototype.init = function (divID, language) {
            this.editor = window.monaco.editor.create(document.getElementById(divID), {
                value: "",
                language: language,
                theme: 'vs-dark'
            });
        };
        MonacoEditor.prototype.getValue = function () {
            return this.editor.getModel().getValue();
        };
        MonacoEditor.prototype.setValue = function (text) {
            this.editor.getModel().setValue(text);
        };
        return MonacoEditor;
    }());
    MadWorldMonaco.MonacoEditor = MonacoEditor;
})(MadWorldMonaco || (MadWorldMonaco = {}));
let monacoEditor;
export function init(divID, language) {
    CreateNewEditorIfEmpty();
    return monacoEditor.init(divID, language);
}
export function getValue(text) {
    CreateNewEditorIfEmpty();
    return monacoEditor.getValue();
}
export function setValue(text) {
    CreateNewEditorIfEmpty();
    return monacoEditor.setValue(text);
}
function CreateNewEditorIfEmpty() {
    if (monacoEditor == undefined) {
        monacoEditor = new MadWorldMonaco.MonacoEditor();
    }
}
//# sourceMappingURL=MadWorldMonacoEditor.js.map