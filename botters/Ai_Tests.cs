using NUnit.Framework;

namespace botters
{
    [TestFixture]
    public class Ai_Tests
    {
        // Если вы заметили в визуализаторе, как ваш бот делает странный ход, 
        // то можно его отладить с помощью этого теста. 
        // Копи-пастите залогированное состояние в параметры TestCase и запускаете тест под отладкой.
        [TestCase("init|data", "some|input|", "expectedOutput")]
        public void GetMove(string initData, string input, string expectedOutput)
        {
            var ai = new Ai();
            string nextMove = ai.GetNextMove(StateReader.Read(initData, input), new Countdown(50));
            Assert.That(nextMove, Is.EqualTo("Command"));
        }
    }
}