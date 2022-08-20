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
        #region Add 
        public void Add(T value)
        {
            throw new NotImplementedException();
        }
        public void AddTo(BinaryTreeNode<T> node, T value)
        {
            throw new NotImplementedException();
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
