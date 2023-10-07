using TestEF;

ApplicationContext db = new ApplicationContext();
db.Database.EnsureCreated();

WorkDB work = new WorkDB(db);
work.GetCustomers(new DateTime(2023, 1, 1), 1000.0M);

namespace TestEF
{
    public class WorkDB
    {
        private readonly ApplicationContext db;

        public WorkDB (ApplicationContext context)
        {
            db = context;
        }

        public List<CustomerViewModel> GetCustomers(DateTime beginDate, decimal sumAmount)
        {
            List<CustomerViewModel> customers = new List<CustomerViewModel>();
            var query = from o in db.Orders
                        where o.Date > beginDate
                        group o by o.Customer into g
                        where g.Sum(o => (double)o.Amount) > (double)sumAmount
                        select new
                        {
                            Name = g.Key.Name,
                            ManagerID = g.Key.ManagerID,
                            Sum = g.Sum(o => (double) o.Amount),
                        };
            foreach (var o in query)
            {
                customers.Add(new CustomerViewModel
                {
                    CustomerName = o.Name,
                    ManagerName = db.Managers.Find(o.ManagerID).Name,
                    Amount = (decimal)o.Sum
                });
            }
            return customers;
        }

    }
}

