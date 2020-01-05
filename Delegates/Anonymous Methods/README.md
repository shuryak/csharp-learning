# Анонимные методы

Анонимный метод – безымянный блок кода, привязанный к конкретному делегату 
(не может существовать сам по себе). Анонимные методы полезны, когда нужно 
определить однократное неповторяющееся и единственное в своем роде действие.

Синтаксис:

```csharp
delegate(параметры)
{
    // ...
}; // ; обязательно
```

Пример:

```csharp
delegate void MessageHandler(string message);

static void Main(string[] args)
{
    MessageHandler handler = delegate(string mes)
    {
        Console.WriteLine(mes);
    };

    handler("String to print..."); // фактически Console.WriteLine("String to print...");
}
```

## Анонимный метод в качестве параметра

```csharp
ShowMessage("Another string to print...", delegate(string mes)
{
    Console.WriteLine(mes);
});

// ...

static void ShowMessage(string mes, MessageHandler handler)
{
    handler(mes);
}
```

## Анонимный метод без параметров

Если анонимный метод содержит парамтеры, они обязательно должны соответствовать 
параметрам делегата, либо анонимный метод может не принимать никакх параметров.

**НО!** Параметры анонимного метода не могут быть опущены, если какой-либо 
параметр определён с модификатором `out`.

```csharp
delegate void MessageHandler(string message);

// ...

MessageHandler newHandler = delegate
{
    Console.WriteLine("One more string to print...");
};

newHandler("Argument for the delegate."); // Аргумент проигнорируется анонимным методом
```

## Возвращение значения

```csharp
delegate int Operation(int x, int y);

// ...

Operation op = delegate(int x, int y)
{
    return x + y;
};

Console.WriteLine(op(3, 18)); // фактически Console.WriteLine(3 + 18); // 21
```

## Доступ к внешним полям и переменным

Анонимный метод имеет доступ к переменным, заданным во внешнем блоке кода:

```csharp
delegate int Operation(int x, int y);

// ...

int z = 10; // Эта переменная достижима из анонимного метода
Operation newOp = delegate(int x, int y)
{
    return x + y + z;
};

Console.WriteLine(newOp(3, 18)); // фактически Console.WriteLine(3 + 18 + 10); // 31
```
