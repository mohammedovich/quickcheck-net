using System;
using QuickCheck.Random;

namespace QuickCheck
{
    public class TestableAction : ITestable
    {
        private readonly Action m_Test;

        public TestableAction(Action test)
        {
            m_Test = test;
        }

        public TestResult RunTest(IRandom gen, int size)
        {
            var args = new TestArgs(m_Test.Method);

            try
            {
                m_Test();
                return TestResult.Success(args);
            }
            catch (Exception exception)
            {
                return TestResult.Failure(args, exception);
            }
        }
    }

    public class TestableAction<A> : ITestable
    {
        private readonly Action<A> m_Test;

        public TestableAction(Action<A> test)
        {
            m_Test = test;
        }

        public TestResult RunTest(IRandom gen, int size)
        {
            var a = gen.Arbitrary<A>(size);
            var args = new TestArgs(m_Test.Method, a);

            try
            {
                m_Test(a);
                return TestResult.Success(args);
            }
            catch (Exception exception)
            {
                return TestResult.Failure(args, exception);
            }
        }
    }

    public class TestableAction<A, B> : ITestable
    {
        private readonly Action<A, B> m_Test;

        public TestableAction(Action<A, B> test)
        {
            m_Test = test;
        }

        public TestResult RunTest(IRandom gen, int size)
        {
            var a = gen.Arbitrary<A>(size);
            var b = gen.Arbitrary<B>(size);
            var args = new TestArgs(m_Test.Method, a, b);

            try
            {
                m_Test(a, b);
                return TestResult.Success(args);
            }
            catch (Exception exception)
            {
                return TestResult.Failure(args, exception);
            }
        }
    }
}
