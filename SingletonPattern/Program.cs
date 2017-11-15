using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /*
     *      设计模式の单例
     *      来源：http://www.cnblogs.com/zhili/p/SingletonPatterm.html
     *      应用场景
     * 
     * 
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Singleton ss = Singleton.GetInstance();

        }
    }

    /// <summary>
    /// 适用于多线程的单例模式示例：
    /// </summary>
    public class Singleton
    {
        //定义一个静态变量保存类的实例
        private static Singleton uniqueInstance;
        
        //定义一个标识确保线程同步
        private static readonly object locker = new object();
        
        //定义私有构造函数，使外界不能创建该类的实例
        private Singleton()
        {
        }
        //定义公有方法提供一个全局访问点，也可以定义公有属性来提供全局访问点
        public static Singleton GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对lock对象加锁
            // 当第二个线程运行该方法时，首先检测到locker对相关为“加锁”状态，该线程就会挂起等待第一线程解锁，lock语句块执行完后，即解锁
            //双重锁，在第一个线程完成创建对象后，此后的线程只需要直接判断是否为空，而不必再加锁判断，可以节省一点开销
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();
                    }
                }
            }
               
            return uniqueInstance;
        }
    }
}
