using System;

namespace NeuralNetwork
{
    public class Neuron
    {
        internal readonly Func<double, double> activationFunction;
        public int InputCount { get; internal set; }
        /// <summary>
        /// The weights of the synapses from this Neuron to the neurons of the previous layer
        /// </summary>
        public double[] Weights { get; set; }

        public double Bias { get; set; }

        public double Compute(double[] inputs)
        {
            double v = Bias;
            for (int i = 0; i < InputCount; i++)
            {
                v += inputs[i] * Weights[i];
            }
            return activationFunction(v);
        }

        internal Neuron(Func<double, double> activationFunction, int inputCount)
        {
            this.activationFunction = activationFunction ?? throw new ArgumentNullException(nameof(activationFunction));
            InputCount = inputCount;
            Weights = new double[inputCount];
            for (int i = 0; i < inputCount; i++)
                Weights[i] = Util.Random.NextDouble();
            Bias = Util.Random.NextDouble();
        }
    }
}