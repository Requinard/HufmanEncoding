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

        /// <summary>
        /// Creates an entire huffman tree based on a string that needs to be compressed
        /// </summary>
        /// <param name="toCompress">String that needs compressing</param>
        /// <returns>Complete Huffman priority queue</returns>
        public HuffmanTree createTree(string toCompress)
        {
            Dictionary<char, int> weightDictionairy = createDictionairy(toCompress);

            return this;
        }

        /// <summary>
        /// Compresses a string into a dictionairy holding the weight of each character
        /// </summary>
        /// <param name="s">String that needs to be compressed</param>
        /// <returns>Dictionairy containing weight for each character in a string</returns>
        private Dictionary<char, int> createDictionairy(string s)
        {
            Console.WriteLine("Starting string compression");
            Dictionary<char, int> dict = new Dictionary<char, int>();

            Console.WriteLine("Starting iterating through string")
            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                    dict[c] += 1;
                else
                    dict[c] = 1;

                Console.WriteLine("Char %s has appeared %d times", c, dict[c]);
            }

            return dict;
        }
    }
}
