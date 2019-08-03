# Класс Queue

Коллекция класса `Queue` позволяет реализовать список в виде очереди по алгоритму **FIFO** (***F**irst-**i**n*, ***F**irst-**o**ut* — первым пришёл, первым ушёл), где элементы обрабатываются *в порядке поступления*.

## Методы Queue

У класса `Queue` нет привычных методов `Add()` и `Remove()`, потому что логика очереди не должна предоставлять доступ к любому элементу. Зато у класса `Queue` есть следующие методы, работающие по принципу очереди:

 - `Enqueue()` — добавляет указанный в качестве параметра элемент в конец очереди;
 - `Dequeue()` — возвращает первый элемент очереди и удаляет его;
 - `Peek()` — возвращает первый элемент очереди без удаления.

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.collections.queue).

## Пример использования очереди

```csharp
Queue queue = new Queue();

queue.Enqueue("First");
queue.Enqueue("Second");
queue.Enqueue("Third");
queue.Enqueue("Fourth");
queue.Enqueue("Fifth");

while (queue.Count > 0)
{
    Console.WriteLine(queue.Dequeue().ToString());
}
```

## Перебор очереди

При переборе элементов очереди, нужно быть аккауратнее, т.к. при получении элемента с помощью `Dequeue()`, длина очереди `Count` уменьшается на единицу.

Цикл `for` может выглядеть так:

```csharp
for ( ; queue.Count > 0; )
{
    Console.WriteLine(queue.Dequeue().ToString());
}
```

Заметьте, при переборе очереди через `foreach`, элементы очереди не удаляются:

```csharp
foreach(object i in queue)
{
    Console.WriteLine(i.ToString());
}

Console.WriteLine(queue.Count); // 5
```