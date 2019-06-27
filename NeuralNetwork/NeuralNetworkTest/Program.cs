using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace NeuralNetworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var nn = new NeuralNetwork.NeuralNetwork(Equations.Linear, 1, 2, 4, 8, 16, 32, 1);
            //set weights
            foreach (var layer in nn.layers)
            {
                for (int i = 0; i < layer.Weights.GetLength(0); i++)
                {
                    for (int j = 0; j < layer.Weights.GetLength(1); j++)
                    {
                        layer.Weights[i, j] = 1;
                    }
                    layer.Biases[i] = 0;
                }
            }

            Console.WriteLine(nn.Compute(new double[] { 1 })[0]);
        }
        static double func(double d) => d;
    }
}
