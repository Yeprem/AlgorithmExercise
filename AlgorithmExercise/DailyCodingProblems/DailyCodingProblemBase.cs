using System;

namespace AlgorithmExercise.DailyCodingProblems
{
    public abstract class DailyCodingProblemBase<TReturn>
    {
        public void Run()
        {
            Console.WriteLine(GetType().Name);

            RunIntrnal();

            Console.WriteLine();
        }

        protected abstract void RunIntrnal();

        protected abstract TReturn RunLogic(params object[] list);
    }
}
