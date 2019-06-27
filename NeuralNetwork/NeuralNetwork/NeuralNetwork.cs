using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        public Layer[] layers { get; protected set; }
        public int InputCount { get; protected set; }
        public int OutputCount { get; protected set; }

        public NeuralNetwork(Func<double, double> activationFunction, int inputSize, params int[] layersCount)
        {
            InputCount = inputSize;
            OutputCount = layersCount[layersCount.Length - 1];
            layers = new Layer[layersCount.Length + 1];
            layers[0] = new Layer(activationFunction, inputSize) { IsStart = true };
            layers[1] = new Layer(activationFunction, layersCount[1], inputSize);
            for (int i = 2; i < layersCount.Length+1; i++)
            {
                layers[i] = new Layer(activationFunction, layersCount[i-1], layersCount[i - 2]);
            }
        }

        public double[] Compute(double[] inputs)
        {
            if (inputs.Length != InputCount) throw new ArgumentOutOfRangeException(nameof(inputs), "The length of the input array does not equal the input size of the Network");
            double[] res = inputs;
            for (int i = 0; i < layers.Length; i++)
            {
                Console.WriteLine(i + " = " + res[0]);
                res = layers[i].Compute(res);
            }

            Console.WriteLine(layers.Length + " = " + res[0]);

            return res;
        }
    }
}