using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    /**
     * 
     * 设计模式の中介者模式
     * 来源：http://www.cnblogs.com/zhili/p/MediatorPattern.html
     * 定义：中介者模式，定义了一个中介对象来封装一系列对象之间的交互关系。
     * 说明：在本例中，中介计算两个打牌的人A和B的输赢之后的钱数。将计算的事让中介执行，而不是分散给各个打牌的人。从网状结构转换到星型结构
     * 
     * **/

    class Program
    {
        static void Main(string[] args)
        {
            AbstractCardPartner A = new ParterA();
            AbstractCardPartner B = new ParterB();
            // 初始钱
            A.MoneyCount = 20;
            B.MoneyCount = 20;

            AbstractMediator mediator = new MediatorPater(A, B);

            // A赢了
            A.ChangeCount(5, mediator);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

            // B 赢了
            B.ChangeCount(10, mediator);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是15
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25
            Console.Read();
        }
    }
    public abstract class AbstractCardPartner
    {
        public int MoneyCount { get; set; }
        public AbstractCardPartner()
        {
            MoneyCount = 0;
        }
        public abstract void ChangeCount(int Count, AbstractMediator mediator);

    }
    public class ParterA : AbstractCardPartner
    {
        public override void ChangeCount(int count, AbstractMediator mediator)
        {
            mediator.AWin(count);
        }
    }
    public class ParterB : AbstractCardPartner
    {
        public override void ChangeCount(int count, AbstractMediator mediator)
        {
            mediator.BWin(count);
        }
    }
    public abstract class AbstractMediator
    {
        protected AbstractCardPartner A;
        protected AbstractCardPartner B;
        public AbstractMediator(AbstractCardPartner a, AbstractCardPartner b)
        {
            A = a;
            B = b;
        }
        public abstract void AWin(int count);
        public abstract void BWin(int count);
        
    }
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(AbstractCardPartner a, AbstractCardPartner b) : base(a, b)
        { 
        }
        public override void AWin(int count)
        {
            A.MoneyCount += count;
            B.MoneyCount -= count;
        }
        public override void BWin(int count)
        {
            B.MoneyCount += count;
            A.MoneyCount -= count;
        }
    }
}
