## 2) 

A good approach is to store the data in memory to reduce database queries, updating the cache only when the data changes.  
With multiple instances, each would have its own copy in memory, which can be avoided by using a distributed cache like Redis.

---

## 3) 

The method iterates through a list of invoices and, for each one, retrieves the customer from the database, updates their balance in memory, and then saves the changes. This means that, with 100 invoices, there would be 100 queries and 100 commits, which is highly inefficient.  
The best approach would be to use LINQ to first get the customer IDs from the invoices, fetch all those customers from the database in a single query, update their balances in memory, and finally perform a single commit with all the changes.  

### Optimized Method

```csharp
public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
{
    var customerIds = invoices
        .Where(i => i.CustomerId.HasValue)
        .Select(i => i.CustomerId.Value)
        .Distinct()
        .ToList();

    var customers = dbContext.Customers
        .Where(c => customerIds.Contains(c.Id))
        .ToDictionary(c => c.Id);

    foreach (var invoice in invoices)
    {
        if (invoice.CustomerId.HasValue && customers.TryGetValue(invoice.CustomerId.Value, out var customer))
        {
            customer.Balance -= invoice.Total;
        }
    }

    dbContext.SaveChanges();
}
```

If the number of invoices is very large, this approach could consume too much memory and take too long to commit all the changes.  
In that case, I would process the data in smaller batches or delegate the operation to the database, for example using a stored procedure or perform the updates directly in SQL.

```sql
CREATE PROCEDURE UpdateCustomersBalanceByInvoices
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE c
    SET c.Balance = c.Balance - totals.TotalInvoice
    FROM Customers c
    INNER JOIN (
        SELECT CustomerId, SUM(Total) AS TotalInvoice
        FROM Invoices
        WHERE CustomerId IS NOT NULL
        GROUP BY CustomerId
    ) AS totals
    ON c.Id = totals.CustomerId;
END;
```
