using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibity
{
    /**
     * 
     * 设计模式の责任链模式
     * 来源：http://www.cnblogs.com/zhili/p/ChainOfResponsibity.html
     * 定义：某个请求需要多个对象进行处理，从而避免请求的发送者和接收之间的耦合关系
     * 说明：每一步的处理人在处理的时候，在自己权限内的自己处理，权限外的，交给指定的下一个人处理
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseRequest requestTelphone = new PurchaseRequest(4000.0, "Telphone");
            PurchaseRequest requestSoftware = new PurchaseRequest(10000.0, "Visual Studio");
            PurchaseRequest requestComputers = new PurchaseRequest(40000.0, "Computers");

            Approver manager = new Manager("LearningHard");
            Approver Vp = new VicePresident("Tony");
            Approver Pre = new President("BossTom");

            // 设置责任链
            manager.NextApprover = Vp;
            Vp.NextApprover = Pre;

            // 处理请求
            manager.ProcessRequest(requestTelphone);
            manager.ProcessRequest(requestSoftware);
            manager.ProcessRequest(requestComputers);
            Console.ReadLine();
        }
    }
    public class PurchaseRequest
    {
        public double Amount { get; set; }
        public string ProductName { get; set; }
        public PurchaseRequest(double amount, string productName)
        {
            Amount = amount;
            ProductName = productName;
        }
    }
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }
        public string Name { get; set; }
        public Approver(string name)
        {
            this.Name = name;
        }
        public abstract void ProcessRequest(PurchaseRequest request);

    }
    public class Manager : Approver
    {
        public Manager(string name):base(name)
        {

        }
        /// <summary>
        /// 判断是否有权限处理，没有的交给下一个人
        /// </summary>
        /// <param name="request"></param>
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 1000.00)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }

        }
    }
    public class VicePresident : Approver
    {
        public VicePresident(string name) : base(name)
        {
        }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 25000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }
    public class President : Approver
    {
        public President(string name)
            : base(name)
        { }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 100000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else
            {
                Console.WriteLine("Request需要组织一个会议讨论");
            }
        }
    }


}
