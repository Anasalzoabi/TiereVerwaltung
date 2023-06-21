public abstract class Pet
{
    public string Name { get; set; }
    public abstract void Attend();

    protected Pet(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {Name}";
    }
}


public abstract class Mammal : Pet, IStrokeable
{
    public abstract void Move();

    protected Mammal(string name) : base(name)
    {
    }
    public void Stroke()
    {
        Console.WriteLine($" {GetType().Name} {Name} schnurrt, wenn es gestreichelt wird.");
    }
}


public abstract class Fish : Pet
{
    public abstract void Swim();

    protected Fish(string name) : base(name)
    {
    }

    public override void Attend()
    {
        Console.WriteLine("Das Wasser für den Fisch wird gewechselt.");
    }
}


public class Goldfish : Fish, IStrokeable
{
    public Goldfish(string name) : base(name)
    {
    }

    public override void Swim()
    {
        Console.WriteLine("Der Goldfisch schwimmt im Kreis.");
    }

    public void Stroke()
    {
        Console.WriteLine("Der Goldfisch genießt es gestreichelt zu werden");
    }
    public override string ToString()
    {
        return $"{GetType().Name}: {Name}";
    }
}


public class Guppy : Fish
{
    public Guppy(string name) : base(name)
    {
    }

    public override void Swim()
    {
        Console.WriteLine("Der Guppy schwimmt vor und zurück.");
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {Name}";
    }
}


public class Katze : Mammal, IStrokeable
{
    public string Owner { get; }

    public Katze(string name, string owner) : base(name)
    {
        Owner = owner;
    }
    public void Stroke()
    {
        Console.WriteLine($"Die Katze {Name} schnurrt, wenn sie gestreichelt wird.");
    }


    public override void Move()
    {
        Console.WriteLine("Die Katze schleicht sich fort.");
    }

    public override void Attend()
    {
        Console.WriteLine("Das Fell der Katze wird gebürstet.");
    }

    public void Beißen()
    {
        Console.WriteLine("Die Katze schnurrt, wenn sie gestreichelt wird.");
        if (new Random().Next(5) == 0)
        {
            Console.WriteLine("Vorsicht! Die Katze beißt grundlos zu!");
        }

    }

    public override string ToString()
    {
        return $"{GetType().Name}: {Name} ";

    }
}


public class Rabbit : Mammal, IStrokeable
{
    public Rabbit(string name) : base(name)
    {
    }
    public void Stroke()
    {
        Console.WriteLine($"Der Hase {Name} genießt es, gestreichelt zu werden.");
    }

    public override void Move()
    {
        Console.WriteLine("Das Kaninchen hopst herum.");
    }

    public override void Attend()
    {
        Console.WriteLine("Der Kaninchenstall wird ausgemistet.");
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {Name}";
    }
}


public interface IStrokeable
{
    void Stroke();
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Mammal> garden = new List<Mammal>();
        List<Fish> aquarium = new List<Fish>();

        Katze Katze1 = new Katze("Whiskers", null);
        garden.Add(Katze1);

        Katze Katze2 = new Katze("Mittens", null);
        garden.Add(Katze2);

        Rabbit rabbit = new Rabbit("Häschen");
        garden.Add(rabbit);

        Goldfish goldfish = new Goldfish("Goldie");
        aquarium.Add(goldfish);

        Guppy guppy = new Guppy("Bubbles");
        aquarium.Add(guppy);


        Console.WriteLine("Haustiere im Garten:");
        foreach (Mammal mammal in garden)
        {
            Console.WriteLine(mammal);
            mammal.Move();
            mammal.Attend();
            Console.WriteLine();
        }


        Console.WriteLine("Haustiere im Aquarium:");
        foreach (Fish fish in aquarium)
        {
            Console.WriteLine(fish);
            fish.Swim();
            fish.Attend();
            Console.WriteLine();
        }


        List<Pet> zoo = new List<Pet>();
        zoo.AddRange(garden);
        zoo.AddRange(aquarium);


        Console.WriteLine("Zoo-Pflege:");
        foreach (Pet pet in zoo)
        {
            Console.WriteLine(pet);
            pet.Attend();
            Console.WriteLine();
        }


        Console.WriteLine("Streichelzoo:");
        foreach (Pet pet in zoo)
        {
            if (pet is IStrokeable strokeablePet)
            {
                Console.WriteLine(pet);
                strokeablePet.Stroke();
                Console.WriteLine();

            }
        }

    }

}
