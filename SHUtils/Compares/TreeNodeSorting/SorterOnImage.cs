using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace SHUtils.Compares.TreeNodeSorting
{
    public class SorterOnImage : IComparer
    {
        // Compare the length of the strings, or the strings 
        // themselves, if they are the same length. 
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            if (tx.SelectedImageIndex == ty.SelectedImageIndex)
            {
                return string.Compare(tx.Text, ty.Text);
            }
            return tx.SelectedImageIndex - ty.SelectedImageIndex;
        }
    }
}
