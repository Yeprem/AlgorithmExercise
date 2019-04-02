using System;

namespace AlgorithmExercise
{
    public abstract class AlgorithmBase
    {
        public void Run()
        {
            Console.WriteLine(GetType().Name);

            RunIntrnal();

            Console.WriteLine();
        }
        protected abstract void RunIntrnal();
    }
}
