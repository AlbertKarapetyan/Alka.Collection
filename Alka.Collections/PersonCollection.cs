using System.Collections;
using Newtonsoft.Json;
using Alka.Collections.Interfaces;
using Alka.Collections.Models;

namespace Alka.Collections
{
    public class PersonCollection : IAlkaCollection<IPerson>
    {
        // Delegates
        public event EventHandler<AddedEventArgs>? AddedEvent;
        public event EventHandler<RemovedEventArgs>? RemovedEvent;

        public ArrayList People { get; set; } = new();

        // Add  the  person  object 
        // complexity of O(n)
        public IPerson Add<T>(IPerson item) where T : class
        {
            // Generated ID automaticaly
            // like Entity Framework saving object into the DB
            item.setId(People.Count + 1);

            var peopleList = People.ToArray();

            for (int i = 0; i < peopleList.Length; i++)
            {
                var person = peopleList[i] as IPerson;

                // Getting the maximum
                if(person!.CompareTo(item) > 0)
                {
                    var tmp = person;
                    People[i] = item;
                    
                    People.Add(peopleList.Last());

                    for (int j = People.Count-1; j > i; j--)
                    {
                        People[j] = People[j - 1];
                    }

                    People[i + 1] = tmp;

                    break;
                }
            }

            // new object will be maximum
            // and added end of collection
            if(peopleList.Length == People.Count)
            {
                People.Add(item);
            }

            Console.WriteLine("\r\n=========================================");
            
            foreach(var person in People)
            {
                Console.WriteLine(JsonConvert.SerializeObject(person));
            }

            // publish a notification to subscribers about added
            if (AddedEvent != null)
            {
                AddedEvent.Invoke(item, new AddedEventArgs());
            }

            return item;
        }

        // Removing the person object with the maximum value
        // and return it
        // complexity of O(1)
        public IPerson Remove()
        {
            var removedMaxItem = People[People.Count-1] as IPerson;

            People.RemoveAt(People.Count - 1);

            Console.WriteLine("\r\n=========================================");

            foreach (var person in People)
            {
                Console.WriteLine(JsonConvert.SerializeObject(person));
            }

            // publish a notification to subscribers about removed
            if (RemovedEvent != null)
            {
                RemovedEvent.Invoke(removedMaxItem, new RemovedEventArgs());
            }

            return removedMaxItem!;
        }
    }
}