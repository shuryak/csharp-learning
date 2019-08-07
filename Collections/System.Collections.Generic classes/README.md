# Классы System.Collections.Generic

Пространство имён `System.Collections.Generic` содержит классы простых [обощённых](https://github.com/shuryak/csharp-learning/tree/master/OOP/Generics) коллекций. Эти коллекции, в отличие от коллекций класса `System.Collections` (где элементы представлены типом `Object`), являются типизированными. Их типизиция возможна, потому что коллекции являются [обощёнными](https://github.com/shuryak/csharp-learning/tree/master/OOP/Generics), можно явно указать, для какого типа данных создаётся коллекция.

## Основные классы коллекций System.Collections.Generic

 - `List<T>` — коллекция в виде однонаправленного списка;
 - `LinkedList<T>` — коллекция в виде двунаправленного (двусвязного) списка, где каждый элемент хранит ссылку одновременно на следующий и предыдущий элемент в списке;
 - `Queue<T>` — коллекция в виде очереди, использует принцип ***FIFO*** (***F**irst-**i**n*, ***F**irst-**o**ut* — первым пришёл, первым ушёл) — элементы добавляются в конец, а берутся с начала;
 - `Stack<T>` — коллекция в виде стека, использует принцип ***LIFO*** (***L**ast-**i**n*, ***F**irst-**o**ut* — последним пришёл, первым ушёл) — элементы добавляются в конец, берутся тоже с конца.

## Создание строго типизированного списка

Для того, чтобы создать строго типизированный список одного из перечисленных выше классов, используется следующий формат:

```csharp
Список<тип> название;
```

Здесь `Список` — это один из классов, перечисленных выше, `тип` — тип данных, элементы которого будут хранится в списке, `название` — произвольное название переменной списка;