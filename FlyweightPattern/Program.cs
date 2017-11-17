using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FlyweightPattern
{
    /**
     * 
     * 设计模式の享元模式
     * 来源：http://www.cnblogs.com/zhili/p/FlyweightPattern.html
     * 定义：运用共享技术有效地支持大量细粒度的对象。享元模式可以避免大量相似类的开销，在软件开发中如果需要生成大量细粒度的类实例来表示数据，如果这些实例除了几个参数外
     * 基本上都是相同的，这时候就可以使用享元模式来大幅度减少需要实例化类的数量。如果能把这些参数（指的这些类实例不同的参数）移动类实例外面，在方法调用时将他们传递进
     * 来，这样就可以通过共享大幅度地减少单个实例的数目
     * 说明：
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            //定义外部状态，例如字母的位置等信息
            int externalstate = 10;
            FlyweightFactory factory = new FlyweightFactory();
            Flyweight fa = factory.GetFlyweight("A");
            if (fa != null)
            {
                // 把外部状态作为享元对象的方法调用参数
                fa.Operateion(--externalstate);
            }
            Flyweight fb = factory.GetFlyweight("B");
            if (fb != null)
            {
                fb.Operateion(--externalstate);
            }
            Flyweight fc = factory.GetFlyweight("C");
            if (fc != null)
            {
                fc.Operateion(--externalstate);
            }
            Flyweight fd = factory.GetFlyweight("D");
            if (fd != null)
            {
                fd.Operateion(--externalstate);
            }
            else
            {
                Console.WriteLine("驻留池中不存在字符串D");
                ConcreteFlyweight d = new ConcreteFlyweight("D");
                factory.flyweights.Add("D",d);
            }
            Console.Read();
        }
    }
    public abstract class Flyweight
    {
        public abstract void Operateion(int extrinsicstate);
    }
    public class FlyweightFactory
    {
        public Hashtable flyweights = new Hashtable();
        public FlyweightFactory()
        {
            flyweights.Add("A",new ConcreteFlyweight("A"));
            flyweights.Add("B",new ConcreteFlyweight("B"));
            flyweights.Add("C",new ConcreteFlyweight("C"));
        }
        public Flyweight GetFlyweight(string key)
        {
            return flyweights[key] as Flyweight;
        }
    }
    public class ConcreteFlyweight : Flyweight
    {
        private string intrinsicstate;
        public ConcreteFlyweight(string innerState)
        {
            this.intrinsicstate = innerState;
        }
        public override void Operateion(int extrinsicstate)
        {
            Console.WriteLine("具体实现类：intrinsicstate {0},extrinsicstate{1}",intrinsicstate,extrinsicstate);
        }
    }       
}
