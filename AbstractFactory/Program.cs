using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /*
     * 涉及两家公司，可能职位相同，但工作内容不同
     * 
     * 
     */

    class Program
    {
        static void Main(string[] args)
        {
            Compamy adCompany = new AdCompany();
            Compamy softCompany = new SoftCompany();
            Boss adb = adCompany.CreateBoss();
            Employee ade = adCompany.CreateEmployee();

            Boss softb = softCompany.CreateBoss();
            Employee softe = softCompany.CreateEmployee();

            adb.DoTask();
            ade.DoTask();
            softb.DoTask();
            softe.DoTask();
            Console.Read();
        }
    }

    public abstract class Boss  
    {
        public abstract void DoTask();
    }
    public abstract class Employee 
    {
        public abstract void DoTask();
    }

    /// <summary>
    /// 营销公司老板
    /// </summary>
    public class AdBoss : Boss
    {
        public override void DoTask()
        {
            Console.WriteLine("meeting guest... drinking... ");
        }
    }
    /// <summary>
    /// 营销公司员工
    /// </summary>
    public class AdEnployee : Employee
    {
        public override void DoTask()
        {
            Console.WriteLine("trumpte... wandering... ");
        }
    }
    /// <summary>
    /// 软件公司老板
    /// </summary>
    public class SoftBoss : Boss
    {
        public override void DoTask()
        {
            Console.WriteLine("having a meeting...smoking..");
        }
    }
    /// <summary>
    /// 软件公司员工
    /// </summary>
    public class SoftEnployee : Employee
    {
        public override void DoTask()
        {
            Console.WriteLine("coding... debugging..");
        }
    }

    /// <summary>
    /// 相当于一个抽象的工厂
    /// </summary>
    public abstract class Compamy
    {
        public abstract Boss CreateBoss();
        public abstract Employee CreateEmployee();
    }

    /// <summary>
    /// 营销公司
    /// </summary>
    public class AdCompany:Compamy
    {
        public override Boss CreateBoss()
        {
            return new AdBoss();
        }
        public override Employee CreateEmployee()
        {
            return new AdEnployee();
        }
    }

    /// <summary>
    /// 软件公司
    /// </summary>
    public class SoftCompany : Compamy
    {
        public override Boss CreateBoss()
        {
            return new SoftBoss();
        }
        public override Employee CreateEmployee()
        {
            return new SoftEnployee();
        }
    }

}
