using System;
using System.Text.RegularExpressions;

namespace NoteApp
{
    /*
     * This class provides correct input and editing for any fields/values used in this app. 
     * Input won't stop until it is correct. Main functional is an overloaded TryEnter method.
     * While creating empty string means skipping not required fields. While editing space means 
     * to leave the current value and empty string means clearing the field (if it's not required).
     */
    public static class Enter
    {
        private const string withNotLetters = "[^A-Za-zА-Яа-я-]";
        private const string withNotDigits = "[^\\d]";

        public static void TryEnter(out int id, string outputPhrase)
        {
            string strValue;
            do
            {
                PrintOutputPhrase(outputPhrase);
                strValue = Console.ReadLine().Trim();
            } while (!IsValidId(strValue, out id));
        }

        public static void TryEnter(out string strValue, string outputPhrase, bool canContainNotLetters,
            bool required, string currentValue = "", bool isInEdit = false)
        {
            string input;
            do
            {
                PrintOutputPhrase(outputPhrase, required, isInEdit);
                input = Console.ReadLine();
                if (!isInEdit)
                    input = input.Trim();
            } while (!IsValidString(input, required, canContainNotLetters, isInEdit));
            if (input == " ")
                strValue = currentValue;
            else
                strValue = input;
        }

        public static void TryEnter(out string number, string outputPhrase, string currentValue = "", bool isInEdit = false)
        {
            string input;
            do
            {
                PrintOutputPhrase(outputPhrase, true, isInEdit);
                input = Console.ReadLine();
                if (!isInEdit)
                    input = input.Trim();
            } while (!IsValidNumber(input, isInEdit));
            if (input == " ")
                number = currentValue;
            else
                number = input;
        }

        public static void TryEnter(out DateTime birthDate, string outputPhrase, DateTime currentValue, bool isInEdit = false)
        {
            string input;
            do
            {
                PrintOutputPhrase(outputPhrase, false, isInEdit);
                input = Console.ReadLine();
                if (!isInEdit)
                    input = input.Trim();
            } while (!IsValidBirthDate(input, isInEdit));
            if (input == " ")
                birthDate = currentValue;
            else if (input == "")
                birthDate = DateTime.MinValue;
            else
                birthDate = DateTime.Parse(input);
        }

        private static bool IsValidBirthDate(string strValue, bool isInEdit)
        {
            if (isInEdit)
            {
                if (strValue == " ")
                    return true;
                strValue = strValue.Trim();
            }

            if (strValue == "")
                return true;

            DateTime birthDate;
            if (!DateTime.TryParse(strValue, out birthDate))
            {
                Error.PrintError(Error.ErrorTypes.incorrectDate);
                return false;
            }
            else if (birthDate > DateTime.Now || birthDate.Year < 1900)
            {
                Error.PrintError(Error.ErrorTypes.incorrectDate);
                return false;
            }

            return true;
        }

        private static bool IsValidId(string strValue, out int id)
        {
            if (!int.TryParse(strValue, out id))
            {
                Error.PrintError(Error.ErrorTypes.notNumber);
                return false;
            }

            return true;
        }

        private static bool IsValidNumber(string strValue, bool isInEdit)
        {
            if (isInEdit)
            {
                if (strValue == " ")
                    return true;
                strValue = strValue.Trim();
            }

            if (strValue.Length != 11)
            {
                Error.PrintError(Error.ErrorTypes.incorrectNumberLength);
                return false;
            }

            if (ContainsNotDigits(strValue))
            {
                Error.PrintError(Error.ErrorTypes.containsNotDigits);
                return false;
            }

            return true;
        }

        private static void PrintOutputPhrase(string outputPhrase, bool required = true, bool isEdit = false)
        {
            if (!required)
                outputPhrase += " (not required)";
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!isEdit)
                Console.WriteLine();
            Console.Write(outputPhrase + ":   ");
            Console.ResetColor();
        }
        private static bool IsValidString(string strValue, bool required, bool canContainNotLetters, bool isInEdit = false)
        {
            if (isInEdit)
            {
                if (strValue == " ")
                    return true;
                if (strValue == "" && !required)
                    return true;
                strValue = strValue.Trim();
            }

            if (required && strValue == "")
            {
                Error.PrintError(Error.ErrorTypes.required);
                return false;
            }
            if (!canContainNotLetters && ContainsNotLetters(strValue))
            {
                Error.PrintError(Error.ErrorTypes.containsNotLetter);
                return false;
            }

            return true;
        }

        private static bool ContainsNotLetters(string str) => Regex.IsMatch(str, withNotLetters);
        private static bool ContainsNotDigits(string str) => Regex.IsMatch(str, withNotDigits);
    }
}
