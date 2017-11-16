using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    /**
     * 
     * 设计模式の桥接模式
     * 来源：http://www.cnblogs.com/zhili/p/BridgePattern.html
     * 定义：执行动作与动作如何执行分开。桥接模式即将抽象部分与实现部分脱耦，使它们可以独立变化
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个遥控器
            RemoteControl remoteControl = new ConcreteRemote();
            // 长虹电视机
            remoteControl.Implementor = new ChangHong();
            remoteControl.On();
            remoteControl.TurnChannel();
            remoteControl.Off();
            Console.WriteLine();

            // 三星牌电视机
            remoteControl.Implementor = new Samsung();
            remoteControl.On();
            remoteControl.TurnChannel();
            remoteControl.Off();
            Console.Read();
        }
    }
    /// <summary>
    /// 电视抽象类
    /// </summary>
    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void TurnChannel();
    }


    /// <summary>
    /// 遥控器抽象，包含了抽象的TV，用TV的派生类赋值TV属性，完成派生类电视的各种操作
    /// </summary>
    public class RemoteControl
    {
        private TV implementor;
        public TV Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }
        /// <summary>
        /// 打开电视，至于打开什么品牌的电视，取决于TV属性的赋值
        /// </summary>
        public virtual void On()
        {
            implementor.On();
        }
        /**
         * 虚方法与抽象方法辨析
         * 
         * 
         * **/
        public virtual void Off()
        {
            implementor.Off();
        }
        public virtual void TurnChannel()
        {
            implementor.TurnChannel();
        }

    }

    /// <summary>
    /// 具体的遥控器，重写了换台方法，其他比如On/Off还是用的是基类方法
    /// </summary>
    public class ConcreteRemote : RemoteControl
    {
        public override void TurnChannel()
        {
            Console.WriteLine("---------------------");
            base.TurnChannel();
            Console.WriteLine("---------------------");
        }
    }

    public class Samsung : TV
    {
        public override void On()
        {
            Console.WriteLine("Open Sumsung...");
        }
        public override void TurnChannel()
        {
            Console.WriteLine("Sumsung TurnChanel...");
        }
        public override void Off()
        {
            Console.WriteLine("Close Sumsung...");
        }
    }

    public class ChangHong : TV
    {
        public override void On()
        {
            Console.WriteLine("Open ChangHong ...");
        }
        public override void TurnChannel()
        {
            Console.WriteLine("ChangHong  TurnChanel...");
        }
        public override void Off()
        {
            Console.WriteLine("Close ChangHong ...");
        }
    }
}
