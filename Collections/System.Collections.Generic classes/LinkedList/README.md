# Класс `LinkedList<T>`

Класс `LinkedList<T>` позволяет реализовать *типизированный* двунаправленный (двусвязный) список. Двусвязный список подразумевает, что *каждый элемент* хранит *ссылки* *одновременно* на *следующий* и *предыдущий* элемент. Реализует интерфейсы `ICollection<T>`, `IEnumerable<T>`, `IReadOnlyCollection<T>`, `ICollection`, `IEnumerable`, `IDeserializationCallback`, `ISerializable`.

В простом списке `List<T>` каждый элемент представлен типом `T`, в `LinkedList<T>` же каждый узел представляет объект класса `LinkedListNode<T>`.

## `LinkedListNode<T>`

Класс `LinkedListNode<T>` имеет следующие свойства:

 - `Value` — хранит само значение узла;
 - `Next` — хранит ссылку на следующий элемент типа `LinkedListNode<T>` в списке. Если таковой отсутствует, то `null`;
 - `Previous` — хранит ссылку на предыдущий элемент типа `LinkedListNode<T>` в списке. Если таковой отсутствует, то `null`.

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.collections.generic.linkedlistnode-1).

## `LinkedList<T>`

Методы класса `LinkedList<T>` позволяют обращаться к элементам массива:

 - `AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)` — добавляет в список узел `newNode` после узла `node`;
 - `AddAfter(LinkedListNode<T> node, T value)` — добавляет в список узел со значением `value` после узла `node`;
 - `AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)` — добавляет узел `newNode` перед узлом `node`;
 - `AddBefore(LinkedListNode<T> node, T value)` — добавляет в список новый узел со значением `value` перед узлом `node`;
 - `AddFirst(LinkedListNode<T> node)` — добавляет новый узел `node` в начало списка;
 - `AddFirst(T value)` — добавляет новый узел со значением `value` в начало списка;
 - `AddLast(LinkedListNode<T> node)` — добавляет новый узел `node` в конец списка;
 - `AddLast(T value)` — добавляет новый узел со значением `value` в конец списка;
 - `RemoveFirst()` — удаляет первый узел из списка. После этого новым первым узлом становится узел, следующий за удалённым;
 - `RemoveLast()` — удаляет последний узел из списка.

Подробнее на [Microsoft Docs](https://docs.microsoft.com/dotnet/api/system.collections.generic.linkedlist-1).