using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternInDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            TenXun tenXun = new TenXunGame("TenXun Game","Have a new game published...");
            Subscriber sba = new Subscriber("SBA");
            Subscriber sbb = new Subscriber("SBB");
            tenXun.AddObserver(new TenXun.NotifyEventHandler(sba.ReceiveAndPrint));
            tenXun.AddObserver(new TenXun.NotifyEventHandler(sbb.ReceiveAndPrint));
            tenXun.AddObserver(new TenXun.NotifyEventHandler(sba.ReceiveAndPrint));
            tenXun.Update();
            Console.ReadKey();
        }
    }
    public class TenXun
    {
        public delegate void NotifyEventHandler(object sender);
        public NotifyEventHandler NotifyEvent;
        public string Symbol { get; set; }
        public string Info { get; set; }
        public TenXun(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }
        #region 新增对订阅号列表的维护操作
        public void AddObserver(NotifyEventHandler ob)
        {
            NotifyEvent += ob;
        }
        public void RemoveObserver(NotifyEventHandler ob)
        {
            NotifyEvent -= ob;
        }
        #endregion
        public void Update()
        {
            if (NotifyEvent != null)
            {
                NotifyEvent(this);
            }
        }
    }
    public class TenXunGame : TenXun
    {
        public TenXunGame(string symbol, string info) : base(symbol, info)
        {
        }
    }
    public class Subscriber
    {
        public string Name { get; set; }
        public Subscriber(string name)
        {
            this.Name = name;
        }
        public void ReceiveAndPrint(Object obj)
        {
            TenXun tenxun = obj as TenXun;
            if (tenxun != null)
            {
                Console.WriteLine("Notified {0} of {1}'s Info  is :{2}",Name,tenxun.Symbol,tenxun.Info);
            }
        }
    }
}
