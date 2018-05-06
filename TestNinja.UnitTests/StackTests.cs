using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        Stack<object> sut;

        [SetUp]
        public void SetUp()
        {
            sut = new Stack<object>();
        }

        [Test]
        public void Count_StackIsEmpty_ShouldReturn0()
        {
            var result = sut.Count;

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Count_Push2ItemsToStack_ShouldReturn2()
        {
            sut.Push(1);
            sut.Push("hello");
            var result = sut.Count;

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Push_PushNullIntoStack_ShouldThrowArgumentNullException()
        {
            Assert.That(() => sut.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_PushOneItemIntoStack_ShouldBeAbleToPeekItem()
        {
            sut.Push("hello");
            var result = sut.Peek();

            Assert.That(result, Is.EqualTo("hello"));
        }

        [Test]
        public void Push_PushAndPeekStack_ShouldReturnCountOf1()
        {
            sut.Push("hello");
            sut.Peek();
            var result = sut.Count;

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Pop_PopEmptyStack_ShouldThrowInvalidOpertionException()
        {
            Assert.Throws<InvalidOperationException>(() => sut.Pop());
        }

        [Test]
        public void Pop_PopStackWith1Item_ShouldReturnValueAndCountOf0()
        {
            sut.Push(1);
            var resultItem = sut.Pop();

            var result = sut.Count;

            Assert.That(resultItem, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Peek_PeekEmptyStack_ShouldThrowInvalidOpertionException()
        {
            Assert.Throws<InvalidOperationException>(() => sut.Peek());
        }

        [Test]
        public void Peek_PeekStackWith1Item_ShouldReturnValueAndCountOf1()
        {
            sut.Push(1);
            var resultItem = sut.Peek();

            var result = sut.Count;

            Assert.That(resultItem, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
