namespace MadWorldMonaco {
    export class MonacoDecorationOptions {
        public isWholeLine: boolean = false;
        public linesDecorationsClassName: string = "";
    }

    export class MonacoRange {
        public startLineNumber: number = 0;
        public startColumnNumber: number = 0;
        public endLineNumber: number = 0;
        public endColumnNumber: number = 0;
    }

    export class MonacoDecoration {
        public test: string = "";
        public range: MonacoRange = new MonacoRange();
        public options: MonacoDecorationOptions = new MonacoDecorationOptions();
    }

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

        public setDecorations(oldDecorationIds: string[], newDecorations: MonacoDecoration[]): string[] {
            alert(newDecorations.length + ' lol');
            alert(newDecorations[0].options);
            alert(newDecorations[0].test);

            return this.editor.deltaDecorations(
                oldDecorationIds,
                newDecorations
            );
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

export function getValue(): string {
    CreateNewEditorIfEmpty();
    return monacoEditor.getValue();
}

export function setDecorations(oldDecorationIds: string[], newDecorations : MadWorldMonaco.MonacoDecoration[]): string[] {
    CreateNewEditorIfEmpty();
    return monacoEditor.setDecorations(oldDecorationIds, newDecorations);
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

