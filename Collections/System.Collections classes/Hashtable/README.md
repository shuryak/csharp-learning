# Класс Hashtable

Класс `Hashtable` предоставляет возможность создавать коллекции, данные которых представлены в виде паре "ключ — значение", т.е. в виде хэш-таблицы, где доступ к какому-то блоку информации (значению ключа) осуществляется с помощью ключа. Механизм сохранения данных в хеш-таблице называется *хешированием*. Хеширование — процесс присвоения уникального (неповторимого) значения (*хеш-кода*) блоку информации. Полученный хеш-код служит в качестве индекса, по которому обеспечивается доступ к блоку информации. Хеш-код автоматически генерируется из ключа, поэтому программист не видит и не взаимодействует с хеш-кодами напрямую, а просто использует ключ для. 

Массив тоже, своего рода, хеш-таблица, только без хеширования, где ключами являются индексы, а значениями — информация, соответствующая индексам.

Класс `Hashtable` реализует интерфейсы `ICollection`, `IDictionary`, `IEnumerable`, `ICloneable`, `IDeserializationCallback`, `ISerializable`.

## Методы Hashtable

Основные методы класса `Hashtable`:

 - `Add()` — добавляет значение, переданное в качестве второго параметра по ключу, переданному в качестве первого параметра;
 - `ContainsKey()` — возвращает `true`, если в хеш-таблице содержится ключ, переданный в качестве параметра, иначе возвращает `false`;
 - `ContainsValue()` — возвращает `true`, если в хеш-таблице содержится значение, переданное в качестве параметра, иначе возвращает `false`.

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.collections.hashtable).

## Свойства Hashtable

Основные свойства класса `Hashtable`:

 - `Count` - хранит количество пар "ключ — значение".
 - `Keys` - хранит коллекцию `ICollection`, содержащую ключи коллекции `Hashtable`.
 - `Values` - хранит коллекцию `ICollection`, содержащую значения коллекции `Hashtable`.

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.collections.hashtable).

## Получение значения по ключу

Создадим коллекцию `Hashtable`:

```csharp
Hashtable hash = new Hashtable();
```

Добавим три пары "ключ — значение":

```csharp
hash.Add("one", 1);
hash.Add("two", 2);
hash.Add("three", 3);
```

`1`, `2`, `3` — это значения, а `one`, `two`, `three` — это их ключи соответственно.

Чтобы получить, например, значение `2`, нужно знать его ключ (`two`):

```csharp
Console.WriteLine(hash["two"]); // 2
```

## Перебор элементов хеш-таблицы

Предположим, у нас есть класс `Person`:

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
}
```

И есть хеш-таблица `hash` с шестью парами "ключ — значение":

```csharp
Hashtable hash = new Hashtable();

hash.Add("James", new Person("James", "Brooks"));
hash.Add("Veronica", new Person("Veronica", "Tucker"));
hash.Add("Michael", new Person("Michael", "Charles"));
hash.Add("Nancy", new Person("Nancy", "Stafford"));
hash.Add("Scott", new Person("Scott", "Barton"));
hash.Add("Julia", new Person("Julia", "Patterson"));
```

Как перебрать элементы данной хеш-таблицы?

### Перебор только ключей хеш-таблицы

```csharp
foreach (object p in hash.Keys)
{
    Console.WriteLine(p.ToString());
}
```

### Перебор только значений хеш-таблицы

```csharp
foreach (Person p in hash.Values)
{
    Console.WriteLine(p.Firstname + " " + p.Lastname);
}
```

### Перебор ключей и значений хеш-таблицы

```csharp
foreach (object key in hash.Keys)
{
    Person p = (Person)hash[key];
    Console.WriteLine(key + " — " + p.Firstname + " " + p.Lastname);
}
```