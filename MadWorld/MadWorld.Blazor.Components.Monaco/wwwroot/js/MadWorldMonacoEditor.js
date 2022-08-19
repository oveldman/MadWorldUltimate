var MadWorldMonaco;
(function (MadWorldMonaco) {
    var MonacoDecoration = /** @class */ (function () {
        function MonacoDecoration() {
            this.test = "";
            this.startLineNumber = 0;
            this.startColumnNumber = 0;
            this.endLineNumber = 0;
            this.endColumnNumber = 0;
            this.isWholeLine = false;
            this.glyphMarginClassName = "";
            this.linesDecorationsClassName = "";
        }
        return MonacoDecoration;
    }());
    MadWorldMonaco.MonacoDecoration = MonacoDecoration;
    var MonacoEditor = /** @class */ (function () {
        function MonacoEditor() {
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
        MonacoEditor.prototype.setDecorations = function (oldDecorationIds, newDecorations) {
            return this.editor.deltaDecorations(oldDecorationIds, [
                {
                    range: new window.monaco.Range(newDecorations[0].startLineNumber, newDecorations[0].startColumnNumber, newDecorations[0].endLineNumber, newDecorations[0].endColumnNumber),
                    options: {
                        isWholeLine: newDecorations[0].isWholeLine,
                        linesDecorationsClassName: newDecorations[0].linesDecorationsClassName,
                        glyphMarginClassName: newDecorations[0].glyphMarginClassName
                    }
                }
            ]);
        };
        MonacoEditor.prototype.setValue = function (text) {
            this.editor.getModel().setValue(text);
        };
        return MonacoEditor;
    }());
    MadWorldMonaco.MonacoEditor = MonacoEditor;
})(MadWorldMonaco || (MadWorldMonaco = {}));
var monacoEditor;
export function init(divID, language) {
    CreateNewEditorIfEmpty();
    return monacoEditor.init(divID, language);
}
export function getValue() {
    CreateNewEditorIfEmpty();
    return monacoEditor.getValue();
}
export function setDecorations(oldDecorationIds, newDecorations) {
    CreateNewEditorIfEmpty();
    return monacoEditor.setDecorations(oldDecorationIds, newDecorations);
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