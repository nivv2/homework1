using System.Linq.Expressions;
using System.Security.Cryptography;

namespace firstproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DeliveryDrone c1 = new DeliveryDrone("001", 30);
         
                //DeliveryDrone c3 = new DeliveryDrone("", 90);
                
                
                Console.WriteLine(c1.Takeoff());
                Console.WriteLine(c1.AssignDelivery(30, 5));
                c1.Land();
                Console.WriteLine($"{c1.id}: {c1.battery}% ({c1.status})");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        
    }
}
