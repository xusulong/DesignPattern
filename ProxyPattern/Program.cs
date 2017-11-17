using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /**
     * 
     * 设计模式の代理模式
     * 来源：http://www.cnblogs.com/zhili/p/ProxyPattern.html
     * 定义：代理模式——就是给某一个对象提供一个代理，并由代理对象控制对原对象的引用
     * 说明：
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个代理对象并发出请求
            Person proxy = new Friend();
            proxy.BuyProduct();
            Console.Read();
        }
    }
    //抽象主题角色
    public abstract class Person
    {
        public abstract void BuyProduct();
    }
    public class RealBuyPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("李四： 帮我买一个IPhone和一台苹果电脑");
        }
    }
    /// <summary>
    /// 代理人
    /// </summary>
    public class Friend : Person
    {
        RealBuyPerson realSubject;
        public override void BuyProduct()
        {
            Console.WriteLine("通过代理类访问正式对象的方法");
            if (realSubject == null)
            {
                realSubject = new RealBuyPerson();
            }
            realSubject.BuyProduct();
            this.PreBuyProduct();
            this.PostBuyProduct();
        }
        public void PreBuyProduct()
        {
            Console.WriteLine("张三：我怕弄糊涂了，需要列一张清单，张三：要带相机，李四：要带Iphone...........");
        }
        public void PostBuyProduct()
        {
            Console.WriteLine("张三：终于买完了，现在要对东西分一下，相机是张三的；Iphone是李四的..........");
        }
    }

}
