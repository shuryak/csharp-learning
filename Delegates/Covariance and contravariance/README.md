# Ковариантность и контравариантность

Ковариантность и контравариантность – возможность использовать производные 
возвращаемый тип и сигнатуру в методе, переданному делегату.

*Ковариантность* позволяет присвоить делегату метод, возвращаемым типом 
которого является класс, производным от возвращаемого типа делегата.

*Контравариантность* позволяет присвоить делегату метод, типом параметра 
которого служит класс, являющийся базовым для класса, указанного в качестве 
параметра делегата.

## Ковариантность

**Код данного раздела находится в папке `CoAndContraVariance`**

Определим класс `Person`:

```csharp
public class Person
{
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}
```

Затем определим класс `Client`, наследуемый от `Person`:

```csharp
public class Client : Person
{
    public Client(string firstname, string lastname) : base(firstname, lastname) { }

    public int Budget { get; set; } // Свойство определили только для того, чтобы показать, что классы Person и Client чем-то отличаются
}
```

Рассмотрим ковариантность на следующем примере:

```csharp
delegate Person PersonDel(string firstname, string lastname);

// ...

PersonDel pd;
pd = ReturnClient; // Ковариантность
Person harry = pd("Harry", "Smith"); // Фактически Person harry = new Client("Harry", "Smith");

Console.WriteLine(harry.FirstName + " " + harry.LastName);

// ...

private static Client ReturnClient(string firstname, string lastname)
{
    return new Client(firstname, lastname);
}
```

## Контравариантность

**Код данного раздела находится в папке `CoAndContraVariance`**

Используем те же классы `Person` и `Client`.

```csharp
delegate void ClientInfo(Client client); // Здесь тип параметра – Client

// ...

ClientInfo clientInfo = PrintPersonInfo;
Client client = new Client("Mike", "Pierce");
clientInfo(client);

// ...

private static void PrintPersonInfo(Person p) // А здесь аргумент типа Person (базового типа по отношению к Client)
{
    Console.WriteLine(p.FirstName + " " + p.LastName);
}
```

## Ковариантность и контравариантность в обобщенных делегатах

**Код данного раздела находится в папке `CoAndContraGeneralizedDelegates`**

Имеется два класса:

```csharp
public class Person
{
    public string Name { get; set; }
    public virtual void PrintInfo() => Console.WriteLine($"Person: {Name}");
}
```

```csharp
public class Client : Person
{
    public override void PrintInfo() => Console.WriteLine($"Client: {Name}");
}
```

Рассмотрим ковариантность:

```csharp
private delegate T User<out T>(string name);

// ...

User<Client> newClient = GetClient;
User<Person> firstPerson = newClient; // Ковариантность
User<Person> secondPerson = GetClient; // Ковариантность

Person p = firstPerson("Mike");
p.PrintInfo();

// ...

private static Client GetClient(string name)
{
    return new Client {Name = name};
}
```

Использование `out` позволяет присваивать делегату типа `User<Person>` делегат 
типа `User<Client>` или ссылку на метод, возвращающий значение типа `Client`.

Рассмотрим контравариантность:

Используем те же классы `Person` и `Client`.

```csharp
private delegate void GetInfo<in T>(T user);

// ...

GetInfo<Person> personInfo = PersonInfo;
GetInfo<Client> clientInfo = personInfo; // Контравариантность

Client client = new Client { Name = "Harry" };
clientInfo(client);

// ...

private static void PersonInfo(Person p)
{
    p.PrintInfo();
}
```

Использование `in` позволяет присвоить делегат с более универсальным типом 
делегату с производным типом.