namespace MadWorldMonaco {
    export class MonacoDecoration {
        public test: string = "";
        public startLineNumber: number = 0;
        public startColumnNumber: number = 0;
        public endLineNumber: number = 0;
        public endColumnNumber: number = 0;
        public isWholeLine: boolean = false;
        public glyphMarginClassName: string = "";
        public linesDecorationsClassName: string = "";
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
            return this.editor.deltaDecorations(
                oldDecorationIds,
                [
                    {
                        range: new (window as any).monaco.Range(newDecorations[0].startLineNumber, newDecorations[0].startColumnNumber, newDecorations[0].endLineNumber, newDecorations[0].endColumnNumber),
                        options: {
                            isWholeLine: newDecorations[0].isWholeLine,
                            linesDecorationsClassName: newDecorations[0].linesDecorationsClassName,
                            glyphMarginClassName: newDecorations[0].glyphMarginClassName
                        }
                    }
                ]
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

export function setDecorations(oldDecorationIds: string[], newDecorations: MadWorldMonaco.MonacoDecoration[]): string[] {
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

