using System;

public class Bicycle
{
    // Protected attributes (indicated by # in the diagram)
    protected int cadence;
    protected int gear;
    protected int speed;

    // Parameterized Constructor
    public Bicycle(int cadence, int speed, int gear)
    {
        this.cadence = cadence;
        this.speed = speed;
        this.gear = gear;
    }

    // Public methods (indicated by + in the diagram)
    public void setCadence(int cadence)
    {
        this.cadence = cadence;
    }

    public void setGear(int gear)
    {
        this.gear = gear;
    }

    public void applyBrake(int decrement)
    {
        this.speed -= decrement;
    }

    public void speedUp(int increment)
    {
        this.speed += increment;
    }
}