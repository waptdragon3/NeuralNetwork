using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public static class Equations
    {
        public static double Linear (double d)
        {
            return d;
        }

        public static double Sigmoid(double d)
        {
            return 1.0 / (1 + Math.Pow(Math.E, -d));
        }
    }
}
