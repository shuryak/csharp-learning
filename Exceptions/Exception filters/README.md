# Фильтры исключений

Фильтры исключений — инструкции, позволяющие указать условия выполнения конкретного блока `catch`.

## Синтаксис

Синтаксис фильтров исключений таков:

```csharp
catch (тип_исключения /*имя_переменной*/) when (условие)
{

}
```

`when (условие)` — это фильтр, указывающий что данный блок `catch` выполнится только при соблюдении условия `условие`, т.е., если `условие` вернёт `true`.

## Пример использования

```csharp
int x = 1;
int y = 0;

try
{
    Console.WriteLine("Результат: " + (x / y));
}
catch (DivideByZeroException) when (x == 0 && y == 0)
{
    Console.WriteLine("0 / 0 не определено.");
}
catch (DivideByZeroException e)
{
    Console.WriteLine(e.Message);
}
```

Здесь первый блок `catch` отработает лишь в том случае, если сработает условие `x == 0 && y == 0`, т.е., если `x` и `y` будут равны нулю.