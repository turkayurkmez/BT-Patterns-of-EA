using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public interface IMath
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);

      
    }

    public interface IAdvancedMath
    {
        int Modulo(int a, int b);
        double Power(int a, int b);
        int Factorial(int a);
    }

    public class SimpleMath : IMath
    {
        public int Add(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Divide(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Multiply(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Subtract(int a, int b)
        {
            throw new NotImplementedException();
        }
    }


}
