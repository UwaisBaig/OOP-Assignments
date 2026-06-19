using System;

public class MountainBike : Bicycle
{
    // Private attribute (indicated by - in the diagram)
    private int seatHeight;

    // Constructor using 'base' to pass parameters to the parent class
    public MountainBike(int seatHeight, int cadence, int speed, int gear)
        : base(cadence, speed, gear)
    {
        this.seatHeight = seatHeight;
    }

    // Public method
    public void setSeatHeight(int seatHeight)
    {
        this.seatHeight = seatHeight;
    }
}