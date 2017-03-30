using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IPart
    {
    }
    public class Wall : IPart
    {

    }
    public class Window : IPart
    {

    }
    public class Door : IPart
    {

    }
    public class Basement : IPart
    {

    }
    public class Roof : IPart
    {

    }
    public class House
    {
      private  Wall[] walls = new Wall[4];
      private   Window[] windows = new Window[2];
      private  Door door = null;
      private  Basement basement = null;
      private  Roof roof = null;
      public House(Team team)
      {
          IPart[] parts = new IPart[9] { new Wall(), new Wall(), new Wall(), new Wall(), new Window(), new Window(), new Door(), new Basement(), new Roof() };
          int i = 0;
          int j = 0;

          while (j<9)
          {
              if(team.workers[i] is Brigadir){
                  Console.WriteLine("already built: ");
                  for (int k = 0; k < j; k++)
                  {
                      Console.WriteLine(parts[k].GetType().ToString() + "  ");
                  }
                  i++;
              }
              else{
                  team.workers[i].buildnext(parts[j]);
                  j++;
                  i++;
              }
              if (i == team.workers.Length) i = 0;
          }
          walls[0] = (Wall)parts[0];
          walls[1] = (Wall)parts[1];
          walls[2] = (Wall)parts[2];
          walls[3] = (Wall)parts[3];
          windows[0] = (Window)parts[4];
          windows[1] = (Window)parts[5];
          door = (Door)parts[6];
          basement = (Basement)parts[7];
          roof = (Roof)parts[8];
         
          
       
          
 

      }

    }
    public interface IWorker
    {
          IPart buildnext(IPart p);
    }
    public class Worker:IWorker
    {
        protected string name;
        public Worker(){
            name = "default";
        }
        public Worker(string name)
        {
            this.name = name;
        }
        public  IPart buildnext(IPart p){
            Console.WriteLine("worker build " + p.GetType().ToString());
            return p;
        }
        

        
    }
    public class Brigadir : Worker, IWorker
    {
        public Brigadir() : base() { }
        
        public void report() { 


        }

    }
    public class Team
    {
       public int workerCount;
        public Worker[] workers;
       public Brigadir brigadir;
        public Team(int count)
        {
            workerCount = count;
            workers = new Worker[workerCount];
            for (int i = 0; i < count-1; i++)
            {
                workers[i] = new Worker();
            }
            workers[count - 1] = new Brigadir();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team(4);
            House house = new House(team);
        }
    }
}
