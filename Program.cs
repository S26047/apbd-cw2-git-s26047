using System;

class Program
{
    static void Main(string[] args)
    {
        var service = new RentalService();
        
        // 1. Dodanie sprzętu

        var laptop = new Laptop { Name = "Dell XPS", RamGb = 16, Processor = "i7" };
        var projector = new Projector { Name = "Epson X1", Lumens = 3000, Resolution = "1080p" };
        var camera = new Camera { Name = "Canon EOS", Megapixels = 24, Zoom = 10 };

        service.AddEquipment(laptop);
        service.AddEquipment(projector);
        service.AddEquipment(camera);
        
        // 2. Dodanie użytkowników

        var student = new Student { FirstName = "Jan", LastName = "Kowalski" };
        var employee = new Employee { FirstName = "Anna", LastName = "Nowak" };

        service.AddUser(student);
        service.AddUser(employee);

        Console.WriteLine("=== WYPOŻYCZENIE POPRAWNE ===");
        
        // 3. Poprawne wypożyczenie

        service.RentEquipment(student.Id, laptop.Id, 2);
        
        // 4. Próba błędna

        Console.WriteLine("\n=== PRÓBA BŁĘDNA ===");

        try
        {
            service.RentEquipment(student.Id, laptop.Id, 2); // już wypożyczony
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
 
        // 5. Zwrot w terminie
 
        Console.WriteLine("\n=== ZWROT W TERMINIE ===");

        var loan = service.GetUserActiveLoans(student.Id)[0];
        service.ReturnEquipment(loan.Id);

        Console.WriteLine($"Kara: {loan.Penalty} zł");
        
        // 6. Zwrot po terminie

        Console.WriteLine("\n=== ZWROT PO TERMINIE ===");

        service.RentEquipment(student.Id, camera.Id, 1);
        var lateLoan = service.GetUserActiveLoans(student.Id)[0];

        // symulacja opóźnienia
        lateLoan.DueDate = DateTime.Now.AddDays(-3);

        service.ReturnEquipment(lateLoan.Id);

        Console.WriteLine($"Kara za spóźnienie: {lateLoan.Penalty} zł");
        
        // 7. Raport
        
        Console.WriteLine("\n=== RAPORT ===");

        foreach (var eq in service.GetAllEquipment())
        {
            Console.WriteLine($"{eq.Id} - {eq.Name} - Dostępny: {eq.IsAvailable}");
        }
    }
}