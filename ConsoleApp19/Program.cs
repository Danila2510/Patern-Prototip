using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    public interface Interface_clone { Vehicle Clone_de(); }

    public class Eng
    {
        public double Eng_Power { get; set; }
        public Eng(double idNumber) => Eng_Power = idNumber;
        public Eng() => Eng_Power = 0;
        public Eng Clone_de() { return new Eng(Eng_Power); }
    }

    public abstract class Vehicle : Interface_clone
    {
        public string Name { get; set; }
        public double Ranges { get; set; }
        public Eng Eng { get; set; }

        public Vehicle(string name, double ranges, Eng eng)
        {
            Name = name;
            Ranges = ranges;
            this.Eng = eng;
        }
        public abstract Vehicle Clone_de();
    }
    public class Ship : Vehicle
    {
        public int Max_Displacement { get; set; }
        public int MaxSpeed { get; set; }

        public Ship(string name, double ranges, Eng eng, int max_Displacement, int max_Speed)
            : base(name, ranges, eng)
        {
            Max_Displacement = max_Displacement;
            MaxSpeed = max_Speed;
        }

        public override string ToString()
        {
            return $"{Name}:\n Максимальное смещение{Max_Displacement}\n Максимальная скорость{MaxSpeed} узлы \nДиапазон{Ranges} км";
        }
        public override Vehicle Clone_de()
        {
            Ship copy = new Ship(Name, Ranges, Eng.Clone_de(), Max_Displacement, MaxSpeed);
            return copy;
        }
    }
    public class Car : Vehicle
    {
        public int Max_Pass { get; set; }
        public int Max_Speed { get; set; }
        public Car(string name, double ranges, Eng eng, int max_Pass, int max_Speed) : base(name, ranges, eng)
        {
            Max_Pass = max_Pass;
            Max_Speed = max_Speed;
        }

        public override string ToString()
        {
            return $"{Name}: \nМаксимальное количество пассажиров{Max_Pass}\nМаксимальная скорость{Max_Speed}км/ч\nДиапазон:{Ranges} км";
        }
        public override Vehicle Clone_de()
        {
            Car copy = new Car(Name, Ranges, Eng.Clone_de(), Max_Pass, Max_Speed);
            return copy;
        }
    }
    public class Air : Vehicle
    {
        public int MaxAltitude { get; set; }
        public int MaxSpeed { get; set; }

        public Air(string name, double range, Eng engine, int maxAltitude, int maxSpeed) : base(name, range, engine)
        {
            MaxAltitude = maxAltitude;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return $"{Name}\nМаксимальная высота{MaxAltitude}\nМаксимальная скорость{MaxSpeed}км/ч \nДиапазон{Ranges} км";
        }
        public override Vehicle Clone_de()
        {
            Air copy = new Air(Name, Ranges, Eng.Clone_de(), MaxAltitude, MaxSpeed);
            return copy;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Eng engine = new Eng(800);
            Ship ship = new Ship("Корабль", 2500, engine, 50000, 25);
            Car car = new Car("Машина", 800, engine, 5, 260);
            Air airplane = new Air("Самолет", 7500, engine, 50000, 690);
            Car copy = (Car)car.Clone_de();
            Console.WriteLine(copy);
        }
    }
}