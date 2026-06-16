using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Football
{
    public string type;
    public int size;
    public double weight;

    //by deefault constructor
    public Football() { }

    //parameterized constructor
    public Football(string type, int size, double weight)
    {
        this.type = type;
        this.size = size;
        this.weight = weight;
    }
}

class FootballPlayer
{
    public string name;
    public Football playerBall; //aaggregation

    //by default Constructor
    public FootballPlayer() { }

    //parameterized Constructor
    public FootballPlayer(string name, Football ball)
    {
        this.name = name;
        this.playerBall = ball;
    }
}