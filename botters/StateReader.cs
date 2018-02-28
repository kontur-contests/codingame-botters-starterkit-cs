using System;
using System.Linq;

namespace botters
{
    public class StateReader : BaseStateReader
    {
        public StateReader(string input) : base(input)
        {
        }

        public StateReader() : base(Console.ReadLine)
        {
        }

        public InitData ReadInitData()
        {
            //int x = base.ReadInt();
            //int[] ys = base.ReadInts();
            return new InitData();
        }

        /// <summary>
        /// Для тестов
        /// </summary>
        public static State Read(string init, string state)
        {
            var initData = new StateReader(init).ReadInitData();
            return new StateReader(state).ReadState(initData);
        }

        public State ReadState(InitData initData)
        {
            //int x = base.ReadInt();
            //int[] ys = base.ReadInts();
            return new State();
        }
    }
}