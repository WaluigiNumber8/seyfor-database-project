using Microsoft.EntityFrameworkCore;
using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using DatabaseContext db = new();

            Console.WriteLine("Connected successfully");
            
            //Add a new equipment
            Equipment newEquipment = new()
            {
                Title = "Excavator",
                Description = "Used for digging"
            };
            db.Equipment.Add(newEquipment);
            await db.SaveChangesAsync();
            Console.WriteLine("New equipment added with ID: " + newEquipment.ID);

            IQueryable<Equipment> equipment = from e in db.Equipment select e;
            await foreach (Equipment e in equipment.AsAsyncEnumerable())
            {
                Console.WriteLine("ID: " + e.ID);
            }
        }
    }
}