using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //内容提供商
            TenXun tenXun = new TenXunGame("TenXun Game", "Have a new game published...");
            //添加订阅用户到提供商，以便接收提供商的消息
            tenXun.AddObsercer(new Subscriber("订阅者A"));
            tenXun.AddObsercer(new Subscriber("订阅者B"));
            //服务商提供更新了
            tenXun.Update();
            Console.ReadKey();

        }
    }
    /// <summary>
    /// 观察者接口
    /// </summary>
    public interface IObserver
    {
        void ReceiveAndPrint(TenXun tenXun);
    }
    //服务商抽象类
    public abstract class TenXun
    {
        private List<IObserver> observers = new List<IObserver>();
        public string Symbol { get; set; }
        public string Info { get; set; }
        public TenXun(string symbol, string info)
        {
            Symbol = symbol;
            Info = info;
        }
        #region 订阅者维护
        public void AddObsercer(IObserver ob)
        {
            observers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }
        #endregion
        //有更新，通知所有订阅者。即订阅者们做一件事，表示收到通知
        public void Update()
        {
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                {
                    ob.ReceiveAndPrint(this);
                }
            }
        }
    }
    //具体服务商
    public class TenXunGame:TenXun
    {
        public TenXunGame(string symbol, string info) : base(symbol, info)
        {
        }
    }
    //具体的订阅者类
    public class Subscriber : IObserver
    {
        public string Name { get; set; }
        public Subscriber(string name)
        {
            this.Name = name;
        }
        public void ReceiveAndPrint(TenXun tenXun)
        {
            Console.WriteLine("Notified {0} of {1}'s Info is :{2}",Name,tenXun.Symbol,tenXun.Info);
        }
    }

}
