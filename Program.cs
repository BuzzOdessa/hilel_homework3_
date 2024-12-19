using System.Text;
using HomeWork_3;


#region Вызов  решения
Console.OutputEncoding = Encoding.UTF8; // Інакше українське "і" не виводилось.
Console.Title = "Домашка №3";


FilterA(["Angel", "Diablo", "Nothing", "All", "Array", "Impossible"]);
InterSectArrays();
MaxGradeStudent();
AvgProductCategoryPrice();
FiveYearEmployees();
BookAfter2010();
Customers1000();

Console.ReadKey();
#endregion



#region Собственно имплементация вызываемых метод

//Написати програму на C#, яка отримує набір рядків зі словами та фільтрує лише ті, які починаються з літери "A". Вивести результат на екран.
static void FilterA(string[] strArray)
{

    StartTask("Слова які починаються з літери \"A\"");
    //string[] strArray = ["Angel", "Diablo", "Nothing", "All", "Array"];
    PrintArray(strArray, "Отриманий масив");
    var results = strArray.Where(word => word.StartsWith('A'));
    PrintArray(results, "Результат");
    EndTask();
}
//Створити два масиви цілих чисел різної довжини. Використовуючи LINQ, знайти всі значення, які містяться в обох масивах та відобразити їх на екран.
void InterSectArrays()
{
    StartTask("Всі значення, які містяться в обох масивах");
    //Створити два масиви цілих чисел різної довжини.
    int[] arr1 = [0, 1, 3, 4, 10, 88, -1];
    int[] arr2 = [1, 2, 3, 10, -1];

    PrintArray(arr1, "Два масиви:");
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
    PrintCollection(students, "Усі студенти:");

    // Собственно поиск студента с макс оценкой
    var result = students.OrderByDescending(s => s.Grade).FirstOrDefault();
    if (result != null)
    {
        Console.WriteLine($"Результат: {result}");
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

    PrintCollection(products, "Усі продукти:");

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
        Console.WriteLine($" {group.Category} - {group.AvgPrice}");
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
    PrintCollection(employees, "Усіх робітники:");

    var results = employees.Where(e => e.EmploymentDate < DateTime.Today.AddMonths(-12 * 5));
    PrintCollection(results.ToList(), "Результат:");

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

void BookAfter2010()
{
    StartTask("знайти книги, які були видані після 2010 року та належать до жанру \"Фантастика");
    var books = InitTestData();
    PrintCollection(books, "Усі книги:");

    var results = books.Where(e => e.PublishYear > 2010 && e.Genre == "Фантастика");
    PrintCollection(results.ToList(), "Результат:");

    EndTask();

    List<Book> InitTestData()
    {
        return
        [
             new Book() { Title = "Дважды два равно четыре", Author = "Коллектив авторов", Genre = "Фантастика", PublishYear = 2011 }
           , new Book() { Title = "Путь Сусанина", Author = "Агния Барто", Genre = "Наукова література", PublishYear = 2009 }
           , new Book() { Title = "С# для чайников", Author = "Клопотенко", Genre = "Кулинария", PublishYear = 2023 }
           , new Book() { Title = "Спасти рядового Кота", Author = "Шредингер", Genre = "Фантастика", PublishYear = 2018 }
        ];
    }
}

void Customers1000()
{
    StartTask("знайти клієнтів, які зробили замовлення на суму більше 1000 грн та вивести їх замовлення у вигляді переліку");
    var customers = InitTestData();
    PrintCollection(customers, "Усі замовники:");

    var results = customers
    .Select(c => new
    {
        c.FirstName,
        c.LastName,
        c.Address,
        c.Orders,
        TotalSpent = c.Orders.Sum(o => o.Amount)
    }
    );

    results = results.Where(r => r.TotalSpent > 1000);

    if (!results.Any())
    {
        Console.WriteLine("Нема замовників з замовленнямы більш чим на 1000 грн. ");
    }
    else
    {
        Console.WriteLine("Результат:");
        foreach (var customer in results)
        {
            Console.WriteLine($"Замовник: {customer.FirstName} {customer.LastName} ");
            PrintCollection(customer.Orders, "Замовлення:");
        }
    }
    EndTask();

    List<Customer> InitTestData()
    {
        return
        [
              new Customer() {Address = "місто Одеса", FirstName = "Іван", LastName = "Іванов",
                Orders = {
                         new Order { Amount = 100.10m, Goods ="Тушеночка" , OrderDate = new DateTime(2024, 11, 15)}
                       , new Order { Amount = 960.30m, Goods ="Тушенище" , OrderDate = new DateTime(2024, 11, 01)}
                }
              }
            , new Customer() {Address = "село Якесь", FirstName = "Петро", LastName = "Петров"
               , Orders = {
                         new Order { Amount = 500, Goods ="Книжка" , OrderDate = new DateTime(2024, 10, 25)}
                 }
             }
            , new Customer() {Address = "село Якесь", FirstName = "Семен", LastName = "Семенюк"
               , Orders = {
                         new Order { Amount = 1500, Goods ="Пиво", OrderDate = new DateTime(2024, 11, 2)}
                 }
             }
        ];
    }
}
#endregion

#region Всякого рода  рутины
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


static void PrintCollection<T>(List<T> collection, string msg = "")
{
    if (msg.Length > 0)
        Console.WriteLine(msg);
    foreach (var obj in collection)
    {
        Console.WriteLine($"  {obj?.ToString()}");
    }
    Console.WriteLine();
}
#endregion
