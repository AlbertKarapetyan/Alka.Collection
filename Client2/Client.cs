using Alka.Collections.Models;

namespace Client2
{
    public class Client : IPerson
    {
        private int _id { get; set; }
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly int _height;
        private readonly DateOnly _birthDate;

        public int Id { get { return _id; } }
        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        public int Height { get { return _height; } }

        public Client(string firstName, string lastName, int Height, DateOnly birthDate)
        {
            _id = 0; // will generate by the Collection class

            _firstName = firstName;
            _lastName = lastName;
            _height = Height;
            _birthDate = birthDate;
        }

        public void setId(int id)
        {
            _id = id;
        }

        public int getId()
        {
            return _id;
        }

        public string getFirstName()
        {
            return _firstName;
        }

        public string getLastName()
        {
            return _lastName;
        }

        public int getHeight()
        {
            return _height;
        }

        public DateOnly getDateOfBirth()
        {
            return _birthDate;
        }

        public int CompareTo(IPerson? other)
        {
            int res = this.Height.CompareTo(other?.getHeight());
            return res;
        }
    }
}
