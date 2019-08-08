# Исключения

Исключения — ошибочные ситуации во время выполнения программы, приводящие к невозможности дальнейшей её работы по базовому алгоритму.

## Обработка исключений

Обработка исключений в C# производится с помощью ключевых слов `try`, `catch`, `finally`. Синтаксис обработки исключений:

```csharp
try
{
    // проблемный код (вызывающий исключения)
}
catch (x) // блоков catch может быть несколько
{
    // обработка исключения x
}
finally // обычно выполняется всегда
{

}
```

`x` — тип, производный от `System.Exception` (*все* типы исключений C# являются производными от `System.Exception`).

Когда внутри такого блока `try` возникает исключение, поток управления переходит к первому *подходящему* `catch`. `catch` — обработчик исключений.

Блок `finally` (необязателен) обычно используется для освобождения использованных в `try` ресурсов.

## Свойства `System.Exception`

Рассмотрим некоторые интересные свойства `System.Exception`:

 - `Data` — коллекция, реализующая интерфейс `IDictionary`, в которой в виде списка "ключ — значение" представлена подробная информация об исключении;
 - `HelpLink` — URL файла справки с дополнительной информацией по данному классу исключений;
 - `InnerException` — информация о внутренних исключениях, которые стали причиной текущей исключительной ситуации;
 - `Message` — короткое текстовое описание ошибки;
 - `Source` — имя сборки, сгенерировавшей исключение;
 - `StackTrace` — строка, содержащая последовательность вызовов, которые привели к исключению.

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.exception).

## Пример обработки исключительных ситуаций

Пусть есть метод `Divide()`:

```csharp
public static int Divide(int a, int b)
{
    return a / b;
}
```

Также есть следующий код:

```csharp
Divide(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
```

Можно догадаться, что данный код может вызвать сразу две исключительных ситуации: деление на нуль (если пользователь введёт нуль в качестве второго числа) и неверное представление строки (если пользователь вместо числа введёт строку).

Обернём вызов метода `Divide()` в блок `try` и добавим два обработчика `catch`:

```csharp
try
{
    Divide(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
}
catch (DivideByZeroException e /* необязательно создавать переменную (e), но тогда мы не получим e.Message */)
{
    Console.WriteLine(e.Message);
}
catch (FormatException e /* необязательно создавать переменную (e), но тогда мы не получим e.Message */)
{
    Console.WriteLine(e.Message);
}
finally
{
    Console.WriteLine("Блок finally отработал!");
}
```

Как получить название (тип) исключения? Просто вызвать исключительную ситуацию в Visual Studio (или в другой IDE) и посмотреть название (тип) исключения:

![Название (тип) исключения.](https://github.com/shuryak/csharp-learning/blob/master/Images%20for%20README/exception.png?raw=true)

### Использование `System.Exception` вместо нескольких блоков `catch`

Как упоминалось ранее, все типы исключений C# являются производными от `System.Exception`, поэтому в блоке `catch` можно использовать `System.Exception`:

```csharp
try
{
    Divide(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
}
catch (/*System.*/Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    Console.WriteLine("Блок finally отработал!");
}
```