namespace MadWorldMonaco {
    export class MonacoEditor {
        private editor: any;

        public init(divID: string, language: string): void {
            this.editor = (window as any).monaco.editor.create(document.getElementById(divID), {
                value: "",
                language: language,
                theme: 'vs-dark'
            });
        }

        public getValue(): string {
            return this.editor.getModel().getValue();
        }

        public setValue(text: string): void {
            this.editor.getModel().setValue(text);
        }
    }
}

let monacoEditor: MadWorldMonaco.MonacoEditor;

export function init(divID: string, language: string): void {
    CreateNewEditorIfEmpty();
    return monacoEditor.init(divID, language);
}

export function getValue(text: string): string {
    CreateNewEditorIfEmpty();
    return monacoEditor.getValue();
}

export function setValue(text: string): void {
    CreateNewEditorIfEmpty();
    return monacoEditor.setValue(text);
}

function CreateNewEditorIfEmpty() {
    if (monacoEditor == undefined) {
        monacoEditor = new MadWorldMonaco.MonacoEditor();
    }
}

