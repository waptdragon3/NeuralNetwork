using System;

namespace NeuralNetwork
{
    /// <summary>
    /// The layers making up the Neural Network
    /// </summary>
    public class Layer
    {
        public double[,] Weights { get; private set; }
        public double[] Biases { get; private set; }
        Func<double, double> activationFunction;
        internal Layer(System.Func<double, double> activationFunction, int size, int prevSize = 0)
        {
            this.activationFunction = activationFunction;
            Weights = new double[size, prevSize];
            Biases = new double[size];
        }
        internal bool IsStart = false;

        public int Length => Biases.Length;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputs"> The value returned by the neurons of the previous layer or the inputs to the network</param>
        /// <returns></returns>
        internal double[] Compute(double[] inputs)
        {
            if (IsStart) return inputs;
            double[] v = mult(Weights, inputs);
            for (int i = 0; i < v.Length; i++)
                v[i] = activationFunction(v[i]+Biases[i]);
            return v;

        }

        private double[] mult(double[,] w, double[] a)
        {
            double[] res = new double[w.GetLength(0)];
            for(int i = 0; i < w.GetLength(0); i++)
            {
                for (int j = 0; j < w.GetLength(1); j++)
                {
                    res[i] += w[i, j] * a[j];
                }
            }
            return res;
        }
    }
}
