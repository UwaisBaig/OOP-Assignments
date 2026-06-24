using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assesment
{
    // 1. Address Class
    public class Address
    {
        private string buildingName;
        private string apartmentNo;
        private string buildingNo;
        private string streetName;
        private string street2Name;
        private string locality;
        private string townOrCity;
        private string county;
        private string postCodeOrZip;
        private string state;

        // Constructor
        public Address(string bName, string city)
        {
            this.buildingName = bName;
            this.townOrCity = city;
        }

        // Method to compare two addresses
        public bool Equals(Address otherAddress)
        {
            // Logic to establish if two addresses are close enough to be a match
            if (this.buildingName == otherAddress.buildingName &&
                this.townOrCity == otherAddress.townOrCity)
            {
                return true;
            }
            return false;
        }
    }

    // 2. Journey Class
    public class Journey
    {
        // Aggregation: Journey "has-a" start and destination Address.
        // In C#, object variables are references, perfectly modeling Aggregation.
        private Address startAddress;
        private Address destinationAddress;

        // Constructor assigns existing addresses to the journey
        public Journey(Address start, Address dest)
        {
            this.startAddress = start;
            this.destinationAddress = dest;
        }

        public bool Equals(Journey otherJourney)
        {
            // Logic to compare journeys using the dot (.) operator
            return (this.startAddress.Equals(otherJourney.startAddress) &&
                    this.destinationAddress.Equals(otherJourney.destinationAddress));
        }
    }

    // 3. CarSharer Class
    public class CarSharer
    {
        // Aggregation: CarSharer "has-a" home Address
        private Address homeAddress;

        public CarSharer(Address home)
        {
            this.homeAddress = home;
        }
    }

    // Driver Code to test it out
    class Program
    {
        static void Main(string[] args)
        {
            // Create independent Address objects first
            Address myHome = new Address("Iqbal Towers", "Lahore");
            Address work = new Address("Tech Park", "Lahore");

            // Pass those existing addresses into Journey and CarSharer
            Journey morningCommute = new Journey(myHome, work);
            CarSharer driver = new CarSharer(myHome);

            Console.WriteLine("Aggregation setup complete! No syntax errors.");
            Console.ReadKey();
        }
    }
}