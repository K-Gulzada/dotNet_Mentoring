

interface IMovable
{
    public const int minSpeed = 0;     // минимальная скорость
    public static int maxSpeed = 60;   // максимальная скорость
    public void Move();
    protected internal string Name { get; set; }    // название
    public delegate void MoveHandler(string message);  // определение делегата для события
    public event MoveHandler MoveEvent;    // событие движения
}

interface IMovable_2
{
    // реализация метода по умолчанию
    void Move() => Console.WriteLine("Walking");
    // реализация свойства по умолчанию
    // свойство только для чтения
    int MaxSpeed { get { return 0; } }
}

interface IMovable_3
{
    public const int minSpeed = 0;     // минимальная скорость
    private static int maxSpeed = 60;   // максимальная скорость
    // находим время, за которое надо пройти расстояние distance со скоростью speed
    static double GetTime(double distance, double speed) => distance / speed;
    static int MaxSpeed
    {
        get => maxSpeed;
        set
        {
            if (value > 0) maxSpeed = value;
        }
    }
}

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 56;
            object obj = a;
            int b = (int)obj;
            long c = (long)obj;
            object box = 42;
            long unbox = (int)box;


            Console.WriteLine(IMovable.maxSpeed);   // 60
            Console.WriteLine(IMovable.minSpeed);   // 0
            Console.WriteLine("===============================");
            Console.WriteLine(IMovable_3.MaxSpeed);   // 60
            IMovable_3.MaxSpeed = 65;
            Console.WriteLine(IMovable_3.MaxSpeed);   // 65
            double time = IMovable_3.GetTime(500, 10);
            Console.WriteLine(time);    // 50

            IMovable_4 tom = new Person();
            Car tesla = new Car();
            tom.Move();     // Walking
            tesla.Move();   // Driving

            //==================================================

            Bus bus = new Bus();
            bus.Move();
            bus.Move_2();
          

        }
    }
}

interface IMovable_4
{
    void Move() => Console.WriteLine("Walking");
}
class Person : IMovable_4 { }
class Car : IMovable_4
{
    public void Move() => Console.WriteLine("Driving");
}

abstract class Transport
{
    public void Move()
    {
        Console.WriteLine("Transport is moving");
    }
    public virtual void Move_2()
    {
        Console.WriteLine("Transport is moving 2");
    }
}

class Bus : Transport
{
    public override void Move_2()
    {
        Console.WriteLine("Transport is moving. Its Bus");
    }
}