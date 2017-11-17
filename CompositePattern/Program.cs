using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    /**
     * 
     * 设计模式の组合模式
     * 来源：http://www.cnblogs.com/zhili/p/CompositePattern.html
     * 定义：组合模式允许你将对象组合成树形结构来表现”部分-整体“的层次结构，使得客户以一致的方式处理单个对象以及对象的组合
     * 说明：在这个组合模式中，Graphics作为一个基类（抽象类）。然后派生出一系列基本元素，比如线段、圆圈。然后派生一个复杂图形的类，在复杂图形类中放一个列表，列出它包含的基本元素（组合）。然后在复杂图形中调用基本元素的方法，完成复杂图形的操作
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            ComplexGraphics complexGraphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
            complexGraphics.Add(new Line("线段A"));
            ComplexGraphics CompositeCG = new ComplexGraphics("一个圆和一条线组成的复杂图形");
            CompositeCG.Add(new Circle("圆"));
            CompositeCG.Add(new Circle("线段B"));
            complexGraphics.Add(CompositeCG);
            Line l = new Line("线段C");
            complexGraphics.Add(l);

            // 显示复杂图形的画法
            Console.WriteLine("复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            // 移除一个组件再显示复杂图形的画法
            complexGraphics.Remove(l);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.Read();
        }
    }
    public abstract class Graphics
    {
        public string Name { get; set; }
        public Graphics(string name)
        {
            this.Name = name;
        }
        public abstract void Draw();
    }
    /// <summary>
    /// 画线
    /// </summary>
    public class Line : Graphics
    {
        public Line(string name) : base(name)
        {

        }
        public override void Draw()
        {
            Console.WriteLine("画 "+Name);
        }
    }
    public class Circle : Graphics
    {
        public Circle(string name) : base(name)
        {

        }
        public override void Draw()
        {
            Console.WriteLine("画 "+ Name);
        }
    }
    //复杂图形
    public class ComplexGraphics : Graphics
    {
        //组件列表
        private List<Graphics> complexGraphicsList = new List<Graphics>();
        public ComplexGraphics(string name) : base(name)
            { }
        //绘制所有组件
        public override void Draw()
        {
            foreach(Graphics g in complexGraphicsList)
            {
                g.Draw();
            }
        }
        /// <summary>
        /// 向复杂图形中加组件
        /// </summary>
        /// <param name="g"></param>
        public void Add(Graphics g)
        {
            complexGraphicsList.Add(g);
        }
        /// <summary>
        /// 移除组件
        /// </summary>
        /// <param name="g"></param>
        public void Remove(Graphics g)
        {
            complexGraphicsList.Remove(g);
        }

    }

}
