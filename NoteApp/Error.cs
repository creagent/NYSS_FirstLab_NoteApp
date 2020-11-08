using System;

namespace NoteApp
{
     // This class provides error processing and output.
    public static class Error
    {
        public enum ErrorTypes
        {
            incorrectCommand,
            containsNotLetter,
            required,
            incorrectNumberLength,
            containsNotDigits,
            incorrectDate,
            notNumber,
            noteNotFound
        }

        public static void PrintError(ErrorTypes error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string output = "";
            switch (error)
            {
                case ErrorTypes.incorrectCommand:
                    output = "Incorrect command!";
                    break;
                case ErrorTypes.containsNotLetter:
                    output = "This field can contain only letters and \"-\"!";
                    break;
                case ErrorTypes.required:
                    output = "This field is required!";
                    break;
                case ErrorTypes.incorrectNumberLength:
                    output = "Phone number should be an 11-digit sequence!";
                    break;
                case ErrorTypes.containsNotDigits:
                    output = "Phone number should contain only digits!";
                    break;
                case ErrorTypes.incorrectDate:
                    output = "Incorrect birth date!";
                    break;
                case ErrorTypes.notNumber:
                    output = "It should be an integer!";
                    break;
                case ErrorTypes.noteNotFound:
                    output = "\nNote not found!";
                    Console.WriteLine(output + "\n");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    Command.CommandInput();
                    return;
            }
            Console.WriteLine("\n" + output);
            Console.ResetColor();
        }
    }
}
