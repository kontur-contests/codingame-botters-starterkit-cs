using System;
using System.Linq;
using NUnit.Framework;

namespace botters
{
    [TestFixture]
    public class Ai_Tests
    {
        // Если вы заметили в визуализаторе, как ваш бот делает странный ход, 
        // то можно его отладить с помощью этого теста. 
        // Копи-пастите залогированное состояние в параметры TestCase и запускаете тест под отладкой.
        [TestCase("0|0|0|",
            "109|109|1|12|1 0 TOWER 100 540 400 1500 1500 0 100 0 0 0 0 0 0 0 0 0 - 1 0|2 1 TOWER 1820 540 400 1500 1500 0 100 0 0 0 0 0 0 0 0 0 - 1 0|3 0 HERO 200 590 270 820 820 0 60 200 0 300 0 0 0 200 200 2 IRONMAN 1 0|4 1 HERO 1720 590 95 1450 1450 0 80 200 0 300 0 0 0 90 90 1 HULK 1 0|5 0 UNIT 160 490 90 400 400 0 25 150 0 30 0 0 0 0 0 0 - 1 0|6 0 UNIT 160 540 90 400 400 0 25 150 0 30 0 0 0 0 0 0 - 1 0|7 0 UNIT 160 590 90 400 400 0 25 150 0 30 0 0 0 0 0 0 - 1 0|8 0 UNIT 110 490 300 250 250 0 35 150 0 50 0 0 0 0 0 0 - 1 0|9 1 UNIT 1760 490 90 400 400 0 25 150 0 30 0 0 0 0 0 0 - 1 0|10 1 UNIT 1760 540 90 400 400 0 25 150 0 30 0 0 0 0 0 0 - 1 0|11 1 UNIT 1760 590 90 400 400 0 25 150 0 30 0 0 0 0 0 0 - 1 0|12 1 UNIT 1810 490 300 250 250 0 35 150 0 50 0 0 0 0 0 0 - 1 0|",
            "ATTACK_NEAREST UNIT")]
        public void GetMove(string initData, string input, string expectedOutput)
        {
            var ai = new Ai();
            string nextMove = ai.GetNextMove(StateReader.Read(initData, input), new Countdown(50));
            Assert.That(nextMove, Is.EqualTo(expectedOutput));
        }
    }
}