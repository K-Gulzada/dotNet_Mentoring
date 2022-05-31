using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Where(c => c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null)
            {
                throw new ArgumentNullException();
            }

            return customers.Select(
                c => (
                    customer: c,
                    suppliers: suppliers.Where(s => s.Country == c.Country && s.City == c.City)));
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Select(
                c => (
                    customer: c,
                    suppliers: suppliers.Where(s => s.Country == c.Country && s.City == c.City)));
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Where(c => c.Orders.Length > 0 && c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Where(c => c.Orders.Count() > 0)
                            .Select(customer => (
                                    customer: customer,
                                    dateOfEntry: customer.Orders.OrderBy(order => order.OrderDate).First().OrderDate));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            var result = Linq4(customers);

            return result.OrderBy(item => item.dateOfEntry.Year)
                         .ThenBy(item => item.dateOfEntry.Month)
                         .ThenByDescending(item => item.customer.Orders.Sum(order => order.Total))
                         .ThenBy(item => item.customer.CompanyName);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            return customers.Where(c => c.PostalCode.Any(character => char.IsLetter(character))
                                         || String.IsNullOrEmpty(c.Region) || !c.Phone.Contains('('));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            var groupedProductsByCategory = products.GroupBy(product => product.Category);

            return groupedProductsByCategory.Select(group =>
                new Linq7CategoryGroup
                {
                    Category = group.Key,
                    UnitsInStockGroup =
                        group.GroupBy(product => product.UnitsInStock)
                            .Select(unit => new Linq7UnitsInStockGroup
                            {
                                UnitsInStock = unit.Key,
                                Prices = unit.OrderBy(product => product.UnitPrice)
                                             .Select(product => product.UnitPrice)
                            })
                });
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            var result = products.Select(
               product => (
                   category: product.UnitPrice,
                   products: products.Where(p => p.UnitPrice == cheap ||
                                           (p.UnitPrice == middle) ||
                                           (p.UnitPrice == expensive))));

            return result;
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            var groupedCustomersByCity = customers.GroupBy(customer => customer.City);

            return groupedCustomersByCity.Select(group => (
                city: group.Key,
                avarageIncome: (int)Math.Round(group.Average(cutomer => cutomer.Orders.Sum(order => order.Total))),
                averageIntensity: (int)Math.Round(group.Average(cutomer => cutomer.Orders.Count()))
            ));
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            if (suppliers == null)
            {
                throw new ArgumentNullException(nameof(suppliers));
            }

            return String.Join(
                separator: "",
                values: suppliers.Select(supplier => supplier.Country)
                                 .OrderBy(country => country.Length)
                                 .ThenBy(country => country)
                                 .Distinct());
        }
    }
}