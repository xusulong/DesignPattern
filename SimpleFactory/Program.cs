using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    /*
     *  设计模式の简单工厂
     *  来源：http://www.cnblogs.com/zhili/p/SimpleFactory.html
     *  场景说明
     */
    class Program
    {
        static void Main(string[] args)
        {
            Coder coder1 = (Coder)TeamFactory.CreateRole("Coder");
            People boss1 = (Boss)TeamFactory.CreateRole("Boss");
            People coder2 = TeamFactory.CreateRole("Coder");
            People boss2 = TeamFactory.CreateRole("Boss");
            coder1.DoTask();
            boss1.DoTask();
            coder2.DoTask();
            boss2.DoTask();
            Console.ReadKey();
        }
    }

    public  abstract class People
    {
        public abstract void DoTask(); 
    }

    public class Coder: People
    {
        public override void DoTask()
        {
            Console.WriteLine("codng...debugging...");
        }
    }
    public class Boss : People
    {
        public override void DoTask()
        {
            Console.WriteLine("having a meeting...smoking...");
        }
    }
    public class TeamFactory
    {
        public static People CreateRole(string role)
        {
            People people = null;
            if (role.Equals("Coder"))
            {
                people = new Coder();
            }
            if (role.Equals("Boss"))
            {
                people = new Boss();
            }
            return people;
        }
    }
}
