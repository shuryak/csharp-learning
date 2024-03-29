﻿# Многомерные массивы

Массивы характеризуются понятием *ранг*. *Ранг* показывает количество измерений в массиве. То есть, *двумерный массив* имеет *ранг 2*, а *трёхмерный массив* — *3*. По аналогии, одномерный (обычный) массив имеет *ранг 1*.

## Создание многомерных массивов

### Одномерный (обычный) массив из 5 целых чисел
```csharp
int[] myArray = new int[5];
```

В графическом представлении он выглядит так:

![Одномерный массив из 5 целых чисел.](https://github.com/shuryak/csharp-learning/blob/master/Images%20for%20README/1D.png?raw=true)

### Двумерный массив 3×4 целых чисел

```csharp
int[,] myArray = new int[3, 4];
```

В графическом представлении он выглядит так:

![Двумерный массив 3×4 целых чисел.](https://github.com/shuryak/csharp-learning/blob/master/Images%20for%20README/2D.png?raw=true)

### Трёхмерный массив 2×4×3 целых чисел

```csharp
int[,,] myArray = new int[2, 4, 3];
```

В графическом представлении он выглядит так:

![Трёхмерный массив 2×4×3 целых чисел.](https://github.com/shuryak/csharp-learning/blob/master/Images%20for%20README/3D.png?raw=true)

То есть, одна запятая в квадратных скобках значит, что измерений два (массив двумерный), две запятые значат, что измерений три (массив трёхмерный) и т.д. Но почему количество запятых не совпадает с количеством измерений массива. Ответ на этом изображении:

![Длины измерений указываются через запятую.](https://github.com/shuryak/csharp-learning/blob/master/Images%20for%20README/commas.png?raw=true)

## Способы инициализации многомерных массивов

Рассмотрим способы инициализации многомерных массивов на примере двумерного массива `Array2D` (способы применимы ко всем многомерным массивам):

 - ```csharp
   int[,] Array2D = new int[3, 2];
   ```
	Чтобы заполнить массив числами от 1 до 6, инициализированный таким образом, можно воспользоваться циклами:
    
	```csharp
	for (int i = 0; i < Array2D.GetLength(0); i++)
    {
        for (int j = 0; j < Array2D.Length / Array2D.GetLength(0); j++)
        {
            Array2D[i, j] = v;
            v++;
        }
	}
	```

 - ```csharp
   int[,] Array2D = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
   ```
 - ```csharp
   int[,] Array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
   ```
 - ```csharp
   int[,] Array2D = new[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
   ```
 - ```csharp
   int[,] Array2D = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
   ```

## Обращение к многомерным массивам

Допустим, у нас есть двумерный целочисленный массив 3×4:

```csharp
int[,] myArray = new int[3, 4]
{
    { 1, 2, 3, 4 },
    { 5, 6, 7, 8 },
    { 9, 10, 11, 12 }
}; // Фигурные скобки в несколько строк для удобства
```

Чтобы получить последний элемент (содержащий 12), нужно написать следующее:

```csharp
Console.WriteLine(myArray[2, 3]);
```

А почему не `[3,4]`? А потому что массивы нумеруются, начиная с 0.
Например, чтобы получить элемент, содержащий значение 5, нужно написать:

```csharp
Console.WriteLine(myArray[1, 0]);
```

А чтобы получить нулевой элемент (который стоит в самом начале и содержит число 1), нужно написать:

```csharp
Console.WriteLine(myArray[0, 0]);
```

## Перебор многомерных массивов с помощью `foreach`

Длина многомерного массива (`myArray.Length`) — это общее количество элементов массива.
Возьмём следующий массив: 

```csharp
int[,] myArray = new int[3, 4]
{
    { 1, 2, 3, 4 },
    { 5, 6, 7, 8 },
    { 9, 10, 11, 12 }
};
```

То есть, длина этого массива равна 12 (12 элементов в массиве), то есть, задача перебора этого массива по измерениям с помощью `foreach` становится проблематичной.

### Полезные методы

 - `GetUpperBound()` — метод для получения последнего индекса в указанном измерении.
 - `GetLowerBound()` — метод для получения начального индекса в указанном измерении.

### Полезные свойства

 - `Rank` — свойство, хранящее ранг массива.

Используем циклы for для вывода массива в консоль по измерениям:

```csharp
for (int i = 0; i < myArray.GetUpperBound(0) + 1; i++)
{
    for (int j = 0; j < (myArray.GetUpperBound(1) + 1); j++)
    {
        Console.Write(myArray[i, j] + "\t");
    }
    Console.WriteLine();
}
```