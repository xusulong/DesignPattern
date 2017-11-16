using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /**
     * 
     * 设计模式の适配器模式
     * 来源：http://www.cnblogs.com/zhili/p/AdapterPattern.html
     * 定义：
     * 适配器模式——把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法
     * 一起工作的两个类能够在一起工作。适配器模式有类的适配器模式和对象的适配器模式两种形式
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            //接口类型可以由继承该类接口的类赋值，此时接口中调用的方法为派生类的方法
            IThreeHole threehole = new PowerAdapter();
            threehole.Request();

            // 现在客户端可以通过电适配要使用2个孔的插头了
            ThreeHole threeholeobject = new PowerAdapterObj();
            threehole.Request();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 三孔插座
    /// </summary>
    public interface IThreeHole
    {
        void Request();
    }
    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public abstract class TwoHole
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是两个孔的插头");
        }
    }
    /// <summary>
    /// 该适配器继承了两孔插座类，并且继承了三孔插座的接口。此时，它既可以作为两孔插座也可以作为三孔插座
    /// </summary>
    public class PowerAdapter : TwoHole, IThreeHole
    {
        /// <summary>
        /// 实现三孔插座的方法，实际上调用的是两孔插座的方法
        /// </summary>
        public void Request()
        {
            // 调用两个孔插头方法
            this.SpecificRequest();
        }
    }

    #region 对象适配器
    /// <summary>
    /// 三个孔的插头，也就是适配器模式中的目标(Target)角色
    /// </summary>
    public class ThreeHole
    {
        // 客户端需要的方法
        public virtual void Request()
        {
            // 可以把一般实现放在这里
        }
    }
    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public class TwoHoleObj
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是两个孔的插头");
        }
    }
    /// <summary>
    /// 适配器类，这里适配器类没有TwoHole类，
    /// 而是引用了TwoHole对象，所以是对象的适配器模式的实现
    /// </summary>
    public class PowerAdapterObj : ThreeHole
    {
        // 引用两个孔插头的实例,从而将客户端与TwoHole联系起来
        public TwoHoleObj twoholeAdaptee = new TwoHoleObj();

        /// <summary>
        /// 实现三个孔插头接口方法，方法中是让两孔插座的做事情
        /// </summary>
        public override void Request()
        {
            twoholeAdaptee.SpecificRequest();
        }
    }
 
    #endregion
}
