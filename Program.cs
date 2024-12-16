using System.Text;
using HomeWork_3;

Console.OutputEncoding = Encoding.UTF8; // Інакше українське "і" не виводилось.
FilterA();
InterSectArrays();
MaxGradeStudent();
AvgProductCategoryPrice();
FiveYearEmployees();

// Ниже собственно имплементация вызываемых метод

//Написати програму на C#, яка отримує набір рядків зі словами та фільтрує лише ті, які починаються з літери "A". Вивести результат на екран.
static void FilterA()
{

    StartTask("Слова які починаються з літери \"A\"");
    string[] strArray = ["Angel", "Diablo", "Nothing", "All", "Array"];
    PrintArray(strArray, "Для масива");
    var results = strArray.Where(word => word.StartsWith('A'));
    PrintArray(results, "Результат");
    EndTask();
}
//Створити два масиви цілих чисел різної довжини. Використовуючи LINQ, знайти всі значення, які містяться в обох масивах та відобразити їх на екран.
void InterSectArrays()
{
    StartTask("всі значення, які містяться в обох масивах");
    //Створити два масиви цілих чисел різної довжини.
    int[] arr1 = [0, 1, 3, 4, 10];
    int[] arr2 = [1, 2, 3, 10];

    PrintArray(arr1, "Для масивів");
    PrintArray(arr2, "           ");
    var intersect = arr1.Intersect(arr2);
    PrintArray(intersect, "Результат");
    EndTask();
}

//Написати програму, яка створює колекцію об'єктів класу Student, в яких є поля "Ім'я", "Прізвище" та "Оцінка". Використовуючи LINQ, знайти студента з максимальною оцінкою та вивести його на екран.
void MaxGradeStudent()
{
    StartTask("Знайти студента з максимальною оцінкою та вивести його на екран.");
    var students = InitTestData();
    PrintCollection(students, "Список студентів:");

    // Собственно поиск студента с макс оценкой
    var result = students.OrderByDescending(s => s.Grade).FirstOrDefault();
    if (result != null)
    {
        result.PrintInfo("Результат:");
    }
    else
    {
        Console.WriteLine("Список студентів пустий.");
    }
    EndTask();

    List<Student> InitTestData()
    {
        return
        [
           new Student() { FirstName = "Иван", LastName = "Помидоров", Grade = 39 }
         , new Student() { FirstName = "Олексій", LastName = "Іваненко", Grade = 80 }
         , new Student() { FirstName = "Васісуалій", LastName = "Лоханкін", Grade = 50 }
        ];
    }
}


//Створити колекцію об'єктів класу Product, в яких є поля "Назва", "Ціна" та "Категорія". Використовуючи LINQ, згрупувати продукти за категорією та обчислити середню ціну кожної категорії
void AvgProductCategoryPrice()
{
    StartTask("згрупувати продукти за категорією та обчислити середню ціну кожної категорії.");
    var products = InitTestData();

    PrintCollection(products, "Список продуктів:");

    var groups = products
        .GroupBy(p => p.Category, r => r.Price)
        .Select(g => new
        {
            Category = g.Key,
            AvgPrice = g.Average()
        }
     )
    ;

    Console.WriteLine("Середні ціни кожної категорії:");
    foreach (var group in groups)
    {
        Console.WriteLine($"{group.Category} середня ціна {group.AvgPrice}");
    }
    EndTask();

    List<Product> InitTestData()
    {
        return
        [
            new Product() { Category = "Еда", Name = "Хлеб", Price = 20.00m }
          , new Product() { Category = "Еда", Name = "Говядина", Price = 200.00m }
          , new Product() { Category = "Еда", Name = "Свинина", Price = 300.00m }
          , new Product() { Category = "Алкоголь", Name = "Водка", Price = 300.00m }
          , new Product() { Category = "Алкоголь", Name = "Пиво", Price = 100.00m }
          , new Product() { Category = "Канцтовары", Name = "Ручка", Price = 50.50m }
          , new Product() { Category = "Канцтовары", Name = "Тетрадь", Price = 150.50m }
        ];
    }
}

//  
static void FiveYearEmployees()
{
    StartTask("знайти робітників, які працюють в компанії більше 5 років.");
    var employees = InitTestData();
    PrintCollection(employees, "Список робітників:");

    var results = employees.Where(e => e.EmploymentDate < DateTime.Today.AddMonths(-12 * 5));
    PrintCollection(results, "Результат:");

    EndTask();

    List<Employee> InitTestData()
    {
        return
        [
           new Employee() { FirstName = "Александр", LastName = "Александров", BirthDate = new DateTime(2000, 3, 15), EmploymentDate = new DateTime(2021, 4, 5)}
         , new Employee() { FirstName = "Петр", LastName = "Петров", BirthDate = new DateTime(1998, 3, 15), EmploymentDate = new DateTime(2018, 11, 25)}
         , new Employee() { FirstName = "Иван", LastName = "Иванов", BirthDate = new DateTime(1995, 3, 15), EmploymentDate = new DateTime(2017, 1, 1)
        }
       ];
    }
}

// Всякого рода  рутины
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
static void PrintArray<T>(IEnumerable<T> source, string msg = "")
{
    var result = string.Join(", ", source);
    msg = msg.Length > 0 ? msg + ": " : "";
    Console.WriteLine($"{msg}{result}");
}

static void PrintCollection<T>(IEnumerable<T> collection, string msg = "") where T : IConsoleOutput
{
    if (msg.Length > 0)
        Console.WriteLine(msg);
    foreach (var obj in collection)
    {
        obj.PrintInfo("");
    }
    Console.WriteLine();
}
