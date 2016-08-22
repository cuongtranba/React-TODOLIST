using System.Diagnostics;

namespace ServiceImplementations
{
    public class TestService:ITestService
    {
        public void hello()
        {
            Debug.Write("hello");
        }
    }
}
