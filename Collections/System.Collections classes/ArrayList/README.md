﻿# Динамические массивы `ArrayList`

В C# динамические массивы представлены классом ArrayList, находящимся в пространстве имён `System.Collection`. Этот класс представляет собой коллекцию различных объектов типа `Object`, соответственно динамические массивы в C# являются *нетипизированными*. Реализует интерфейсы `ICollection`, `IEnumerable`, `IList`, `ICloneable`.

## Создание динамического массива

 1. Создаём объект класса ArrayList через конструктор:
	```csharp
    ArrayList myList = new ArrayList();
	```
 2. Добавляем элементы в коллекцию с помощью метода `Add()`:
	```csharp
    myList.Add(1); myList.Add("hello"); myList.Add(3);
	```

Или можно сразу выполнить инициализацию коллекции:
```csharp
ArrayList myList = new ArrayList(){1, "hello",  3};
```

## Полезные свойства класса `ArrayList`

 - `Count` — свойство, позволяющее узнать количество элементов в коллекции;
 - `Capacity` — свойство, позволяющее передать/получить максимально возможное количество элементов, которые может содержать данная коллекция;
 - `IsFixedSize` — свойство, которое указывает, имеет ли коллекция зафиксированный размер (ограничена ли коллекция с помощью `Capacity`).

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.collections.arraylist).

## Полезные методы класса `ArrayList`

 - `Add()` — метод для добавления элемента в коллекцию;
 - `AddRange()` — метод, добавляющий в коллекцию ArrayList элементы из переданного в качестве аргумента массива;
 - `Remove()` — метод для удаления первого вхождения элемента, объект которого указан в качестве аргумента;
 - `RemoveAt()` — метод для удаления элемента с указанным в качестве аргумента индексом;
 - `Clear()` — метод для удаления всех элементов коллекции;
 - `Contains()` — метод для определения существования в коллекции элемента в виде объекта, указанного в качестве аргумента;
 - `Insert()` — вставляет элемент в коллекцию ArrayList по указанному индексу.

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.collections.arraylist).

## Возможности `ArrayList`

Поскольку ArrayList реализует интерфейс `IEnumerable`, его можно перебирать с помощью foreach:

```csharp
foreach(object i in myList){
    Console.WriteLine(i.GetType());
}
```

Стоит обратить внимание на то, что переменная `i` должна быть типа `object`.
