using System;

namespace NeuralNetwork
{
    /// <summary>
    /// The layers making up the Neural Network
    /// </summary>
    public class Layer
    {
        public Neuron[] Neurons { get; private set; }

        internal Layer(System.Func<double, double> activationFunction, int size, int prevSize = 0)
        {
            this.Neurons = new Neuron[size];
            for (int i = 0; i < size; i++)
            {
                this.Neurons[i] = new Neuron(activationFunction, prevSize);
            }
        }

        public int Length => Neurons.Length;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputs"> The value returned by the neurons of the previous layer or the inputs to the network</param>
        /// <returns></returns>
        internal double[] Compute(double[] inputs)
        {
            double[] res = new double[Neurons.Length];
            for (int i = 0; i < res.Length; i++)
                res[i] = Neurons[i].Compute(inputs);
            return res;
        }
    }
}
