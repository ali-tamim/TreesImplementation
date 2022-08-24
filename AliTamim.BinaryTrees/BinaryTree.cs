
#define tdd
using System.Collections;

namespace AliTamim.BinaryTrees
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head; // Root of the tree
        private int _count;

        #region Add 
        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            } else
            {
                AddTo(_head, value);
            }
            _count++;
        }
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            // value is less than the current node value
            if(value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                } else
                {
                    AddTo(node.Left, value);
                }
            } else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                } else
                {
                    AddTo(node.Right, value);
                }
            }
        }
        #endregion

        #region Find
        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _head;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                } else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                } else
                {
                    break;
                }
            }

            return current;
        }
        #endregion

        #region remove
        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;

            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }
            _count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    _head = current.Left;
                } else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    } else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            } else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left; // reconncted
                if (parent == null)
                {
                    _head = current.Left;
                } else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            } else
            {
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right.Left;

                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftmost;
                } else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }
            return true;
        }
        #endregion

        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion

        #if tdd
        public BinaryTreeNode<T> GetHead()
        {
            return _head;
        }
        #endif
    }
}
