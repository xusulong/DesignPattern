using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    /**
     * 
     * 设计模式之迭代器模式
     * 来源：http://www.cnblogs.com/zhili/p/IteratorPattern.html
     * 定义：
     * 迭代器模式提供了一种方法顺序访问一个聚合对象（理解为集合对象）中各个元素，
     * 而又无需暴露该对象的内部表示，这样既可以做到不暴露集合的内部结构，
     * 又可让外部代码透明地访问集合内部的数据
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {
            Iterator iterator;
            IListConnection list = new ConcreteList();
            iterator = list.GetIterator();
            while (iterator.MoveNext())
            {
                int i = (int)iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }
            Console.Read();
        }
    }
    public interface IListConnection
    {
        Iterator GetIterator(); 
    }
    public interface Iterator
    {
        bool MoveNext();
        Object GetCurrent();
        void Next();
        void Rest();
    }
    public class ConcreteList : IListConnection
    {
        int[] collection;
        public ConcreteList()
        {
            collection = new int[] { 2, 3, 4, 5 };
        }
        public Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }
        public int Length
        {
            get { return collection.Length; }
        }
        public int GetElement(int index)
        {
            return collection[index];
        }
    }
    public class ConcreteIterator : Iterator
    {
        private ConcreteList _list;
        private int _index;
        public ConcreteIterator(ConcreteList list)
        {
            _list = list;
            _index = 0;
        }
        public bool MoveNext()
        {
            if (_index < _list.Length)
            {
                return true;
            }
            return false;
        }
        public Object GetCurrent()
        {
            return _list.GetElement(_index);
        }
        public void Rest()
        {
            _index = 0;
        }
        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }
        }
    }
}
