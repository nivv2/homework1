using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstproject
{
    internal class DeliveryDrone
    {
        private string Id;
        private int CurrentAltitude;
        private double BatteryPrecentage;
        private double MaxWeightKG;
        private string Status;

        public DeliveryDrone(string id, double maxweight)
        {
            if (id is null)
                throw new ArgumentNullException("ID not found");
            else if (maxweight <= 0)
                throw new ArgumentOutOfRangeException("Bad drone");
            else
            {
                Id = id;
                MaxWeightKG = maxweight;
                Status = "Grounded";
                BatteryPrecentage = 100.0;
                CurrentAltitude = 0;
            }
        }

        public string id { get { return Id; } }
        public string status { get { return Status; } }
        public double maxweight { get { return MaxWeightKG; } }
        public double battery { get { return BatteryPrecentage; } }



        public DeliveryResult Takeoff()
        {
            if (BatteryPrecentage < 30.0)
            {
                return new DeliveryResult(false, "Battery too low to takeoff");
            }
            else if (Status != "Grounded")
            {
                throw new InvalidOperationException("Already flying");
            }
            else
            {
                Status = "InFlight";
                CurrentAltitude = 50;
                return new DeliveryResult(true, "Operation accepted");
            }
        }
        public DeliveryResult AssignDelivery(double packageWeightKG, int distanceKM)
        {
            if (packageWeightKG > MaxWeightKG)
                return new DeliveryResult(false, "Cannot lift");
            else if (distanceKM * 5 > BatteryPrecentage)
                return new DeliveryResult(false, "Will not make it");
            else if (Status != "InFlight")
                throw new InvalidOperationException("Isn't flying");
            else
            {
                Status = "ReturningHome";
                BatteryPrecentage -= distanceKM * 5;
                return new DeliveryResult(true, "Operation successful");
            }
        }
        public void Land()
        {
            if (Status != "ReturningHome")
                throw new InvalidOperationException("Can't strand the drone");
            else
            {
                CurrentAltitude = 0;
                Status = "Grounded";
            }
        }




    }
}
