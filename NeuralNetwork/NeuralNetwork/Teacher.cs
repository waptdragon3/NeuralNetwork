using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Learning
{
    /// <summary>
    /// Each teacher teaches a <see cref="NeuralNetwork"/> how to operate a task
    /// </summary>
    public abstract class Teacher
    {

        protected NeuralNetwork network;

        protected Teacher(NeuralNetwork network)
        {
            this.network = network ?? throw new ArgumentNullException(nameof(network));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expectedOutput"></param>
        /// <returns>The error</returns>
        public abstract double Run(double[] input, double[] expectedOutput);

        /// <summary>
        /// The method runs one learning epoch, by calling <see cref="Run(double[], double[])"/> for each vector provided in the input array.
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="expectedOutputs"></param>
        /// <returns>Sum of error for each Run call</returns>
        public double RunEpoch(double[][] inputs, double[][] expectedOutputs)
        {
            if (inputs.Length != expectedOutputs.Length) throw new ArgumentException("The number of cycles in inputs and expectedOutputs must be the same");

            double error = 0;
            for (int i = 0; i < inputs.Length; i++)
                error += Run(inputs[i], expectedOutputs[i]);

            return error;
        }

    }
}
