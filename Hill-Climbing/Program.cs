using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// threshold is stopping criterion
/// hypothesis is startingPoint in the hypothese space
/// lastFitness = fitness(hypothesis)
/// do
///     copy(hypothesis) //copy hypothesis into saveState
///     moveOneStepAtRandom(hypothesis)
///     if fitness(hypothesis) > lastFitness then
///         lastFitness = fitness(hhypothesis)
///     else
///         undoMove(hypothesis) // copy saveState back into hypothesis
///     endif
/// While lastFitness < threshhold 
/// 
/// distanz zwischen den staedten = 100
/// 100 staedte
/// 1000 durchlaeufe
/// 
/// jede stadt einmal besuchen und am ende wieder bei sich selbst rauskommen
/// 
/// array initialisieren mit random zahlen
/// hauptdiagonale ist 0
/// ab == ba
/// </summary>
namespace Hill_Climbing
{
    class Program
    {
        private int[,] distance; //alle staedte in einer matrix.
        private int[] trip = new int[100]; // alle staedte in einer bestimmten reihenfolge


        static void Main(string[] args)
        {
            Program program = new Program();
            //foreach(var thing in program.distance)
            //{
            //    Console.WriteLine(thing);
            //}
            program.DoTrip();
            Console.WriteLine();
            Console.WriteLine("!!!FINISHED!!!");
            Console.ReadLine();
        }

        public Program()
        {
            distance = new int[100,100];
            Random random = new Random();
            for (int i = 0; i < distance.GetLength(0) - 1; i++)
            {
                for (int j = i+1; j < distance.GetLength(1) - 1; j++)
                {
                    distance[i,j] = random.Next(100);
                    distance[j,i] = random.Next(100);
                }
            }
            trip = new int[100];
            for (int i = 0; i < trip.Length; i++)
            {
                trip[i] = i;
            }
        }

        public int GetDistance(int[] trip1)
        {
            int tripDistance = 0;
            for (int i = 0; i < trip1.Length - 1; i++)
            {
                tripDistance += distance[trip1[i], trip1[1 + i]];
            }
            tripDistance += distance[trip1.Length - 1, trip1[0]];
            return tripDistance;
            //Random random = new Random();
            //return distance[cityA, cityB]; 
            //return 0;
        }

        public void DoTrip()
        {
            Random random = new Random();
            int lastDistance = GetDistance(trip);
            for (int i = 0; i < 1000; i++)
            {
                int[] newTrip = swap(random.Next(100), random.Next(100));
                int thisDistance = GetDistance(newTrip);
                if (thisDistance < lastDistance)
                {
                    lastDistance = thisDistance;
                    this.trip = newTrip;
                }
                Console.WriteLine("Nummer: " + i + " shortest: " + lastDistance + " now: " + thisDistance);
            }
        }

        private int[] swap(int v1, int v2)
        {
            int[] trip = this.trip;
            var temp = trip[v1];
            trip[v1] = trip[v2];
            trip[v2] = temp;
            return trip;
            //throw new NotImplementedException();
        }
    }
}
