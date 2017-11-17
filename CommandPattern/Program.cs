using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /**
     * 
     * 设计模式の命令模式
     * 来源：http://www.cnblogs.com/zhili/p/CommandPattern.html
     * 
     * 定义：命令模式属于对象的行为型模式。
     * 命令模式是把一个操作或者行为抽象为一个对象中，通过对命令的抽象化来使得发出命令的责任和执行命令的责任分隔开。
     * 命令模式的实现可以提供命令的撤销和恢复功能
     * 说明：
     * 客户角色：发出一个具体的命令并确定其接受者。
     * 命令角色：声明了一个给所有具体命令类实现的抽象接口
     * 具体命令角色：定义了一个接受者和行为的弱耦合，负责调用接受者的相应方法。
     * 请求者角色：负责调用命令对象执行命令。
     * 接受者角色：负责具体行为的执行。
     * 
     * 
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            // 初始化Receiver、Invoke和Command
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoke i = new Invoke(c);
            // 院领导发出命令
            i.ExecuteCommand();
            Console.WriteLine("呵呵呵");
            r.Run1000M();
            Console.Read();
        }
    }
    public class Invoke
    {
        public Command command;
        public Invoke(Command _command)
        {
            this.command = _command;
        }
        public void ExecuteCommand()
        {
            command.Action();
        }
    }
    public abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver _receiver)
        {
            this.receiver = _receiver;
        }
        /// <summary>
        /// 执行命令
        /// </summary>
        public abstract void Action();
    }
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {

        }
        public override void Action()
        {
            receiver.Run1000M();
        }
    }
    // 命令接收者--学生
    public class Receiver
    {
        public void Run1000M()
        {
            Console.WriteLine("跑1000米");
        }
    }
}
