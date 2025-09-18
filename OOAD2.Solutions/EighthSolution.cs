namespace OOAD2.Solutions;

public static class EighthSolution
{
    static void ProcessUsers(IRepository<User> repo, INotifier<User> handler)
    {
        foreach (var u in repo.GetAll())
        {
            handler.Notify(u, "Добро пожаловать в систему!");
        }
    }
    
    public static void Run()
    {
        IRepository<Admin> adminRepo = new AdminRepository();
        IRepository<Customer> customerRepo = new CustomerRepository();

        INotifier<User> userNotifier = new EmailNotifier();

        // КОВАРИАНТНОСТЬ:
        // IRepository<Admin> можно использовать там, где ожидается IRepository<User>
        // (Admin является наследником User, репозиторий "отдаёт" объекты наружу).
        ProcessUsers(adminRepo, userNotifier);

        // КОВАРИАНТНОСТЬ:
        // IRepository<Customer> также спокойно превращается в IRepository<User>.
        ProcessUsers(customerRepo, userNotifier);

        //  КОНТРАВАРИАНТНОСТЬ:
        // INotifier<User> можно использовать там, где ожидается INotifier<Admin>,
        // потому что метод Notify принимает любого User, а значит и Admin подойдёт.
        INotifier<Admin> adminNotifier = userNotifier;
        adminNotifier.Notify(new Admin { Email = "boss@site.com" }, "Только для админов");

        // КОНТРАВАРИАНТНОСТЬ:
        // Аналогично, INotifier<User> можно использовать как INotifier<Customer>.
        INotifier<Customer> customerNotifier = userNotifier;
        customerNotifier.Notify(new Customer { Email = "client@site.com" }, "Привет, клиент!");
    }
}

public class User
{
    
    public string Email { get; set; }
}

public class Admin : User;

public class Customer : User;

// Интерфейс с ключевым словом out (out T) ковариантный.
// Это значит: IRepository<Admin> можно присвоить в IRepository<User>.
public interface IRepository<out T>
{
    IEnumerable<T> GetAll();
}

public class AdminRepository : IRepository<Admin>
{
    
    public IEnumerable<Admin> GetAll() => [new() { Email = "admin1@test.com" }, new(){Email = "admin2@test.com"}];
}

public class CustomerRepository : IRepository<Customer>
{
    public IEnumerable<Customer> GetAll() => [new() { Email = "customer1@test.com" }, new() {Email = "customer2@test.com"}];
}

// Интерфейс с ключевым словом in (in T) контравариантный.
// Это значит: INotifier<User> можно присвоить в INotifier<Admin> или INotifier<Customer>.
interface INotifier<in T>
{
    void Notify(T user, string message);
}

class EmailNotifier : INotifier<User>
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Отправка e-mail на {user.Email}: {message}");
    }
}
