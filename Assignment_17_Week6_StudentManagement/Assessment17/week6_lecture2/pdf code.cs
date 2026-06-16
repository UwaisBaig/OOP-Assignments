using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Car
{
    public string carName;
    public Car(string name)
    {
        carName = name;
    }
    public void onSignalChange(string action)
    {
        Console.WriteLine("I am " + carName + " and I am in " + action + " state");
    }
}

class TrafficSignal
{
    string state;
    List<Car> carList = new List<Car>();
    public void addCar(Car c)
    {
        carList.Add(c);
    }
    public void setRedState()
    {
        state = "Red";
        informCars();
    }
    public void setGreenState()
    {
        state = "Green";
        informCars();
    }
    public void informCars()
    {
        foreach (Car car in carList)
        {
            car.onSignalChange(state);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TrafficSignal signal1 = new TrafficSignal();
        Car car1 = new Car("Car1");
        Car car2 = new Car("Car2");
        signal1.addCar(car1);
        signal1.addCar(car2);
        signal1.setRedState();
        signal1.setGreenState();
        Console.ReadKey();
    }
}