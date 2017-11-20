﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    /**
     * 
     * 设计模式の状态者模式
     * 来源：http://www.cnblogs.com/zhili/p/StatePattern.html
     * 定义：允许一个对象在其内部状态改变时自动改变其行为，对象看起来就像是改变了它的类
     * 
     * 说明：在条件变化后，改变其状态属性，从而在行为上改变
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("Alfred.Xu");
            account.Deposit(1000.0);
            Console.WriteLine();
            account.Deposit(200.0);
            Console.WriteLine();
            account.Deposit(600.0);
            Console.WriteLine();
            account.PayInterest();
            Console.WriteLine();
            account.Withdraw(2000.00);
            Console.WriteLine();
            account.Withdraw(500.00);
            Console.ReadKey();
        }
    }
    public class Account
    {
        public State State { get; set; }
        public string Owner { get; set; }
        public Account(string owner)
        {
            this.Owner = owner;
            this.State = new SilverState(0.0,this);
        }
        public double Balance { get { return State.Balance; } }
        public void Deposit(double amount)
        {
            State.Deposit(amount);
            Console.WriteLine("存款金额为：{0:C}",amount);
            Console.WriteLine("账户余额为：{0:C}",this.Balance);
            Console.WriteLine("账户状态为：{0}",this.State.GetType().Name);
        }
        public void Withdraw(double amount)
        {
            State.Withdraw(amount);
            Console.WriteLine("取款金额为{0:C}",amount);
            Console.WriteLine("账户余额为：{0:C}",this.Balance);
            Console.WriteLine("账户状态为:{0}",this.State.GetType().Name);
        }
        public void PayInterest()
        {
            State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine("账户余额为:{0:C}", this.Balance);
            Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
            Console.WriteLine();
        }
    }
    // 抽象状态类
    public abstract class State
    {
        public Account Account { get; set; }
        public double Balance { get; set; }
        public double Interest { get; set; }
        public double LowerLimit { get; set; }
        public double UpperLimit { get; set; }
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();
    }
    public class RedState : State
    {
        public RedState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            Interest = 0.00;
            LowerLimit = -100.00;
            UpperLimit = 0.00;
        }
        //存款
        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }
        public override void Withdraw(double amount)
        {
            Console.WriteLine("没有钱可以取了！");
        }
        public override void PayInterest()
        {

        }
        private void StateChangeCheck()
        {
            if (Balance > UpperLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }
    public class SilverState : State
    {
        public SilverState(State state):this(state.Balance,state.Account)
        {

        }
        public SilverState(double balance,Account account)
        {
            this.Balance = balance;
            this.Account = account;
            Interest = 0.00;
            LowerLimit = 0.00;
            UpperLimit = 1000.00;
        }
        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }
        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }
        public override void PayInterest()
        {
            Balance += Interest * Balance;
        }
        private void StateChangeCheck()
        {
            if (Balance < LowerLimit)
            {
                Account.State = new RedState(this);
            }
            else
            {
                Account.State = new GoldState(this);
            }
        }
    }
    public class GoldState : State
    {
        public GoldState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            Interest = 0.05;
            LowerLimit = 1000.00;
            UpperLimit = 1000000.00;
        }
        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }
        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }
        public override void PayInterest()
        {
            Balance += Interest * Balance;
        }

        private void StateChangeCheck()
        {
            if (Balance < 0.0)
            {
                Account.State = new RedState(this);
            }
        }
    }
}
