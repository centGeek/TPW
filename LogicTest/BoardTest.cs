using Logic;
using Data; 
namespace DataTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void GetterSetterConstuctorTest()
        {
            LogicBoard board = new LogicBoard(new Board(3, 5));
            Assert.AreEqual(5, board.GetHeight()); 
            Assert.AreEqual(3, board.GetWidth());

            board.SetHeight(5);
            board.SetWidth(8); 

            Assert.AreEqual(5, board.GetHeight());
            Assert.AreEqual(8, board.GetWidth());
        }
        [TestMethod]

        public void initializeBoard()
        {

        }
    }
}