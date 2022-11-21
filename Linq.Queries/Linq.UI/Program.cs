using Linq.DataAccess.DTOs;
using Linq.DataAccess.Entities;
using Linq.Queries;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Practicing Operators in Linq Queries.\n");

// Deferred queries

var operatorWhereQuery = Operators.QueryWhereShippers();

foreach (Shippers s in operatorWhereQuery)
{
    Console.WriteLine($"{s.ShipperId} - {s.CompanyName}");
}

// Filtering Operators

var ofTypeQuery = Operators.QueryOfType();

foreach (Person s in ofTypeQuery)
{
    Console.WriteLine(s.Name);
}

var whereQuery = Operators.QueryWhereAndOfType();

foreach (Person s in ofTypeQuery)
{
    Console.WriteLine($"\nName: {s.Name} - Gender: {s.Gender}");
}

// Sorting Operators

var orderByQueryShippers = Operators.QueryOrderByShippers();
var orderByQueryProducts = Operators.QueryOrderByProducts();

Console.WriteLine("Shippers ordered by CompanyName");
foreach (Shippers s in orderByQueryShippers)
{
    Console.WriteLine($"{s.ShipperId} - {s.CompanyName}");
}
Console.WriteLine("Products Ordered by Units in Stock");
foreach (ProductsDto p in orderByQueryProducts)
{
    Console.WriteLine($"{p.ProductId} - {p.ProductName}:\t {p.UnitsInStock}");
}

// Set Operators

var distinctQueryNumbers = Operators.QueryDistinctNumbers();
var distinctQueryPerson = Operators.QueryDistinctPersons();
Console.WriteLine("\n\nDistinct Operator:\n");
Console.WriteLine("\nDistinct on People (reference type) List");
foreach (Person person in distinctQueryPerson)
{
    Console.WriteLine(person.Name);
}
Console.WriteLine("\nDistinct on Number (value type) List");
foreach (var number in distinctQueryNumbers)
{
    Console.WriteLine(number);
}


var intersectQueryNumbers = Operators.QueryIntersectNumbers();
Console.WriteLine("\nIntersect Operator with numbers list");
foreach (var number in intersectQueryNumbers)
{
    Console.Write(number + " ");
}

var exceptQueryNumbers = Operators.QueryExceptNumbers();
Console.WriteLine("\nExcept Operator with numbers list\n");
foreach (var number in exceptQueryNumbers)
{
    Console.Write(number + " ");
}

// Quantification Operators

Console.WriteLine("\n\nQuantification Operators:\n");
var allQueryProducts = Operators.QueryAllStockProducts();
var anyQueryProducts = Operators.QueryAnyProductDiscontinued();
var containsQueryWord = Operators.QueryContainsWord("argentina, españa, brasil, uruguay", "brasi");

Console.WriteLine($"Products without stock? {(allQueryProducts ? "YES": "NO")}");
Console.WriteLine($"Any product discontinued? {(anyQueryProducts ? "YES" : "NO")}");
Console.WriteLine($"Are Brasil in the list? {(containsQueryWord ? "YES" : "NO")}\n\n");

// Projection Operators

Console.WriteLine("Projection Operators: Select & SelectMany:\n");
var queryWithSelectMany = Operators.QuerySelectMany();
var queryWithJustSelect = Operators.QueryJustSelect();
var queryBadSelect = Operators.QuerySelectBad();

Console.WriteLine("Query with SelectMany:");
Console.WriteLine(JsonSerializer.Serialize(queryWithSelectMany));
Console.WriteLine("\nQuery with Select only:");
Console.WriteLine(JsonSerializer.Serialize(queryWithJustSelect));
Console.WriteLine("\nQuery using Select bad:");
Console.WriteLine(JsonSerializer.Serialize(queryBadSelect));

// Partition Operators
Console.WriteLine("\n\nPartition Operators: Skip, SkipWhile, Take, TakeWhile\n\n");
var querySkip = JsonSerializer.Serialize(Operators.QuerySkipNumbers());
var querySkipWhile = JsonSerializer.Serialize(Operators.QuerySkipWhileNumbers());
var queryTake = JsonSerializer.Serialize(Operators.QueryTakeNumbers());
var queryTakeWhile = JsonSerializer.Serialize(Operators.QueryTakeWhileNumbers());

Console.WriteLine($"{querySkip}\n\n{querySkipWhile}\n\n{queryTake}\n\n{queryTakeWhile}");