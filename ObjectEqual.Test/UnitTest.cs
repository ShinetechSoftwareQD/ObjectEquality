using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectEquality.Test
{
    [TestClass]
    public class UnitTest
    {
        private ObjectEquality _objectEquality = null;



        [TestInitialize]
        public void SetEquality()
        {
            _objectEquality = new ObjectEquality();
        }

        [TestMethod]
        public void TestValueType()
        {
            var a = 1;
            var b = 1;

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestValueTypeError()
        {
            var a = 1;
            var b = 2;

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestArray()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 2, 3 };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestArrayError()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 2, 4 };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestSimpleClass()
        {
            var a = new SimpleClass
            {
                Id = 1,
                Name = "A"
            };

            var b = new SimpleClass
            {
                Id = 1,
                Name = "A"
            };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestSimpleClassError()
        {
            var a = new SimpleClass
            {
                Id = 1,
                Name = "A"
            };

            var b = new SimpleClass
            {
                Id = 1,
                Name = "B"
            };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestComplexClass()
        {
            var a = new ComplexClass
            {
                Id = 1,
                Strs = new System.Collections.Generic.List<string> { "A", "B" }
            };

            var b = new ComplexClass
            {
                Id = 1,
                Strs = new System.Collections.Generic.List<string> { "A", "B" }
            };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestComplexClassError()
        {
            var a = new ComplexClass
            {
                Id = 1,
                Strs = new System.Collections.Generic.List<string> { "A", "B" }
            };

            var b = new ComplexClass
            {
                Id = 1,
                Strs = new System.Collections.Generic.List<string> { "A", "C" }
            };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestEnumInClass()
        {
            var a = new EnumClass
            {
                Test = TestEnum.A
            };

            var b = new EnumClass
            {
                Test = TestEnum.A
            };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestEnumInClassError()
        {
            var a = new EnumClass
            {
                Test = TestEnum.A
            };

            var b = new EnumClass
            {
                Test = TestEnum.B
            };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestEnumValue()
        {
            var a = TestEnum.A;

            var b = TestEnum.A;

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestEnumValueError()
        {
            var a = TestEnum.A;

            var b = TestEnum.B;

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStruct()
        {
            var a = new DemoStruct();
            a.Id = 1;
            a.Name = "Test";

            var b = new DemoStruct();
            b.Id = 1;
            b.Name = "Test";

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStructError()
        {
            var a = new DemoStruct();
            a.Id = 1;
            a.Name = "Test";

            var b = new DemoStruct();
            b.Id = 2;
            b.Name = "Test";

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStructWithClass()
        {
            var a = new StructWithClass();
            a.SimpleClass = new SimpleClass
            {
                Id = 1,
                Name = "Test"
            };

            var b = new StructWithClass();
            b.SimpleClass = new SimpleClass
            {
                Id = 1,
                Name = "Test"
            };

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStructWithClassError()
        {
            var a = new StructWithClass();
            a.SimpleClass = new SimpleClass
            {
                Id = 1,
                Name = "Test"
            };

            var b = new StructWithClass();
            b.SimpleClass = new SimpleClass
            {
                Id = 2,
                Name = "Test"
            };

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestLooseArray()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 2, 1, 3 };

            ObjectEqualityOptions.Current.ArrayEqualityMode = ArrayEqualityMode.Loose;
            var objectEquality = new ObjectEquality();
            Assert.IsTrue(objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestLooseArrayError()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 1, 3 };

            ObjectEqualityOptions.Current.ArrayEqualityMode = ArrayEqualityMode.Loose;
            var objectEquality = new ObjectEquality();
            Assert.IsTrue(!objectEquality.IsEqual(a, b));
        }


        [TestMethod]
        public void TestStrictArray()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 2, 1, 3 };

            ObjectEqualityOptions.Current.ArrayEqualityMode = ArrayEqualityMode.Strict;
            var objectEquality = new ObjectEquality();
            Assert.IsTrue(!objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStrictArrayError()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 1, 3 };

            ObjectEqualityOptions.Current.ArrayEqualityMode = ArrayEqualityMode.Strict;
            var objectEquality = new ObjectEquality();
            Assert.IsTrue(!objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestString()
        {
            var a = "a";
            var b = "a";

            Assert.IsTrue(_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestStringError()
        {
            var a = "a";
            var b = "b";

            Assert.IsTrue(!_objectEquality.IsEqual(a, b));
        }

        [TestMethod]
        public void TestCycleReferenceException()
        {
            Assert.ThrowsException<CycleReferenceException>(() =>
            {
                var wrappedClassA = new WrappedClass
                {
                    Field = "A"
                };

                wrappedClassA.Inner = wrappedClassA;


                var wrappedClassB = new WrappedClass
                {
                    Field = "A"
                };

                wrappedClassB.Inner = wrappedClassB;

                _objectEquality.IsEqual(wrappedClassA, wrappedClassB);
            });

        }
    }


}
