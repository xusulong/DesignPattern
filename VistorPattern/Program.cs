using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistorPattern
{
    /**
     * 
     * 设计模式の访问者模式
     * 来源：http://www.cnblogs.com/zhili/p/VistorPattern.html
     * 定义：
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure objectStructure = new ObjectStructure();
            foreach (Element e in objectStructure.Elements)
            {
                e.Accept(new ConcreteVisitor());
            }
            Console.Read(); 
        }
    }
    public interface IVisitor
    {
        void Visit(ElementA a);
        void Visit(ElementB b);
    }
    public class ConcreteVisitor:IVisitor
    {
        public void Visit(ElementA a)
        {
            a.Print();
        }
        public void Visit(ElementB  b)
        {
            b.Print();
        }
    }
    //抽象元素角色
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
        public abstract void Print();
    }
    public class ElementA : Element
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public override void Print()
        {
            Console.WriteLine("我是元素A");
        }
    }
    public class ElementB :Element
    {
        public override void Print()
        {
            Console.WriteLine("我是元素B");
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class ObjectStructure
    {
        private ArrayList elements = new ArrayList();
        public ArrayList Elements
        {
            get { return elements; }
        }
        public ObjectStructure()
        {
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = random.Next(10);
                if (ranNum > 5)
                {
                    elements.Add(new ElementA());
                }
                else
                {
                    elements.Add(new ElementB());
                }
            }
        }
    }

}
