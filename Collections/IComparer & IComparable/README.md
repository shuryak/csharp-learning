# Интерфейсы IComparer и IComparable

Интерфейсы `IComparer` и `IComparable` применяются для сортировки элементов коллекций. Метод `Sort()` по умолчанию работает только для набора примитивных типов. А если мы захотим сортировать пользовательские типы данных (объекты), следует явно реализовать интерфейс `IComparable` для их класса. Интерфейс `IComparable` содержит лишь один метод `CompareTo()`:

```csharp
public interface IComparable
{
    int CompareTo(object obj);
}
```

В этом методе мы должны описать логику сравнения объектов данного класса, нужно сравнить текущий объект с объектом, который передаётся в качестве параметра `object obj`. Метод должен вернуть целое число, которое может быть:

 - Меньше нуля. Значит, *текущий объект* "меньше" *переданного объекта*, а значит должен находится *перед* ним.
 - Нулём. Значит оба объекта *равны* (разумеется, не важно, как их упорядочить между собой).
 - Больше нуля. Значит *текущий объект* "больше" *переданного объекта*, а значит должен находится *после* него.

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
        get { return (Person)Childrens[index]; }
    }

    public IEnumerator GetEnumerator()
    {
        return new PersonEnumerator(this); // см. IComparer and IComparable/PersonEnumerator.cs
    }

    public new string ToString()
    {
        return Firstname + " " + Lastname;
    }
}
```

В коллекции `Childrens` находятся дети, мы бы хотели отсортировать их имена по алфавитному порядку. Напишем следующий метод в классе `Person`:

```csharp
public void SortChildren()
{
    Children.Sort();
}
```

Если его вызвать, то получим ошибку "Произошёл сбой при сравнении двух элементов массива". Причина в том, что мы не задали логику сравнения объектов `Person`. Чтоб объекты какого-либо класса могли участвовать в сортировке коллекций, такой класс должен реализовывать интерфейс `IComparable`. Выше было указано, что этот интерфейс содержит лишь метод `CompareTo()` и было указано, как данный метод должен работать. Давайте реализуем этот метод в классе `Person`:

```csharp
public int CompareTo(object obj)
{
    Person person = (Person)obj;

    string personName1 = this.ToString();
    string personName2 = person.ToString();

    return personName1.CompareTo(personName2); // здесь CompareTo() строковый, он применяется к строке (примитиву)
}
```

Принцип работы реализованного метода:

 1. Создаётся переменная типа `Person`, хранящая переданный объект `obj`, приведённый к `Person`.
 2. Создаётся строка `personName1`, хранящая текущий объект, приведённый к строке с помощью переопределённого метода `ToString()`, возвращающего строку вида `Имя Фамилия`.
 3. По аналогии создаётся строка `personName2`, только для `person`.
 4. Возвращается результат `CompareTo(personName2)` для `personName1` (стоит обратить внимание на то, что здесь `CompareTo()` применяется к примитивным строкам, это не наш `CompareTo`, применяемый к объектам). [CompareTo() для строк](https://docs.microsoft.com/ru-ru/dotnet/api/system.string.compareto). Кстати, получается, у строк есть метод интерфейса `IComparable`.

Мы реализовали метод `CompareTo()` интерфейса `IComparable`.

Теперь данный метод будет корректно сортировать объекты `Person` по имени

## Перегруженный метод Sort()

Если у класса уже есть реализация метода сравнения, но мы хотим использовать свой алгоритм, что делать? Например, у нашего класса `Person` из свойств есть только имя и фамилия. Но что, если мы захотели добавить возраст и сортировать ещё и по нему? На такой случай у метода `Sort()` есть перегруженный вариант, который в качестве параметра получает интерфейс `IComparer`. Этот интерфейс определяет только один метод `Compare()`, получающий два объекта, подлежащих сравнению:

```csharp
interface IComparer
{
    int Compare(object obj1, object obj2);
}
```

Метод `Compare()` также может возвращать три целочисленных значения:

 - Положительное значение (больше нуля). Значит `obj1` "больше" `obj2`.
 - Ноль. Значит оба объекта `obj1` и `obj2` "равны".
 - Отрицательное значение (меньше нуля). Значит `obj1` "меньше" `obj2`.

Для класса `Person` метод `Compare` может выглядеть так:

```csharp
int IComparer.Compare(object person1, object person2)
{
    string personName1 = ((Person)person1).ToString();
    string personName2 = ((Person)person2).ToString();

    return personName1.CompareTo(personName2);
}
```

Чтобы использовать данный метод нужно вызвать метод `Sort()`, указав ему в качестве параметра объект, реализующий интерфейс `IComparer`. Из-за того, что интерфейс реализован нами прямо в классе `Person`, метод можно вызвать так:

```csharp
Children.Sort(this);
```

Конечно, в качестве параметра может быть передан любой другой класс, который реализует `IComparer` и который содержит логику сравнения объектов нашего класса. Создадим такой класс, но только сортирующий в обратном порядке:

```csharp
class PersonSort : IComparer
{
    int IComparer.Compare(object person1, object person2)
    {
        string personName1 = ((Person)person1).ToString();
        string personName2 = ((Person)person2).ToString();

        return personName2.CompareTo(personName1);
    }
}
```

Вся фишка в том, что здесь в `return`, во-первых, `CompareTo(personName1)`, во-вторых, он применяется к `personName2`.

Теперь перегруженную версию `Sort()` можно вызвать так:

```csharp
Childrens.Sort(new PersonSort());
```
