using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    /*
     * 设计模式の装饰者模式
     * 定义：
     * 装饰者模式以对客户透明的方式动态地给一个对象附加上更多的责任，装饰者模式相比生成子类可以更灵活地增加功能
     * 来源：http://www.cnblogs.com/zhili/p/DecoratorPattern.html
     * 说明：
     */
    class Program
    {
        static void Main(string[] args)
        {
            //买手机
            Phone phone = new ApplePhone();//有买手机这个动作，即phone的print

            //这个例子，相当于买了一个手机，然后把手机拿给人家贴膜，然后把有贴膜的手机拿给人家加挂件
            Sticker sticker = new Sticker(phone);//买好的手机拿去贴膜
            sticker.Print();//
            Accessories applePhoneWithAccessoriesAndSticker = new Accessories(sticker);//贴了膜的手机加挂件
            applePhoneWithAccessoriesAndSticker.Print();

            Console.ReadLine();
        }
    }

    public abstract class Phone
    {
        public abstract void Print();
    }
    public class ApplePhone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("手机裸体");
        }
    }
    /// <summary>
    /// 定义抽象装饰类
    /// </summary>
    public abstract class Decorator : Phone
    {
        private Phone phone;
        public Decorator(Phone phone)
        {
            this.phone = phone;
        }
        public override void Print()
        {
            if (phone != null)
            {
                phone.Print();
            }
        }
    }
    /// <summary>
    /// 贴膜装饰者，继承Decorator装饰类，抽象装饰类Decorator是Phone的派生类
    /// </summary>
    public class Sticker : Decorator
    {
        public Sticker(Phone p) : base(p)
        {

        }
        public override void Print()
        {
            base.Print();
            AddSticker();
        }
        public void AddSticker()
        {
            Console.WriteLine("手机有膜");
        }
    }
    /// <summary>
    /// 挂件装饰者，继承Decorator装饰类，抽象装饰类Decorator是Phone的派生类
    /// </summary>
    public class Accessories : Decorator
    {
        public Accessories(Phone p) : base(p)
        {
        }
        public override void Print()
        {
            base.Print();
            AddAccessories();
        }
        public void AddAccessories()
        {
            Console.WriteLine("手机有挂件");
        }
    }


}
