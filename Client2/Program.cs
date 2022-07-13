//The Collection project used ase NuGet package

using Alka.Collections;
using Alka.Collections.Interfaces;
using Alka.Collections.Models;
using Client2;
using Newtonsoft.Json;

Console.WriteLine("Client1 app is running... / The Collection project used ase NuGet package");

IAlkaCollection<IPerson> _personCollection = new PersonCollection();

_personCollection.AddedEvent += _personCollection_AddedEvent;
_personCollection.RemovedEvent += _personCollection_RemovedEvent;


IPerson _client = new Client("Elon", "Park", 95, new DateOnly(2003, 10, 06));
var result = _personCollection.Add<Client>(_client);

_client = new Client("Ali", "Baba", 89, new DateOnly(2001, 02, 22));
result = _personCollection.Add<Client>(_client);

result = _personCollection.Remove();

_client = new Client("Bob", "Marti", 100, new DateOnly(1981, 10, 02));
result = _personCollection.Add<Client>(_client);

_client = new Client("Sharon", "Rich", 56, new DateOnly(2003, 09, 01));
result = _personCollection.Add<Client>(_client);

result = _personCollection.Remove();

_client = new Client("Elon", "Park", 95, new DateOnly(2003, 10, 06));
result = _personCollection.Add<Client>(_client);


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