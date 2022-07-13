using Alka.Collections;
using Alka.Collections.Interfaces;
using Alka.Collections.Models;
using Collection.Models;
using Newtonsoft.Json;

IAlkaCollection<IPerson> _personCollection = new PersonCollection();

_personCollection.AddedEvent += _personCollection_AddedEvent;
_personCollection.RemovedEvent += _personCollection_RemovedEvent;


IPerson _person = new Person("Poghos", "Pogosyan", 95, new DateOnly(1980, 08, 15));
var result = _personCollection.Add<Person>(_person);

_person = new Person("Albert", "Karapetyan", 89, new DateOnly(1982, 03, 20));
result = _personCollection.Add<Person>(_person);

_person = new Person("Jone", "Stone", 100, new DateOnly(1979, 06, 18));
result = _personCollection.Add<Person>(_person);

_person = new Person("Mari", "Green", 56, new DateOnly(1982, 12, 06));
result = _personCollection.Add<Person>(_person);

_person = new Person("Anna", "Marvel", 52, new DateOnly(2003, 10, 22));
result = _personCollection.Add<Person>(_person);

_person = new Person("Arthur", "Karapetyan", 18, new DateOnly(2017, 10, 07));
result = _personCollection.Add<Person>(_person);  // Added O(n)

_person = new Person("Kate", "Slogan", 89, new DateOnly(2005, 01, 01));
result = _personCollection.Add<Person>(_person);  // Added O(n)

result = _personCollection.Remove(); // Remove maximum O(1)


void _personCollection_RemovedEvent(object? sender, RemovedEventArgs e)
{
    Console.WriteLine("RemovedEvent");
    Console.WriteLine(JsonConvert.SerializeObject(sender));
}

void _personCollection_AddedEvent(object? sender, AddedEventArgs e)
{
    Console.WriteLine("AddedEvent");
    Console.WriteLine(JsonConvert.SerializeObject(sender));
}


Console.ReadLine();