# Интерфейсы IEnumerable и IEnumerator

Чтобы использовать возможность перебирать класс в операторе цикла `foreach`, нужно, чтобы этот класс реализовывал интерфейс `IEnumerable`. Интерфейс `IEnumerable` имеет метод `GetEnumerator()`, возвращающий *ссылку на другой интерфейс* — перечислитель `IEnumerator`:

> `IEnumerable` — это интерфейс, определяющий метод `GetEnumerator()`, который возвращает интерфейс `IEnumerator`... 
> [Источник](https://stackoverflow.com/questions/619564/what-is-the-difference-between-ienumerator-and-ienumerable/)

```csharp
public interface IEnumerable
{
    IEnumerator GetEnumerator(); // метод, возвращающий интерфейс IEnumerator
}
```

Интерфейс `IEnumerator` содержит всего два метода и одно свойство, реализовав которые, класс можно будет использовать в цикле `foreach`:

```csharp
public interface IEnumerator
{
    object Current { get; }
    bool MoveNext();
    void Reset();
}
```

 - Свойство `Current`. Отвечает за возвращение элемента коллекции, соответствующему текущей позиции перечислителя.
 - Метод `MoveNext()`. Отвечает за перемещение перечислителя к следующему элементу коллекции. Должен возвратить `false`, если достигнут конец коллекции, в остальных случаях возвращает `true`.
 - Метод `Reset()`. Отвечает за установку перечислителя в начальное положение, т.е. ПЕРЕД первым элементом коллекции, то есть, если индекс первого элемента — это `0`, то начальное положение перечислителя — это `-1`.

Программист имеет полную свободу и может реализовать интерфейс, как ему удобно.

Пусть есть класс `Person`:

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

    ArrayList Childrens = new ArrayList();
    
    public void AddChild(string firstname, string lastname)
    {
        Childrens.Add(new Person(firstname, lastname));
    }
    
    public int GetChildrenCount()
    {
        return Childrens.Count;
    }
    
    public Person this[int index]
    {
        get { return (Person)Childrens[index];  }
    }
}
```

Нам бы хотелось перебирать коллекцию Childrens с помощью foreach. Но как это сделать? Мы бы могли, конечно, сделать эту коллекцию `public` и перебирать её так:

```csharp
Person Vasiliy = new Person("Василий", "Иванов");
Vasiliy.AddChild("Олег", "Иванов");
Vasiliy.AddChild("Светлана", "Иванова");

foreach (Person children in Vasiliy.Childrens)
{
    Console.WriteLine(children.Firstname + " " + children.Lastname);
}
```

Да, данный код выведет вполне ожидаемые и корректные данные:
`Олег Иванов`
`Светлана Иванова`
однако, это ненадёжно, потому что мы сделали `Childrens` публичным.

Реализуя `IEnumerable` и `IEnumerator`, мы, как раз, сможем перебирать коллекцию `Childrens` через объект `Vasiliy` с помощью `foreach`. Давайте это сделаем. Достаточно просто в классе `Person` написать:

```csharp
public IEnumerator GetEnumerator()
{
    return Childrens.GetEnumerator();
}
```

Мы описали метод `GetEnumerator()` в классе `Person`, который возвращает `IEnumerator` из `Childrens`. `Childrens` — это `ArrayList`, а `ArrayList` реализует интерфейс `IEnumerable`, а значит, в нём описан метод `GetEnumerator()`, возвращающий `IEnumerator`.

Но в данном случае мы используем не свою реализацию интерфейса `IEnumerator`, а уже готовую. Так давайте реализуем свой вариант перечислителя `IEnumerator` и назовём его `PersonEnumerator`:

```csharp
class PersonEnumerator: IEnumerator
{
    int currentIndex = -1; // начальное положение перечислителя – перед первым элементом коллекции.
    Person person; // свойство типа Person
    
    public PersonEnumerator(Person person) // конструктор
    {
        this.person = person;
    }
    
    // далее – члены IEnumerator
    public object Current
    {
        get { return person[currentIndex]; }
    }
    
    public bool MoveNext()
    {
        currentIndex++;
        if(currentIndex >= person.GetChildrenCount())
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Reset()
    {
        currentIndex = -1;
    }
}
```

Вот и всё, всего лишь нужно было реализовать 3 члена интерфейса (1 свойство и 2 метода).

Чтобы использовать только что написанный класс, нужно переписать метод `GetEnumerator()` в классе `Person`:

```csharp
public IEnumerator GetEnumerator()
{
    return new PersonEnumerator(this);
}
```

Теперь мы получили возможность использовать объекты класса `Person` в цикле `foreach`:

```csharp
foreach (Person children in Vasiliy)
{
    Console.WriteLine(children.Firstname + " " + Vasiliy.Lastname);
}
```

