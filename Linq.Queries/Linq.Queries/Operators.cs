using Linq.DataAccess;
using Linq.DataAccess.Entities;
using Linq.DataAccess.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Queries
{
    public static class Operators
    {
        public static NorthwindContext _context = new NorthwindContext();
        public static ArrayList ListWithVariedData = new ArrayList
        {
            "Im just string",
            "Im another string",
            2232,
            666,
            new Object(),
            new Person
            {
                Name = "Leopoldo",
                Gender = "Male"
            },
            new Person
            {
                Name = "Mary",
                Gender = "Female"
            },
            new Person
            {
                Name = "Luciana",
                Gender = "Female"
            },
            new Person
            {
                Name = "Omar",
                Gender = "Male"
            },
             new Person
            {
                Name = "Leopoldo",
                Gender = "Male"
            }
        };
        public static List<Person> People = new List<Person>
        {
            new Person
            {
                Name = "Leopoldo",
                Gender = "Male"
            },
            new Person
            {
                Name = "Mary",
                Gender = "Female"
            },
            new Person
            {
                Name = "Luciana",
                Gender = "Female"
            },
            new Person
            {
                Name = "Omar",
                Gender = "Male"
            },
             new Person
            {
                Name = "Leopoldo",
                Gender = "Male"
            }
        };

        // Filtering Operators
        public static IEnumerable QueryOfType()
        {
            var query = from person in ListWithVariedData.OfType<Person>()
                        select person;

            return query;
        }

        public static IEnumerable QueryWhereAndOfType()
        {
            var query = from person in ListWithVariedData.OfType<Person>()
                        where person.Gender == "Female"
                        select person;

            return query;
        }

        public static IEnumerable<Shippers> QueryWhereShippers()
        {
            var query = from shipper in _context.Shippers
                        where shipper.CompanyName.Contains("Speedy")
                        select shipper;
            return query;
        }


        // Sorting Operators
        public static IEnumerable<Shippers> QueryOrderByShippers()
        {
            return _context.Shippers.OrderBy(shipper => shipper.CompanyName);
        }

        public static IEnumerable<ProductsDto> QueryOrderByProducts()
        {
            var query = from product in _context.Products
                        orderby product.UnitsInStock
                        select new ProductsDto
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            UnitsInStock = product.UnitsInStock,
                        };

            return query;
        }

        // Set Operators
        public static IEnumerable<Person> QueryDistinctPersons()
        {
            var query = (from p in People
                         select new { p.Name, p.Gender }) // Using anonymous type can distintct Person instances with same values
                        .Distinct()
                        .Select(p => new Person { Name = p.Name, Gender = p.Gender });
            return query;
        }

        public static IEnumerable<int> QueryDistinctNumbers()
        {
            var list = new List<int> { 1, 1, 1, 6, 3, 5, 5, 66, 64, 3, 4, 3, 4, 1 };
            return list.Distinct();
        }


        public static IEnumerable<int> QueryIntersectNumbers()
        {
            var listA = new List<int> { 1, 2, 3, 4, 5 };
            var listB = new List<int> { 1, 2, 7, 8, 9, 5 };

            // Return elements that are in listA and also in listB
            // {1, 2, 5 }
            return listA.Intersect(listB);
        }

        public static IEnumerable<int> QueryExceptNumbers()
        {
            var listA = new List<int> { 1, 2, 3, 4, 5 };
            var listB = new List<int> { 1, 2, 7, 8, 9, 5 };

            return listA.Except(listB);
        }

        // Quantification Operators - return boolean values
        public static bool QueryAllStockProducts()
        {
            return _context.Products.All(p => p.UnitsInStock == 0);

        }

        public static bool QueryAnyProductDiscontinued()
        {
            return _context.Products.Any(p => p.Discontinued);
        }

        public static bool QueryContainsWord(string wordList, string wantedWord)
        {
            return wordList.Contains(wantedWord);
        }

        // Projection Operators

        // SelectMany => obtain one secuence from various sub-sequences. Many inputs => One OutPut
        public static IEnumerable<string> QuerySelectMany()
        {
            string[] randomNames = new string[] {
                "Marcelo,Juan,Omar,Gomez",
                "Omar,Julio,Marcelo,Julian,Mariano"
            };

            return randomNames
                .SelectMany(n => n.Split(','))
                .Distinct();
        }

        public static IEnumerable<string> QueryJustSelect()
        {
            string[] randomNames = new string[] {
                "Marcelo,Juan,Omar,Gomez",
                "Omar,Julio,Marcelo,Julian,Mariano"
            };

            return (from str in randomNames
                   from name in str.Split(',')
                   select name).Distinct();
        }

        // The same output of code above, but with Select operator. Is not posible, instead of words we return a collection of string-arrays.
        // Select operator project one output object for each input object.
        public static IEnumerable<string[]> QuerySelectBad()
        {
            string[] randomNames = new string[] {
                "Marcelo,Juan,Omar,Gomez",
                "Omar,Julio,Marcelo,Julian,Mariano"
            };

            return randomNames
                .Select(str => str.Split(','))
                .Distinct();
        }

        // Partition Operators. Skip & Take

        public static IEnumerable<int> QuerySkipNumbers()
        {
            var numbers = Enumerable.Range(0, 100);

            return numbers.Skip(20);
        }

        public static IEnumerable<int> QuerySkipWhileNumbers()
        {
            var numbers = Enumerable.Range(0, 100);

            return numbers.SkipWhile(n => n < 95);
        }

        public static IEnumerable<int> QueryTakeNumbers()
        {
            var numbers = Enumerable.Range(0, 100);

            return numbers.Take(20);
        }

        public static IEnumerable<int> QueryTakeWhileNumbers()
        {
            var numbers = Enumerable.Range(0, 100);

            return numbers.TakeWhile(n => n < 5);
        }

        // Join Operators


    }

    // Auxiliary Resources 

    public class Person
    {
        public string Name { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
    }
}
