using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTourConsole.Services
{
    public class TourService
    {
        private List<Tour> tours = new List<Tour>();

        public void AddTour()
        {
            Console.WriteLine("Add new tour: ");
            int id = ConsoleHelper.ReadInt("Tour ID: ");
            string title = ConsoleHelper.ReadString("Tour title: ");
            string description = ConsoleHelper.ReadString("Description: ");
            DateTime start = ConsoleHelper.ReadDate("Start Date (yyyy-MM-dd): ");
            DateTime end = ConsoleHelper.ReadDate("End Date (yyyy-MM-dd): ");
            decimal price = ConsoleHelper.ReadDecimal("Price: ");
            int capacity = ConsoleHelper.ReadInt("Capacity: ");
            int cityId = ConsoleHelper.ReadInt("City ID: ");
            int agencyId = ConsoleHelper.ReadInt("Agency ID: ");
            int categoryId = ConsoleHelper.ReadInt("Category ID: ");

            tours.Add(new Tour(id, title, description, start, end, price, capacity, cityId, agencyId, categoryId));
            Console.WriteLine("Tour added successfully.");
        }

        public void ListTours()
        {
            Console.WriteLine("List of tours: ");
            foreach (var tour in tours)
                Console.WriteLine(tour);
        }

        public bool RemoveTour(int id)
        {
            // LINQ (FirstOrDefault Method for getting first value)
            var tour = tours.FirstOrDefault(t => t.Id == id);
            if (tour != null)
            {
                tours.Remove(tour);
                return true;
            }
            return false;
        }

        public Tour FindById(int id)
        {
            return tours.FirstOrDefault(t => t.Id == id);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n - - - Tour Management - - -");
                Console.WriteLine("1. Add Tour");
                Console.WriteLine("2. Show All Tours");
                Console.WriteLine("3. Delete Tour");
                Console.WriteLine("4. Return");

                int choice = ConsoleHelper.ReadInt("Your choice: ");

                switch (choice)
                {
                    case 1: AddTour(); break;
                    case 2: ListTours(); break;
                    case 3:
                        int id = ConsoleHelper.ReadInt("Tour ID for deletion: ");
                        Console.WriteLine(RemoveTour(id) ? "Deleted" : "Tour not found");
                        break;
                    case 4: return;
                    default: Console.WriteLine("Invalid option!"); break;
                }
            }
        }
    }
}
