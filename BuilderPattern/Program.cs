using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /***
     * 
     * 设计模式の建造者模式
     * 来源：http://www.cnblogs.com/zhili/p/BuilderPattern.html
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            // 客户找到电脑城老板说要买电脑，这里要装两台电脑
            // 创建指挥者和构造者
            Director director = new Director();
            Builder b1 = new BuilderDELL();
            Builder b2 = new BuilderASUS();

            // 老板叫员工去组装第一台电脑
            director.Construct(b1);

            // 组装完，组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();

            // 老板叫员工去组装第二台电脑
            director.Construct(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();

            Console.Read();
        }
    }

    public class Computer
    {
        // 电脑组件
        private IList<string> parts = new List<string>();
        public string Band = "自主品牌";
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("电脑开始组装...");
            foreach (string part in parts)
            {
                Console.WriteLine("组件"+part+"已组装好");
            }
            Console.WriteLine(Band+"牌电脑组装完毕");
        }
    }

    public abstract class Builder
    {
        public abstract void AddCPU();
        public abstract void AddMainBord();
        public abstract Computer GetComputer();
    }

    /// <summary>
    /// 组装一个DELL电脑
    /// </summary>
    public class BuilderDELL: Builder
    {
        Computer computer = new Computer();
        public override void AddCPU()
        {
            computer.Add("CPU1");
        }
        public override void AddMainBord()
        {
            computer.Add("Bord1");
        }
        public override Computer GetComputer()
        {
            computer.Band = "DELL";
            return computer;
        }
    }
    /// <summary>
    /// 组装一个ASUS电脑
    /// </summary>
    public class BuilderASUS : Builder
    {
        Computer computer = new Computer();
        public override void AddCPU()
        {
            computer.Add("CPU1");
        }
        public override void AddMainBord()
        {
            computer.Add("Bord1");
        }
        public override Computer GetComputer()
        {
            computer.Band = "ASUS";
            return computer;
        }
    }

    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.AddCPU();
            builder.AddMainBord();
        }
    }

}
