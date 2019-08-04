# Класс Stack

Коллекция класса `Stack` позволяет реализовать список в виде стека по алгоритму ***LIFO*** (***L**ast-**i**n*, ***F**irst-**o**ut* — последним пришёл, первым ушёл).

## Методы Stack

У класса `Stack` нет привычных методов `Add()` и `Remove()`, потому что логика стека не должна предоставлять доступ к любому элементу. Зато у класса `Stack` есть следующие методы, работающие по принципу стека:

 - `Push()` — добавляет указанный в качестве параметра элемент в конец стека;
 - `Pop()` — возвращает последний элемент стека и удаляет его;
 - `Peek()` — возвращает последний элемент стека без удаления.

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.collections.stack).

## Пример использования стека

```csharp
Stack stack = new Stack();

stack.Push("First");
stack.Push("Second");
stack.Push("Third");
stack.Push("Fourth");
stack.Push("Fifth");

while(stack.Count > 0)
{
    Console.WriteLine(stack.Pop().ToString());
}
```

## Перебор стека

При переборе элементов стека нужно быть аккуратнее, т.к. при получении элемента с помощью `Pop()`, длина стека `Count` уменьшается на единицу.

Цикл `for` может выглядеть так:

```csharp
for ( ; stack.Count > 0; )
{
    Console.WriteLine(queue.Pop().ToString());
}
```

Заметьте, при переборе стека через `foreach`, элементы стека не удаляются:

```csharp
foreach(object i in stack)
{
    Console.WriteLine(i.ToString());
}

Console.WriteLine(stack.Count); // 5
```