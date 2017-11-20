using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StragetyPattern
{
    /**
     * 
     * 设计模式の策略者模式
     * 来源：http://www.cnblogs.com/zhili/p/StragetyPattern.html
     * 定义：将每个算法封装到不同的策略类中，使得它们可以互换
     * 
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
            Console.WriteLine("个人支付的税为：{0}", operation.GetTax(5000.00));
            operation = new InterestOperation(new EnterpriseTaxStrategy());
            Console.WriteLine("企业支付的税为：{0}", operation.GetTax(50000.00));
            Console.Read();
        }
    }
    public interface ITaxStragety
    {
        double CalculateTax(double income);
    }
    //个人缴税
    public class PersonalTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }
    //企业缴税
    public class EnterpriseTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
        }
    }
    //缴税操作【个人或者企业】
    public class InterestOperation
    {
        private ITaxStragety taxStragety;
        public InterestOperation(ITaxStragety stragety)
        {
            this.taxStragety = stragety;
        }
        public double GetTax(double income)
        {
            return taxStragety.CalculateTax(income);
        }
    }
}
