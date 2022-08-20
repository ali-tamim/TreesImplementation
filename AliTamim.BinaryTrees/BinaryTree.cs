using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliTamim.BinaryTrees
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;
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
        #endregion

        #region remove
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
    }
}
