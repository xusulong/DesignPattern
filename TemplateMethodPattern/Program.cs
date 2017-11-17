using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /**
     * 
     * 设计模式の模版方法模式
     * 来源：http://www.cnblogs.com/zhili/p/TemplateMethodPattern.html
     * 定义：模板方法模式——在一个抽象类中定义一个操作中的算法骨架（对应于生活中的大家下载的模板），而将一些步骤延迟到子类中去实现（对应于我们根据自己的情况向模板填充内容）。
     * 模板方法使得子类可以不改变一个算法的结构前提下，重新定义算法的某些特定步骤，模板方法模式把不变行为搬到超类中，从而去除了子类中的重复代码
     * 
     * 
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个菠菜实例并调用模板方法
            Spinach spinach = new Spinach();
            spinach.CookVegetabel();
 
            // 创建一个菠菜实例并调用模板方法
            ChineseCabbage chineseCabbage = new ChineseCabbage();
            chineseCabbage.CookVegetabel();
            Console.Read();
        }
    }
    public abstract class Vegetabel
    {
        public void CookVegetabel()
        {
            Console.WriteLine("炒蔬菜的一般做法");
            this.PourOil();
            this.HeatOil();
            this.PourVegetabel();
            this.StirFry();
        }
        public void PourOil()
        {
            Console.WriteLine("倒油");
        }
        public void HeatOil()
        {
            Console.WriteLine("把油烧热");
        }
        //放蔬菜
        public abstract void PourVegetabel();
        //翻炒
        public void StirFry()
        {
            Console.WriteLine("翻炒");
        }
    }
    public class Spinach : Vegetabel
    {
        public override void PourVegetabel()
        {
            Console.WriteLine("倒菠菜进锅中");
        }
    }
    public class ChineseCabbage : Vegetabel
    {
        public override void PourVegetabel()
        {
            Console.WriteLine("倒大白菜进锅中");
        }
    }
}
