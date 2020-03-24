using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using vector_accelerator_project;

// Note that my classes are incomplete, and not comprehensive. Only tested methods that I was suspicious of, and are prone to break
// in my opinion

namespace MovementTests
{
    [TestClass]
    public class MovementVariableTests
    {
        [TestMethod]
        public void MovemmentVariables_initialization()
        {
            MovementVariables stuff = new MovementVariables();
            Assert.AreEqual(stuff.Segment_positions.Last()[0], 0.0, 0.0, "Segment_position array initialization is wrong");
            Assert.AreEqual(stuff.Segment_positions.Last().Count(), 6, 0, "Segment_position array size is wrong");
            Assert.ThrowsException<System.IndexOutOfRangeException>(() => stuff.Segment_positions.Last()[7]); // have to declare the function this way because the actual argument is of type Func<Object>  meaning it does not take any parameters, and accepts any return value, and because we only want to check for throwing an exception, it is fine
        }

        [TestMethod]
        public void MovementVariables_addSegmentValid()
        {
            MovementVariables stuff = new MovementVariables();
            Assert.AreEqual(stuff.Segment_positions.Count, 1, 0, "Segment list count initialized");
            int[] coor1 = {0, 1, 1, 0, 1, 1};
            append(stuff.Segment_positions.Last(), coor1);
            bool actual = stuff.add_Segment(null);
            Assert.IsTrue(actual);
            Assert.AreEqual(stuff.Segment_positions.Count, 2, 0, "Segment list count increased");

            int[] coor2 = { 0, 0, 0, 0, 0, 0 };
            append(stuff.Segment_positions.Last(), coor2);
            bool actual2 = stuff.add_Segment(null);
            Assert.IsFalse(actual2);
            Assert.AreEqual(stuff.Segment_positions.Count, 2, 0, "Segment list count constant"); // fail to add segment

            int[] coor3 = { -100, 0, 1, -200, 0, 2 };
            append(stuff.Segment_positions.Last(), coor3);
            bool actual3 = stuff.add_Segment(null);
            Assert.IsTrue(actual3);
            Assert.AreEqual(stuff.Segment_positions.Count, 3, 0, "Segment list count increased");

            int[] coor4 = { -100, 100, 1, -200, 0, 1 };
            append(stuff.Segment_positions.Last(), coor4);
            bool actual4 = stuff.add_Segment(null);
            Assert.IsTrue(actual4);
            Assert.AreEqual(stuff.Segment_positions.Count, 4, 0, "Segment list count increased");

        }

        // Method used in above test:
        public void append(int [] arr, int[] arr2)
        {
            arr[0] = arr2[0];
            arr[1] = arr2[1];
            arr[2] = arr2[2];
            arr[3] = arr2[3];
            arr[4] = arr2[4];
            arr[5] = arr2[5];
        }


        [TestMethod]
        public void mmUnit_setStartPosition()
        {
            MovementVariables stuff = new MovementVariables_mmUnit();
            stuff.set_StartPosition(1, 5);
            Assert.AreEqual(stuff.Start_position[1], 5*207, 0, "mmUnit set_StartPosition problem");
            Assert.AreNotEqual(stuff.Start_position[0], 5*207, 0, "mmUnit set_StartPosition problem");

            stuff.set_StartPosition(1, -5);
            Assert.AreEqual(stuff.Start_position[1], -5 * 207, 0, "mmUnit set_StartPosition cannot be reassigned");

            bool inRange = stuff.set_StartPosition(2, 5);
            Assert.IsFalse(inRange, "Still in range of startPosition array");
        }

        [TestMethod]
        public void mmUnit_setSegmentPosition()
        {
            MovementVariables stuff = new MovementVariables_mmUnit();
            int countNow = stuff.Segment_positions.Count;

            stuff.set_SegmentPosition(1, 5);
            Assert.AreEqual(stuff.Segment_positions.Last()[1], 5 * 207, 0, "mmUnit set_SegmentPosition problem");
            Assert.AreNotEqual(stuff.Segment_positions.Last()[0], 5 * 207, 0, "mmUnit set_SegmentPosition problem");

            stuff.set_SegmentPosition(1, -5);
            Assert.AreEqual(stuff.Segment_positions.Last()[1], -5 * 207, 0, "mmUnit set_SegmentPosition cannot be reassigned");

            bool inRange = stuff.set_SegmentPosition(6, 5);
            Assert.IsFalse(inRange, "Still in range of segmentPosition array");

            int countAfter = stuff.Segment_positions.Count;
            Assert.AreEqual(countNow, countAfter, 0, "Segment Position array has changed after set_segmentPosition operation");
        }
    }

    [TestClass]
    public class MovementTests
    {

    }
}
