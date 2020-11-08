using System;

namespace NoteApp
{
    // This class handles commands input and processing.
    public static class Command
    {
        /*
         * Shows command list and reads input until the command is correct.
         * If the command is incorect prints an error phrase.
         */
        public static void CommandInput(bool clear = true)
        {
            bool success;
            CommandTypes command;
            var isIncorrectCommand = false;
            do
            {
                ShowCommandList(isIncorrectCommand, clear);

                string input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "create":
                        command = CommandTypes.create;
                        success = true;
                        break;
                    case "edit":
                        command = CommandTypes.edit;
                        success = true;
                        break;
                    case "delete":
                        command = CommandTypes.delete;
                        success = true;
                        break;
                    case "show":
                        command = CommandTypes.show;
                        success = true;
                        break;
                    case "showall":
                        command = CommandTypes.showAll;
                        success = true;
                        break;
                    case "quit":
                        return;
                    default:
                        success = false;
                        Error.PrintError(Error.ErrorTypes.incorrectCommand);
                        command = CommandTypes.none;
                        isIncorrectCommand = true;
                        break;
                }
            } while (!success);

            Controller.CommandsToController(command);
        }

        // Shows command list lol.
        private static void ShowCommandList(bool isIncorrectCommand = false, bool clear = true)
        {
            if (isIncorrectCommand)
                System.Threading.Thread.Sleep(1000);
            if (clear || isIncorrectCommand)
                Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Choose and enter one of the commands below:\n\n" +
                "create - to create new note\n" +
                "edit - to edit a note\n" +
                "delete - to delete a note\n" +
                "show - to show one note\n" +
                "showAll - to show all notes\n" +
                "quit - to finish program\n");
            Console.ResetColor();
        }

        // Outputs phrase if command was executed successfully.
        public static void CommandSucceed(CommandTypes command)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            switch (command)
            {
                case CommandTypes.create:
                    Console.WriteLine("\nNew note was created successfully!\n");
                    break;
                case CommandTypes.delete:
                    Console.WriteLine("\nNote was deleted successfully!\n");
                    break;
                case CommandTypes.edit:
                    Console.WriteLine("\nNote was edited successfully!\n");
                    break;
                default:
                    CommandInput(false);
                    return;
            }
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
            CommandInput();
        }

        public enum CommandTypes
        {
            create,
            edit,
            delete,
            show,
            showAll,
            none
        }
    }
}
