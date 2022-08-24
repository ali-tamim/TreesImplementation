namespace AliTamim.BinaryTrees.Test
{
    public class BinaryTreeTest
    {
        BinaryTree<int> tree;
        [SetUp]
        public void Setup()
        {
            tree = new BinaryTree<int>();
        }

        [Test]
        public void TheHeadOfTheTreeAreEqualToFirstAddValue()
        {
            tree.Add(4);

            int expected = 4;
            int result = tree.GetHead().Value;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddValueIsLessThanTheCurrentNodeValue()
        {
            tree.Add(4);
            tree.Add(2);
            int? expected = 2;
            int? result = tree.GetHead().Left?.Value;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddValueIsGreaterThanTheCurrentNodeValue()
        {
            tree.Add(4);
            tree.Add(2);
            tree.Add(5);
            int? expected = 5;
            int? result = tree.GetHead().Right?.Value;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddValueIsEqualToTheCurrentNodeValue()
        {
            tree.Add(4);
            tree.Add(2);
            tree.Add(4);
            int? expected = 4;
            int? result = tree.GetHead().Right?.Value;
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}