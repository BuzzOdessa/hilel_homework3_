// See https://aka.ms/new-console-template for more information

using System.Text;


Console.OutputEncoding = Encoding.UTF8; // Інакше українське "і" не виводилось.


static void StartTask(string msg)
{
    Console.WriteLine(msg);
    Console.WriteLine("----------------");
}

static void EndTask()
{
    Console.WriteLine("----------------");
    Console.WriteLine();
}
static void Print<T>(IEnumerable<T> source, string msg = "")
{
    var result = string.Join(", ", source);
    msg = msg.Length > 0 ? msg + ": " : "";
    Console.WriteLine($"{msg}{result}");
}

//Написати програму на C#, яка отримує набір рядків зі словами та фільтрує лише ті, які починаються з літери "A". Вивести результат на екран.
static void FilterA(string[] words)
{
    var results = words.Where(word => word.StartsWith('A'));
    Print(results, "Результат");
}


//Створити два масиви цілих чисел різної довжини. Використовуючи LINQ, знайти всі значення, які містяться в обох масивах та відобразити їх на екран.
static void IntersectArrays(int[] arr1, int[] arr2)
{
    var intersect = arr1.Intersect(arr2);
    Print(intersect, "Результат");
}


StartTask("Слова які починаються з літери \"A\"");
string[] strArray = ["Angel", "Diablo", "Nothing", "All", "Array"];
Print(strArray, "Для масива");
FilterA(strArray);
EndTask();

StartTask("всі значення, які містяться в обох масивах");
//Створити два масиви цілих чисел різної довжини.
int[] arr1 = [0, 1, 3, 4, 10];
int[] arr2 = [1, 2, 3, 10];

Print(arr1, "Для масивів");
Print(arr2, "           ");
IntersectArrays(arr1, arr2);
EndTask();