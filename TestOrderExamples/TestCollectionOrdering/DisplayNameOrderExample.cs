﻿using Xunit;

// Set the orderer
[assembly: TestCollectionOrderer("TestOrderExamples.TestCollectionOrdering.DisplayNameOrderer", "TestOrderExamples")]

// Need to turn off test parallelization so we can validate the run order
[assembly: CollectionBehavior(DisableTestParallelization = true)]

public class DisplayNameOrderExample
{
    [CollectionDefinition("Xyz Test Collection")]
    public class Collection1 { }

    [Collection("Xzy Test Collection")]
    public class TestsInCollection1
    {
        public static bool Collection1Run;

        [Fact]
        public static void Test()
        {
            Assert.True(TestsInCollection2.Collection2Run);     // Abc
            Assert.True(TestsInCollection3.Collection3Run);     // Mno
            Assert.False(TestsInCollection1.Collection1Run);    // Xyz

            Collection1Run = true;
        }
    }

    [CollectionDefinition("Abc Test Collection")]
    public class Collection2 { }

    [Collection("Abc Test Collection")]
    public class TestsInCollection2
    {
        public static bool Collection2Run;

        [Fact]
        public static void Test()
        {
            Assert.False(TestsInCollection2.Collection2Run);    // Abc
            Assert.False(TestsInCollection3.Collection3Run);    // Mno
            Assert.False(TestsInCollection1.Collection1Run);    // Xyz

            Collection2Run = true;
        }
    }

    [CollectionDefinition("Mno Test Collection")]
    public class Collection3 { }

    [Collection("Mno Test Collection")]
    public class TestsInCollection3
    {
        public static bool Collection3Run;

        [Fact]
        public static void Test()
        {
            Assert.True(TestsInCollection2.Collection2Run);     // Abc
            Assert.False(TestsInCollection3.Collection3Run);    // Mno
            Assert.False(TestsInCollection1.Collection1Run);    // Xyz

            Collection3Run = true;
        }
    }
}
