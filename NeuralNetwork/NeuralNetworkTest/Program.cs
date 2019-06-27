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
            var nn = new NeuralNetwork.NeuralNetwork(Equations.Sigmoid, 1, 2, 4, 8, 16, 32, 1);
            //set weights
            foreach (var layer in nn.layers)
            {
                foreach (var neuron in layer.Neurons)
                {
                    neuron.Bias = 0;
                    for (int i = 0; i < neuron.Weights.Length; i++)
                    {
                        neuron.Weights[i] = 1;
                    }
                }
            }

            Console.WriteLine(nn.Compute(new double[] { 1 })[0]);
        }
        static double func(double d) => d;
    }
}
