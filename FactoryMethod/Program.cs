using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /*
     * 设计模式の工厂方法模式
     * 来源 :http://www.cnblogs.com/zhili/p/FactoryMethod.html
     * 应用场景：工厂类不再负责所有产品的创建，添加产品后，只需要加一个继承自抽象工厂的类即可，达到增量开发的效果
     */
    class Program
    {
        static void Main(string[] args)
        {
            Factory coderFactory = new CoderFactory();
            Factory bossFactory = new BossFactory();
            People coder = coderFactory.CreateRoleFactory();
            People boss = bossFactory.CreateRoleFactory();
            coder.DoTask();
            boss.DoTask();
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 每个人都做任务
    /// </summary>
    public abstract class People
    {
        public abstract void DoTask();
    }

    /// <summary>
    /// 定义老板，实现老板要做的任务
    /// </summary>
    public class Boss : People
    {
        public override void DoTask()
        {
            Console.WriteLine("having a meeting...smoking..");
        }
    }
    // 定义程序员，实现程序员的任务
    public class Coder : People
    {
        public override void DoTask()
        {
            Console.WriteLine("coding...debugging..");
        }
    }
    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class Factory
    {
        public abstract People CreateRoleFactory();
    }
    //程序员们
    public class CoderFactory: Factory
    {
        public override People CreateRoleFactory()
        {
            return new Coder();
        }
    }
    //老板们
    public class BossFactory : Factory
    {
        public override People CreateRoleFactory()
        {
            return new Boss();
        }
    }
}
