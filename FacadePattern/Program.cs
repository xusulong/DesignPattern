using System;

namespace FacadePattern
{
    /**
     * 
     * 设计模式の外观模式
     * 来源：http://www.cnblogs.com/zhili/p/FacadePattern.html
     * 定义：外观模式提供了一个统一的接口，用来访问子系统中的一群接口。
     * 外观定义了一个高层接口，让子系统更容易使用。
     * 使用外观模式时，我们创建了一个统一的类，用来包装子系统中一个或多个复杂的类
     * 客户端可以直接通过外观类来调用内部子系统中方法，从而外观模式让客户和子系统之间避免了紧耦合。
     * 
     * 
     * **/
    class Program
    {
        private static RegistrationFacade facade = new RegistrationFacade(); 
        static void Main(string[] args)
        {
            if (facade.RegisterCourse("C++程序设计", "钱能"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }
            Console.Read();
        }
    }

    /// <summary>
    /// 外观类，包含了两个子系统，对外统一提供服务
    /// </summary>
    public class RegistrationFacade
    {
        private RegisterCourse registerCourse;
        private NotifyStudent notifyStu;
        public RegistrationFacade()
        {
            registerCourse = new RegisterCourse();
            notifyStu = new NotifyStudent();
        }
        /// <summary>
        /// 调用两个子系统的方法，协同完成选课
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool RegisterCourse(string courseName, string studentName)
        {
            if (!registerCourse.CheckAvailable(courseName))
            {
                return false;
            }
            return notifyStu.Notify(studentName);
        }
    }
    #region 子系统

    /// <summary>
    /// 相当于子系统A，完成验证课程人数工作
    /// </summary>
    public class RegisterCourse
    {
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程{0}是否人数已满", courseName);
            return true;
        }
    }
    /// <summary>
    /// 相当于子系统B，完成发送通知
    /// </summary>
    public class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向{0}发生通知", studentName);
            return true;
        }
    } 
    #endregion

}
