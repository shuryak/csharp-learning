# Структуры

Структура — это набор типов данных, сгруппированных в одно целое. Интересно, что многие примитивные типы данных, например, `int`, `double` и т.д., представлены структурами. Структуры обладают большей частью синтаксиса классов, но имеют некоторые ограничения и особенности:

 - Поля (свойства) в объявлении структуры не могут быть инициализированы как `const`/`static`.
 - Структура не может объявлять деструктор или конструктор без параметров.
 - Конструктор структуры должен обязательно инициализировать все поля структуры.
 - Структуры копируются при присваивании. При присваивании структуры к переменной, копируется не ссылка на структуру, а сама структура. То есть любое изменение новой копии никак не влияет на исходную копию.
 - Структуры представлены значимыми типами, а классы — ссылочными.
 - Структура не может наследоваться от другой структуры или класса и не может быть базовой для класса. Все структуры наследуются от `ValueType`, который наследует от `Object`.
 - Структура не может быть `null`, если переменная, содержащая структру, не является типом, допускающим значение `null`.

Стоит отметить, что структуры могут реализовывать интерфейсы. А ещё переменные типа структуры могут работать без инициализации с помощью оператора `new` (в этом случае все поля структуры нужно будет проинициализировать явно).

## Создание структуры

Синтаксис структуры такой:

```csharp
struct Name
{
    // Здесь поля, методы, конструкторы (с параметрами)
}
```

Создадим структуру `Player`, описывающую игрока какой-то компьютерной игры. У него будут следующие поля:

 - Игровой ник (поле `Nickname`).
 - Игровой уровень (поле `Level`).
 - Количество опыта (поле `Xp`).

Структура будет выглядеть так:

```csharp
struct Player
{
    public string Nickname;
    public int Level;
    public int Xp;
}
```

Заметьте, что поля в структурах могут объявляться с модификаторами доступа.

Давайте теперь добавим конструктор к структуре:

```csharp
struct Player
{
    public Player(string nickname, int level)
    {
        Nickname = nickname;
        Level = level;
        Xp = level * 1000;
    }
    
    public string Nickname;
    public int Level;
    public int Xp;
}
```

Как уже упоминалось ранее, конструктор структуры **обязательно** должен инициализировать **все** поля структуры.

## Объявление структуры

### Объявление без оператора `new`

Выше сказано, что переменные типа структуры могут объявляться без оператора `new` (естественно, в таком случае, конструктор задействовать будет нельзя).

Объявим переменную `Mike` типа структуры `Player` таким образом:

```csharp
Player Mike;

Mike.Nickname = "Mike171293";
Mike.Level = 5;
Mike.Xp = 5067;
```

При такой инициализации нужно проинициализировать все поля структуры, иначе при получении значения непроинициализированного поля, получим ошибку:

```csharp
Player Mike;

Mike.Nickname = "Mike171293";
Mike.Level = 5;
Console.WriteLine(Mike.Xp); // ОШИБКА: Использование поля "Xp", которому, возможно, не присвоено значение
```

Если же все поля грамотно проинициализировать, следующий код отработает корректно:

```csharp
Console.WriteLine("Information about {0}:", Mike.Nickname); // Information about Mike171293:
Console.WriteLine("Level: {0}.", Mike.Level); // Level: 5.
Console.WriteLine("XP: {0}.", Mike.Xp); // XP: 5067.
```

### Объявление с оператором `new`

Объявление переменной типа структуры даёт парочку преимуществ:

 - Возможность использовать конструктор.
 - Автоматическое заполнение полей значениями по умолчанию (например, переменные-строки заполняются пустой строкой `""`, переменные-числа — нулём `0` и т.д.).

Объявим переменную `Harry` типа структуры `Player` при помощи оператора `new`:

```csharp
Player Harry = new Player("HarryGedon1", 8);
```

Следующий код заработает без проблем:

```csharp
Console.WriteLine("Information about {0}:", Harry.Nickname); // Information about HarryGedon1:
Console.WriteLine("Level: {0}.", Harry.Level); // Level: 8.
Console.WriteLine("XP: {0}.", Harry.Xp); // XP: 8000.
```

## Методы структур

Конечно, структуры могут содержать методы. Давайте к нашей структуре `Player` добавим метод `DisplayInfo()`, который будет отображать информацию об объекте структуры:

```csharp
public void DisplayInfo()
{
    Console.WriteLine("Information about {0}: Level {1}, {2} XP.", Nickname, Level, Xp);
}
```