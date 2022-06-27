var MadWorldMonaco;
(function (MadWorldMonaco) {
    var MonacoDecorationOptions = /** @class */ (function () {
        function MonacoDecorationOptions() {
            this.isWholeLine = false;
            this.linesDecorationsClassName = "";
        }
        return MonacoDecorationOptions;
    }());
    MadWorldMonaco.MonacoDecorationOptions = MonacoDecorationOptions;
    var MonacoRange = /** @class */ (function () {
        function MonacoRange() {
            this.startLineNumber = 0;
            this.startColumnNumber = 0;
            this.endLineNumber = 0;
            this.endColumnNumber = 0;
        }
        return MonacoRange;
    }());
    MadWorldMonaco.MonacoRange = MonacoRange;
    var MonacoDecoration = /** @class */ (function () {
        function MonacoDecoration() {
            this.test = "";
            this.range = new MonacoRange();
            this.options = new MonacoDecorationOptions();
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
            alert(newDecorations.length + ' lol');
            alert(newDecorations[0].options);
            alert(newDecorations[0].test);
            return this.editor.deltaDecorations(oldDecorationIds, newDecorations);
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