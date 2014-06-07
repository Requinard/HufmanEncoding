using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCompression
{
    class HuffmanTree
    {
        public HuffmanTree node_left { get; private set; }
        public HuffmanTree node_right { get; private set; }
        public HuffmanTree parent { get; private set; }
        public int weight { get; private set; }
        public char value { get; private set; }

        public HuffmanTree()
        {
            this.node_left = null;
            this.node_right = null;
            this.parent = null;
            this.weight = 0;
            this.value = (char)0;
        }

        private HuffmanTree(HuffmanTree node_left, HuffmanTree node_right, HuffmanTree parent, int weight, char value)
        {
            this.node_left = node_left;
            this.node_right = node_right;
            this.parent = parent;
            this.weight = weight;
            this.value = value;
        }

        public HuffmanTree createTree(string toCompress)
        {


            return this;
        }
    }
}
