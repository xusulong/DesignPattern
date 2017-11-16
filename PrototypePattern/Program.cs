using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    /**
     * 
     * 设计模式の原型模式
     * 来源：http://www.cnblogs.com/zhili/p/PrototypePattern.html
     * 应用场景：
     * 更具原型产生对象，原型变了，已产生的对象不会变，新产生的对象与新的原型保持一致
     * 
     * 
     * */
    class Program
    {
        static void Main(string[] args)
        {
            MonkeyKingPrototype monkeyKingPrototype = new ConcretePrototype("悟空");
            Console.WriteLine("prototpe:\t" + monkeyKingPrototype.Id);

            MonkeyKingPrototype cloneMonkeyKing = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned1:\t" + cloneMonkeyKing.Id);

     
            MonkeyKingPrototype cloneMonkeyKing2 = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned2:\t" + cloneMonkeyKing2.Id);

            monkeyKingPrototype.Id = "三藏";
            Console.WriteLine("prototpe:\t" + monkeyKingPrototype.Id);

            Console.WriteLine("Cloned1:\t" + cloneMonkeyKing.Id);
            Console.WriteLine("Cloned2:\t" + cloneMonkeyKing2.Id);
            cloneMonkeyKing.Id = "阿不思";
            Console.WriteLine("Cloned1:\t" + cloneMonkeyKing.Id);
            Console.WriteLine("Cloned2:\t" + cloneMonkeyKing2.Id);

            MonkeyKingPrototype cloneMonkeyKing3 = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned2:\t" + cloneMonkeyKing3.Id);
            MonkeyKingPrototype cloneMonkeyKing4 = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned2:\t" + cloneMonkeyKing4.Id);

            Console.ReadLine();
        }
    }
    /// <summary>
    /// 抽象一个原型孙悟空
    /// </summary>
    public abstract class MonkeyKingPrototype
    {
        public string Id { get; set; }

        public MonkeyKingPrototype(string id)
        {
            this.Id = id;
        }
        public abstract MonkeyKingPrototype Clone();
    }
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id)
           : base(id)
        { }
        //浅拷贝
        public override MonkeyKingPrototype Clone()
        {
            return (MonkeyKingPrototype)this.MemberwiseClone();
        }
    }
}









	

	








 