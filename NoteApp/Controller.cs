using System;
using System.Collections.Generic;

namespace NoteApp
{
    /*
     * This class handles changing note's state and displaying notes' 
     * info, according to commands sent by Command class.
     */
    public static class Controller
    {
        private static List<Note> notes = new List<Note>()
        {
            new Note (true, "Anton", "Alekseyev", "Andreevich", "89999999999", 
                "Russia", "24.07.2001", "First Line Software", "Junior C# Developer", 
                "Cool musician by the way")
        };

        // Translates commands to appropriate method calls.
        public static void CommandsToController(Command.CommandTypes command)
        {
            switch (command)
            {
                case Command.CommandTypes.create:
                    CreateNote();
                    break;
                case Command.CommandTypes.showAll:
                    ShowAllNotes();
                    break;
                case Command.CommandTypes.show:
                    ShowNote();
                    break;
                case Command.CommandTypes.delete:
                    DeleteNote();
                    break;
                case Command.CommandTypes.edit:
                    EditNote();
                    break;
            }
        }

        private static void EditNote()
        {
            int id;
            Enter.TryEnter(out id, "Enter note id");
            Note note = FindNote(id);

            if (note == null)
            {
                Error.PrintError(Error.ErrorTypes.noteNotFound);
            }
            else
            {
                note.Edit();
                Command.CommandSucceed(Command.CommandTypes.edit);
            }
        }

        private static void DeleteNote()
        {
            int id;
            Enter.TryEnter(out id, "Enter note id");
            Note note = FindNote(id);

            if (note == null)
            {
                Error.PrintError(Error.ErrorTypes.noteNotFound);
            }
            else
            {
                notes.Remove(note);
                Command.CommandSucceed(Command.CommandTypes.delete);
            }
        }

        private static void ShowNote()
        {
            int id;
            Enter.TryEnter(out id, "Enter note id");
            Note note = FindNote(id);

            if (note == null)
            {
                Error.PrintError(Error.ErrorTypes.noteNotFound);
            }
            else
            {
                note.PrintFullInfo();
                Command.CommandSucceed(Command.CommandTypes.show);
            }
        }
        private static void ShowAllNotes()
        {
            Console.WriteLine();
            if (notes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Your note list is empty :(\n");
                Console.ResetColor();
            }
            else
            {
                foreach (var note in notes)
                {
                    note.PrintShortInfo();
                }
            }
            Command.CommandSucceed(Command.CommandTypes.showAll);
        }

        private static void CreateNote()
        {
            notes.Add(new Note());
            Command.CommandSucceed(Command.CommandTypes.create);
        }

        private static Note FindNote(int id)
        {
            return notes.Find(note => note.Id == id);
        }
    }
}
