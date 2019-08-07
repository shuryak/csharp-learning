# Класс `List<T>`

Класс `List<T>` позволяет реализовать *типизированный* однонаправленный список. Доступ к элементам возможен по индексу. Реализует интерфейсы 
`ICollection<T>`, `IEnumerable<T>`, `IList<T>`, `IReadOnlyCollection<T>`, `IReadOnlyList<T>`, `ICollection`, `IEnumerable`, `IList`.

## Основные методы `List<T>`

 - `Add()` — добавляет элемент типа `T`, указанный в качестве параметра, в список.
 - `AddRange()` — добавляет элементы типа `T` коллекции (или массив), указанной в качестве параметра, в список.
 - `BinarySearch()` — поиск элемента в списке по алгоритму бинарного поиска (коллекция должна быть отсортированной), возвращает индекс найденного элемента.
 - `IndexOf()` — возвращает индекс первого вхождения элемента, переданного в качестве параметра, в списке.
 - `Insert()` — вставляет элемент, переданный в качестве второго параметра, по индексу, переданному в качестве первого параметра, в список.
 - `Remove()` — удаляет первое вхождение элемента, переданного в качестве параметра, в списке.
 - `RemoveAt()` — удаляет элемент по индексу, переданному в качестве параметра, в списке.
 - `Sort()` — выполняет сортировку списка.

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1).

## Начальная инициализация списка `List<T>`

Равно как массивы, списки класса `List<T>` можно инициализировать на этапе объявления. Пример:

```csharp
List<int> numbers = new List<int>() { 1, 2, 3 };
```

## Пример использования `List<T>`

Есть класс `Person`:

```csharp
class Person
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    public Person(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
    }
}
```

Создадим список `persons` типа `List<T>`, используя методы `Add()` и `AddRange()`, добавим в список элементы и выведем их с помощью `foreach`:

```csharp
List<Person> persons = new List<Person>();

persons.Add(new Person("Alban", "Smith"));
persons.Add(new Person("William", "Parks"));
persons.Add(new Person("Jack", "Tucker"));

persons[0].Firstname = "George";

Person[] personRange = new Person[] { new Person("Christopher", "Charles"), new Person("Peter", "Carroll") };

persons.AddRange(personRange);

foreach (Person p in persons)
{
    Console.WriteLine(p.Firstname + " " + p.Lastname);
}

Console.ReadLine();
```