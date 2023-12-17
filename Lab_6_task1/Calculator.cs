using System;
using System.Collections.Generic;

namespace Lab_6_task1
{
    public class Calculator<T>
    {
        public delegate T ArithmeticOperationDelegate(T x, T y);

        public ArithmeticOperationDelegate Addition { get; set; }
        public ArithmeticOperationDelegate Subtraction { get; set; }
        public ArithmeticOperationDelegate Multiplication { get; set; }
        public ArithmeticOperationDelegate Division { get; set; }

        public Calculator()
        {
            Addition = (x, y) => (dynamic)x + y;
            Subtraction = (x, y) => (dynamic)x - y;
            Multiplication = (x, y) => (dynamic)x * y;
            Division = (x, y) =>
            {
                return (dynamic)x / y;
            };
        }

        public T PerformOperation(T x, T y, ArithmeticOperationDelegate operation)
        {
            return operation(x, y);
        }
        }
}
