using System;
using static System.Console;

namespace ConsoleApplication1
{
    public class PeopleClass : IInputClass<PeopleClass>
    {
        public string FirstName;
        public string LastName;
        public string City;
        public DateTime BirthDate;
        public int Age;
        public int User_Id;
        private static int Id = 6535001;

        public PeopleClass()
        { }

        public PeopleClass(string FirstName, string LastName, string City, string BirthDate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.City = City;
            this.BirthDate = DateTime.Parse(BirthDate);
            User_Id = Id++;
        }
            
        virtual public void Info()
        {
            WriteLine("ID: " + User_Id + "\nLast Name: " + LastName + " \nFirst Name: " + FirstName);
        }

        public void CountAge()
        {
            DateTime today = DateTime.Now;
            Age = today.Year - BirthDate.Year;
            if (today.Month < BirthDate.Month)
                Age--;
            if ((BirthDate.Month == today.Month) && (BirthDate.Day < today.Day))
                Age--;
        }

        void IInputClass<PeopleClass>.InputArray(PeopleClass[] people, int n)
        {
            for (int i = 0; i < n; i++)
            {
                WriteLine("Input name");
                string name = ReadLine();
                WriteLine("Input lastname");
                string secondname = ReadLine();
                WriteLine("Input city");
                string city = ReadLine();
                WriteLine("Input birth date");
                string birthDate = ReadLine();
                DateTime check = new DateTime();
                while (!DateTime.TryParse(birthDate, out check))
                {
                    WriteLine("Incorrect input of Birth Date! Try again: ");
                    birthDate = ReadLine();
                }
                people[i] = new PeopleClass(name, secondname, city, birthDate);
                Clear();
            }
        }
    }
}
