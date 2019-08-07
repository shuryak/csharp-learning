# Итераторы и оператор `yield`

Оператор `yield` позволяет написать *итератор* — блок кода, предоставляющий доступ к набору элементов. Итератор должен просто возвращать следующий элемент из набора элементов. Набор элементов не обязательно должен быть массивом или коллекцией. Технически, мы можем просто "притвориться", что у нас есть набор элементов и возвращать любые значения, следующие друг за другом или вразной, как захотим (или только одно значение).

## Инструкции `yield`

Итераторы используют следующие специальные конструкции `yield`:

 - `yield return` — возвращает очередной элемент;
 - `yield break` — сообщает, что набор элементов закончился.

## `GetEnumerator()` с помощью `yield`

Пусть есть класс `Person` с коллекцией `Childrens` класса `ArrayList`:

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
}
```

Чтобы перебирать коллекцию `Childrens` из самого класса, нужно реализовать метод `GetEnumerator()`, возвращающий `IEnumerator()`. [Подробнее от этом](https://github.com/shuryak/csharp-learning/tree/master/Collections/IEnumerable%20%26%20IEnumerator). Но можно не реализовать интерфейс `IEnumerable` для этого, а просто сделать `GetEnumerator()` итератором:

```csharp
public IEnumerator GetEnumerator()
{
    foreach (Person p in Childrens)
    {
        yield return p;
    }
}
```

Здесь `yield return` не прерывает выполнение метода и возвращает значение как `return`, а возвращает указанное значение (`p`) внешнему итератору (циклу `foreach`) и продолжает работать без прерывания работы метода.

##  Итератор без коллекции

Выше было сказано, набор элементов не обязательно должен быть массивом или коллекцией и мы можем возвращать любое значение с помощью `yield return`. Рассмотрим пример сказанного:

Есть следующий класс `Numbers`:

```csharp
class Numbers
{
    public int SqrNum { get; set; }

    public Numbers(int num)
    {
        SqrNum = num;
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i <= SqrNum; i++)
        {
            yield return i * i;
        }
    }
}
```

Как видно, `GetEnumerator` не содержит / не обращается ни к какой коллекции или массиву, а просто с помощью `yield return` поочерёдно возвращает квадрат числа для каждого `i`. Тем не менее, следущий код сработает и выведет 6 первых квадратов натуральных чисел (включая 0):

```csharp
Numbers sqr = new Numbers(5);

Console.WriteLine("Квадраты чисел от 0 до {0}", sqr.SqrNum);
foreach (int i in sqr)
{
    Console.WriteLine(i);
}
```

Благодаря тому, что `Numbers` реализует `GetEnumerator`, мы можем перебирать объекты класса `Numbers` как обычную коллекцию в цикле `foreach`.

## Именованный итератор

Оператор `yield` можно использовать в любом методе, только метод должен возвращать объект интерфейса `IEnumerable`. Подобные методы называют *именованными итераторами*.

Есть класс `Kindergarten`, описывающий детский сад:

```csharp
class Kindergarten // детский сад
{
    private Person[] childrens; // массив детей
    private int index = 0; // текщий индекс
    public int Places // количество мест в детском саду
    {
        get { return childrens.Length; }
    }
    public int OccupiedPlaces // количество занятых мест в детском саду
    {
        get { return childrens.Length - (childrens.Length - index); }
    }

    public Kindergarten(int places) // конструктор, задающий количество мест в дестком саду
    {
        childrens = new Person[places];
    }

    public bool AddChild(string firstname, string lastname) // метод для добавления детей в детский сад
    {
        if (index < Places)
        {
            childrens[index] = new Person(firstname, lastname);
            index++;
            return true;
        }
        return false;
    }

    public IEnumerable GetChildrens(int num) // именованный итератор, в качестве параметра нужно передавать количество первых детей, имена которых нужно вывести
    {
        for (int i = 0; i < num; i++)
        {
            if (i == OccupiedPlaces)
            {
                yield break;
            }
            else
            {
                yield return childrens[i];
            }
        }
    }
}
```

Класс `Person` тот же самый, который был описан выше.

Благодаря методу `GetChildrens()` (заметьте, **не** `GetEnumerator()`), мы можем перебирать массив `childrens` через объекты класса `Kindergarten` с помощью `foreach` таким образом:

```csharp
Kindergarten kg = new Kindergarten(30); // создаём садик на 30 мест

kg.AddChild("Edward", "Lambert");
kg.AddChild("Ethan", "Watkins");
kg.AddChild("Mary", "Nash");
kg.AddChild("Emily", "Lewis");

Console.WriteLine("{0} / {1} мест в детском саду занято:", kg.OccupiedPlaces ,kg.Places);
foreach (Person child in kg.GetChildrens(10))
{
    Console.WriteLine(child.Firstname + " " + child.Lastname);
}
```