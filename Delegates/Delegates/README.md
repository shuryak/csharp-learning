# Делегаты

Делегаты – объекты, указывающие на методы.

## Определение делегатов

Для определения делегата используется ключевое слово `delegate` с указанием 
возвращаемого типа, названия делегата и параметрами в круглых скобках:

```csharp
delegate void Print();
```

Данный делегат `Print` по определению ничего не возвращает (тип `void`) и не 
принимает никаких параметров, поэтому может содержать только методы со схожим 
набором установок: не принимающих никаких параметров и возвращающих тип `void`.

## Использование делегатов

Для дальнейшего использования определим класс `Printer`:

```csharp
public static class Printer
{
    public static void PrintEven()
    {
        Console.WriteLine("Even!");
    }

    public static void PrintOdd()
    {
        Console.WriteLine("Odd!");
    }
}
```

Чтобы использовать делегат, сначала нужно создать переменную делегата:

```csharp
Print sth; // Переменная делегата Print с названием sth
```

Далее переменной делегата нужно присвоить адрес метода (мы сделаем это с 
небольшими проверками):

```csharp
Print sth; // Объявляем переменную делегата Print с названием sth

int userValue = Convert.ToInt32(Console.ReadLine()); // Получаем число, введённое пользователем

if (userValue % 2 == 0) // Если это число кратно двум (чётное)
{
    sth = Printer.PrintEven; // Присваиваем переменной sth метод PrintEven класса Printer
}
else // Иначе (нечётное)
{
    sth = Printer.PrintOdd; // Присваиваем переменной sth метод PrintOdd класса Printer
}

sth(); // Вызываем записанный метод в sth (делегат)
/*
Если пользователь введёт чётное число, в sth будет записан метод 
Printer.PrintEven, и в консоль выведется "Even!", иначе если пользователь 
введёт нечётное число, в sth будет записан метод Printer.PrintOdd, и в консоль 
выведется "Odd!".
*/
```

**Примечание**: в переменную делегата мы *записываем* метод, а *не вызываем* 
его, поэтому писать круглые скобки (`()`) нельзя.

Рассмотрим второй пример:

Определим следующий делегат:

```csharp
internal delegate int Operation(int a, int b);
```

Этот делегат предполагает возвращение `int` и принимает два параметра типа 
`int`.

Определим класс `MathOperations`:

```csharp
public class MathOperations
{
    public int Sum(int x, int y)
    {
        return x + y;
    }

    public int Multiply(int x, int y)
    {
        return x * y;
    }
}
```

В этом классе определены два метода `Sum` и `Multiply`, которые подходят для 
делегата.

**Примечание**: класс и методы сделаны нестатичными намеренно, чтобы показать 
возможность присвоения нестатичных методов объектов делегату.

Запишем методы в делегат следующим образом:

```csharp
MathOperations math = new MathOperations();

Operation del = math.Sum;
Console.WriteLine(del(3, 9)); // 12

del = math.Multiply;
Console.WriteLine(del(3, 9)); // 27
```

## Конструктор делегатов

Можно передать метод в делегат на этапе инициализации с помощью конструктора, в 
который передаётся ссылка на нужный метод:

```csharp
delegate int Something(int a);

// ...

Something del = new Something(MyMethod); // равнозначно Something del = MyMethod
Console.WriteLine(del(5)); // 15

// ...

public static int MyMethod(int x)
{
    return x + 10;
}
```

## Несколько методов в делегате

Делегат может указывать на множество методов, подходящих по установкам
(соответствие возвращаемого типа и парметров). Методы попадают в специальный 
список – *invocation list*, из которого последовательно вызываются методы.

```csharp
public static class ManyMethods
{
    public static int ReturnAsSame(int num)
    {
        int result = num;
        Console.WriteLine(result);
        return result;
    }

    public static int MinusOne(int x)
    {
        int result = x - 1;
        Console.WriteLine(result);
        return result;
    }

    public static int Squaring(int a)
    {
        int result = a * a;
        Console.WriteLine(result);
        return result;
    }
}

// ...

internal delegate int MyDelegate(int num);

// ...

MyDelegate myDel = ManyMethods.ReturnAsSame; // присваиваем в делегат myDel метод ReturnAsSame класса ManyMethods
myDel += ManyMethods.Squaring; // добавляем в делегат myDel метод Squaring класса ManyMethods
myDel += ManyMethods.MinusOne; // добавляем в делегат myDel метод MinusOne класса ManyMethods
myDel += ManyMethods.Squaring; // добавляем в делегат myDel метод Squaring класса ManyMethods
myDel += ManyMethods.Squaring; // добавляем в делегат myDel метод Squaring класса ManyMethods

Console.WriteLine("Return " + myDel(5)); // вызываем myDel(5), возвращается результат последнего записанного метода (ManyMethods.Squaring), поэтому здесь получаем "Return 25"

myDel -= ManyMethods.Squaring; // удаляем метод Squaring класса ManyMethods из делегата myDel

/*
При удалении методов из делегата фактически создаётся новый делегат, который в 
invocation list будет содержать на один метод меньше. Удаление происходит для 
первого вхождения метода с конца invocation list.
*/

Console.WriteLine("Return " + myDel(5)); // вызываем myDel(5), возвращается результат последнего записанного метода (ManyMethods.Squaring), поэтому здесь получаем "Return 25"
```

## Объединение делегатов

В делегаты можно записывать другие делегаты, тем самым объединяя их:

```csharp
public static class OtherMethods
{
    public static void Greet(string name)
    {
        Console.WriteLine("Hello " + name + "!");
    }

    public static void HowAreYou(string name)
    {
        Console.WriteLine("How are you " + name + "?");
    }

    public static void WhatsUp(string name)
    {
        Console.WriteLine("What's up " + name + "?");
    }

    public static void Bye(string name)
    {
        Console.WriteLine("Bye " + name + "!");
    }
}

// ...

internal delegate void OtherDelegate(string str);

// ...

OtherDelegate firstDelegate = OtherMethods.Greet;
firstDelegate += OtherMethods.HowAreYou;

OtherDelegate secondDelegate = OtherMethods.WhatsUp;
secondDelegate += OtherMethods.Bye;

OtherDelegate generalDelegate = firstDelegate + secondDelegate; // объединяем делегаты firstDelegate и secondDelegate

generalDelegate("Mike");
/*
ВЫВОД:

"Hello Mike!"
"How are you Mike?"
"What's up Mike?"
"Bye Mike!"
*/
```

## `Invoke()`

Делегат можно вызвать не только как обычный метод, но и с помощью метода 
`Invoke()`. Если делегат подразумевает получение параметров, то они передаются 
в `Invoke()`.

## Пустой делегат

Если делегат не имеет ссылок на другие методы, он равен `null`. Поэтому при 
вызове такого делегата будет выброшено исключение 
`System.NullReferenceException`. Чтобы контролировать такие ситуации, можно 
ввести проверку на `null` либо использовать оператор условного `null` (`?`).

## Делегаты как параметры методов

Делегаты могут передаваться как аргументы в методы:

```csharp
static void Invoke_Delegate(Print _del)
{
    _del?.Invoke();
}

// ...

Invoke_Delegate(sth);
```

## Обобщённые делегаты

```csharp

static int Squaring(int num)
{
    return num * num;
}

// ...

internal delegate T GDelegate<T>(T val);

// ...

GDelegate<int> sqDel = Squaring;

Console.WriteLine(sqDel(5)); // "25"
```
