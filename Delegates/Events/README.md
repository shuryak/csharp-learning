# События

События – инструмент установки автоматического уведомления 
*объектов-подписчиков* из *объектов-издателей* об определённых изменениях.

**Примечание**: *объекты-подписчики* – объекты, "подписанные" на 
*объекты-издатели*, подготовленные для обработки определённых 
событий *объектов-издателей*; *объекты-издатели* – объекты, генерирующие 
события.

Синтаксис определения событий:

```csharp
event делегатСобытия имяСобытия;
```

## Событие с делегатом "по-умолчанию"

**Код данного раздела находится в папке `EventsIntro`**

Если нужно использовать событие без каких-либо данных о нём, можно использовать 
`EventHandler` – стандартный делегат ([подробнее](https://docs.microsoft.com/ru-ru/dotnet/api/system.eventhandler "EventHandler")), 
имеющий следующую сигнатуру:

```csharp
// EventHandler принадлежит пространству имён System

public delegate void EventHandler(object sender, EventArgs e);

/*
sender – источник события, объект, где событие сгенерированно;
e – объект, НЕ содержащий данных о событии.
*/
```

Вообще, `EventHandler` является эталоном для пользовательских делегатов: 
они должны первым параметром принимать *источник события*, а вторым – объект 
`EventArgs` (или производного класса), но уже содержащий данные о событии.

Рассмотрим пример:

Есть класс `Person`:

```csharp
public class Person
{
    public event EventHandler AgeChanged; // Событие AgeChanged для стандартного делегата

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
        
    public string FirstName { get; set; }

    public string LastName { get; set; }

    private int age;
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0) throw new Exception("Age can't be negative.");

            age = value;

            /*
            Если событие содержит обработчики (!= null), вызываем событие 
            (а соответственно вызываем обработчики) AgeChanged:
            */
            if (AgeChanged != null) AgeChanged(this, new EventArgs());
        }
    }
}
```

Теперь поработаем с классом `Person` извне:

```csharp
Person paul = new Person("Paul", "Weaver", 24);

paul.AgeChanged += AgeChanged; // добавляем обработчик AgeChanged() для события AgeChanged объекта paul класса Person

paul.Age = 30;
paul.Age = 45;
paul.Age = 27;

Console.Read();

// ...

private static void AgeChanged(object sender, EventArgs args) // обработчик, подходящий по сигнатуре для EventHandler
{
    Person curState = (Person)sender;
    Console.WriteLine($"Age changed to {curState.Age}.");
}
```

## Событие с пользовательским делегатом

**Код данного раздела находится в папке `EventsProject`**

Определим класс `Person`:

```csharp
public class Person
{
    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public delegate void NameChanged(object sender, NameChangedArgs args);  // Определяем пользовательский делегат NameChanged с параметрами sender (источник для события) и args (данными для события)

    public event NameChanged FirstNameChanged; // Определяем событие на основе делегата NameChanged
    public event NameChanged LastNameChanged; // Определяем событие на основе делегата NameChanged

    private string firstName;
    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (FirstNameChanged != null)
            {
                /* смотреть в листинг ниже (класс NameChangedArgs) */
                NameChangedArgs changeArgs = new NameChangedArgs(value,
                    NameChangedArgs.NameChangingType.FirstName /* <- Тип изменяего имени (FirstName / LastName) */
                );

                FirstNameChanged(this, changeArgs); // генерируем (выбрасываем) событие изменения имени

                if (changeArgs.Canceled) return; // Если изменение отклонено, то выходим из метода...

                this.firstName = value; // ...иначе присваиваем новое значение
            }
        }
    }

    private string lastName;
    public string LastName
    {
        get { return lastName; }
        set
        {
            if (LastNameChanged != null)
            {
                /* смотреть в листинг ниже (класс NameChangedArgs) */
                NameChangedArgs changeArgs = new NameChangedArgs(value,
                    NameChangedArgs.NameChangingType.LastName /* <- Тип изменяего имени (FirstName / LastName) */
                );

                LastNameChanged(this, changeArgs); // генерируем (выбрасываем) событие изменения фамилии

                if (changeArgs.Canceled) return; // Если изменение отклонено, то выходим из метода...

                this.lastName = value; // ...иначе присваиваем новое значение
            }
        }
    }

    public string GetFullName()
    {
        return FirstName + " " + LastName;
    }
}
```

Класс `NameChangedArgs` на основе `EventArgs` (базового класса данных о 
событии, [подробнее](https://docs.microsoft.com/ru-ru/dotnet/api/system.eventargs "EventArgs")):

```csharp
public class NameChangedArgs: EventArgs // Класс NameChangedArgs наследуется от EventArgs
{
    public NameChangedArgs(string newName, NameChangingType nameType)
    {
        NewName = newName;
        NameType = nameType;
        Canceled = false;
    }

    public string NewName { get; set; }

    public bool Canceled { get; set; } // Отменить изменения (true) / отклонить изменения (false)

    public enum NameChangingType { FirstName, LastName } // Перечисление возможных типов изменения имени ( FirstName (имя) NameType/ LastName (фамилия))
    public NameChangingType NameType{ get; set; }
}
```

Отлавливаем события и реагируем на них:

```csharp
Person paul = new Person("Paul", "Weaver");

paul.FirstNameChanged += FirstNameChanged; // добавляем обработчик события FirstNameChanged
paul.LastNameChanged += LastNameChanged; // добавляем обработчик события LastNameChanged

paul.FirstName = "Calvin"; // изменяем поле FirstName, обработчик FirstNameChanged сразу реагирует
paul.LastName = "Foster"; // изменяем поле LastName, обработчик LastNameChanged сразу реагирует

Console.WriteLine(paul.GetFullName());

// ...

static void FirstNameChanged(object sender, NameChangedArgs args)
{
    Person prevState = (Person)sender;

    Console.WriteLine($"Allow changing the first name from {prevState.FirstName} to {args.NewName}? (y / n)");

    bool userResponse = Console.ReadLine() == "n" ? true : false;

    if (userResponse) args.Canceled = true;
}

static void LastNameChanged(object sender, NameChangedArgs args)
{
    Person prevState = (Person)sender;

    Console.WriteLine($"Allow changing the last name from {prevState.LastName} to {args.NewName}? (y / n)");

    bool userResponse = Console.ReadLine() == "n" ? true : false;

    if (userResponse) args.Canceled = true;
}
```
