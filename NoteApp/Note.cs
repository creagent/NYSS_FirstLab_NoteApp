using System;

namespace NoteApp
{
    public class Note
    {
        private static int count = 0;
        public int Id { get; private set; }
        private string surname;
        private string name;
        private string midName;
        private string phoneNum;
        private string country;
        private DateTime birthDate;
        private string company;
        private string post;
        private string otherNotes;

        public Note(bool isTest = false, string name = "", string surname = "", string midName = "", string phoneNum = "",
            string country = "", string birthDate = "", string company = "", string post = "", string otherNotes = "")
        {
            if (!isTest)
            {
                Id = count;
                count++;

                Enter.TryEnter(out this.name, "Enter name", false, true);
                Enter.TryEnter(out this.surname, "Enter surname", false, true);
                Enter.TryEnter(out this.midName, "Enter middlename", false, false);
                Enter.TryEnter(out this.phoneNum, "Enter phone number");
                Enter.TryEnter(out this.country, "Enter country", false, true);
                Enter.TryEnter(out this.birthDate, "Enter birth date (dd.MM.yyyy)", DateTime.MinValue);
                Enter.TryEnter(out this.company, "Enter company", true, false);
                Enter.TryEnter(out this.post, "Enter person's post", true, false);
                Enter.TryEnter(out this.otherNotes, "Enter other notes", true, false);
            }
            else
            {
                Id = count;
                count++;

                this.name = name;
                this.surname = surname;
                this.midName = midName;
                this.phoneNum = phoneNum;
                this.country = country;
                this.birthDate = DateTime.Parse(birthDate);
                this.company = company;
                this.post = post;
                this.otherNotes = otherNotes;
            }
        }


        public void Edit()
        {
            EditField("name", out name, false, true, name);
            EditField("surname", out surname, false, true, surname);
            EditField("middle name", out midName, false, false, midName);
            EditField("phone number", out phoneNum, phoneNum);
            EditField("country", out country, false, true, country);
            EditField("birh date", out birthDate, birthDate);
            EditField("company", out company, true, false, company);
            EditField("person's post", out post, true, false, post);
            EditField("other notes", out otherNotes, true, false, otherNotes);
        }

        private void EditField(string fieldName, out string field, bool canContainNotLetters, bool required, string currenValue)
        {
            PrintCurrentValue(fieldName, currenValue, "");
            Enter.TryEnter(out field, $"Enter new {fieldName} or enter space to leave the current value", 
                canContainNotLetters, required, currenValue, true);
        }

        private void EditField(string fieldName, out string field, string currenValue)
        {
            PrintCurrentValue(fieldName, currenValue, "");
            Enter.TryEnter(out field, $"Enter new {fieldName} or enter space to leave the current value", currenValue, true);
        }

        private void EditField(string fieldName, out DateTime field, DateTime currenValue)
        {
            PrintCurrentValue(fieldName, "", currenValue.ToShortDateString());
            Enter.TryEnter(out field, $"Enter new {fieldName} or enter space to leave the current value", currenValue, true);
        }

        // Outputs current field value in correct format
        private void PrintCurrentValue(string fieldName, string str = "", string date = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\nCurrent {fieldName}: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (str != "")
            {
                if (str == "")
                    Console.Write("None\n");
                else
                    Console.Write(str + "\n");
            }
            else
            {
                if (date == DateTime.MinValue.ToShortDateString())
                    Console.Write("None\n");
                else
                    Console.Write(date + "\n");
            }
            
        }
        public void PrintFullInfo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string output = $"Id: {Id}\n" +
                $"Surname: {surname}\n" +
                $"Name: {name}\n";
            if (midName != "")
                output += $"Middle name: {midName}\n";
            output += $"Phone number: {phoneNum}\n" +
                $"Country: {country}\n";
            if (birthDate != DateTime.MinValue)
                output += $"Birth date: {birthDate.ToShortDateString()}\n";
            if (company != "")
                output += $"Company: {company}\n";
            if (post != "")
                output += $"Post: {post}\n";
            if (otherNotes != "")
                output += $"Other notes: {otherNotes}\n";

            Console.WriteLine(output);
            Console.ResetColor();
        }

        public void PrintShortInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Id: {Id}\n" +
                $"Surname: {surname}\n" +
                $"Name: {name}\n" +
                $"Phone number: {phoneNum}\n");
            Console.ResetColor();
        }
    }
}
