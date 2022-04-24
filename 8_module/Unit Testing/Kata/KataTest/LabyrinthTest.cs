using Kata;
using NUnit.Framework;

namespace KataTest
{
    [TestFixture]
    public class LabyrinthTest
    {
        [Test]
        public void Possible_To_Find_Exit_Returns_True_And_Path_Followed()
        {
            char[,] labyrinthMap = new char[6, 6] { { '*', '*', '*', '*' , '*', '*' },
                                            { '_', '*', '_', '_' , '_', '*' },
                                            { '*', 's', '_', '*' , '_', '*' },
                                            { '*', '*', '*', '*' , '_', '*' },
                                            { '_', '_', 'e', '_' , '_', '*' },
                                            { '_', '*', '*', '*' , '_', '*' }};

            var labyrinth = new Labyrinth();
            var actual = labyrinth.FindExitFromLabyrinth(labyrinthMap, out string path);
            Assert.AreEqual(true, actual);
            Assert.AreEqual("S R U R R D D D L", path);
        }

        [Test]
        public void Impossible_To_Find_Exit_Returns_False_And_NoWayFound_String()
        {
            char[,] labyrinthMap = new char[6, 6] { { '*', '*', '*', '*' , '*', '*' },
                                            { '_', '*', '_', '_' , '_', '*' },
                                            { '*', 's', '_', '*' , '_', '*' },
                                            { '*', '*', '*', '*' , '_', '*' },
                                            { '_', '_', 'e', '*' , '_', '*' },
                                            { '_', '*', '*', '*' , '_', '*' }};

            var labyrinth = new Labyrinth();
            var actual = labyrinth.FindExitFromLabyrinth(labyrinthMap, out string path);
            Assert.AreEqual(false, actual);
            Assert.AreEqual("No Way Found", path);
        }
    }
}
