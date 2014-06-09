using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCompression
{
    class HuffmanTree
    {
        public HuffmanTree node_left { get; set; }
        public HuffmanTree node_right { get; set; }
        public HuffmanTree parent { get; set; }
        public int weight { get; set; }
        public char value { get; set; }

        public Dictionary<char, int> ProbabilityDict;

        public Queue<bool> CompressedString;

        public HuffmanTree()
        {
            this.node_left = null;
            this.node_right = null;
            this.parent = null;
            this.weight = 0;
            this.value = (char)0;
        }
        public HuffmanTree(string toCompress)
        {
            this.node_left = null;
            this.node_right = null;
            this.parent = null;
            this.weight = 0;
            this.value = (char)0;

            this.CompressedString = new Queue<bool>();
            createTree(toCompress);
            compressString(toCompress);
        }

        private HuffmanTree(HuffmanTree node_left, HuffmanTree node_right, HuffmanTree parent, int weight, char value)
        {
            this.node_left = node_left;
            this.node_right = node_right;
            this.parent = parent;
            this.weight = weight;
            this.value = value;
        }

        private void compressString(string toCompress)
        {
            foreach (char c in toCompress)
            {
                HuffmanTree currentTree = this;
                int prob = this.ProbabilityDict[c];


                while(true)
                {
                    if (prob <= currentTree.node_left.weight)
                    {
                        if (currentTree.node_left == null)
                            break;
                        currentTree = currentTree.node_left;
                        this.CompressedString.Enqueue(false);
                    }
                    else
                    {
                        if (currentTree.node_right == null)
                            break;
                        currentTree = currentTree.node_right;
                        this.CompressedString.Enqueue(true);
                    }
                }
            }
        }

        /// <summary>
        /// Creates an entire huffman tree based on a string that needs to be compressed
        /// </summary>
        /// <param name="toCompress">String that needs compressing</param>
        /// <returns>Complete Huffman priority queue</returns>
        private void createTree(string toCompress)
        {
            Dictionary<char, int> _wDict = cDict(toCompress);

            _wDict = sDict(_wDict);

            PriorityQueue <HuffmanTree> _eQueue = cDict(_wDict);

            HuffmanTree tree = fillTree(_eQueue);

            this.node_left = tree.node_left;
            this.node_right = tree.node_right;
            this.weight = tree.weight;
            this.value = tree.value;
            this.parent = tree.parent;
            this.ProbabilityDict = _wDict;
        }

        private HuffmanTree fillTree(PriorityQueue<HuffmanTree> _eQueue)
        {
            while (_eQueue.count > 1)
            {
                ///Dequeue children
                HuffmanTree node1 = _eQueue.Dequeue();
                HuffmanTree node2 = _eQueue.Dequeue();

                ///Create new parent
                HuffmanTree parent = new HuffmanTree();

                ///Set up relations
                parent.node_left = node1;
                parent.node_right = node2;
                node1.parent = parent;
                node2.parent = parent;

                ///Give parent the weight of it's children combined
                parent.weight = node1.weight + node2.weight;

                ///Reinsert parent into priority queue
                _eQueue.Enqueue(parent, parent.weight);
            }

            ///Return the last object in the queue
            return _eQueue.Dequeue();
        }

        /// <summary>
        /// Creates a Priotity Queue from an unsorted dictionairy
        /// </summary>
        /// <param name="_wDict">Dictionairy with characters and weights</param>
        /// <returns></returns>
        private PriorityQueue<HuffmanTree> cDict(Dictionary<char, int> _wDict)
        {
            ///Existing nodes
            PriorityQueue<HuffmanTree> _nQueue = new PriorityQueue<HuffmanTree>();

            foreach (var item in _wDict.Keys)
            {
                _nQueue.Enqueue(new HuffmanTree(null, null, null, _wDict[item], item), _wDict[item]);
            }

            return _nQueue;
        }

        /// <summary>
        /// Returns a sorted dictionairy
        /// </summary>
        /// <param name="_wdict"></param>
        /// <returns></returns>
        private Dictionary<char, int> sDict(Dictionary<char, int> _wdict)
        {
            Console.WriteLine("Starting sorting procedure");

            var _sDict = from entry in _wdict orderby entry.Value ascending select entry;

            return _sDict.ToDictionary(t => t.Key, t => t.Value);
        }

        /// <summary>
        /// Compresses a string into a dictionairy holding the weight of each character
        /// </summary>
        /// <param name="s">String that needs to be compressed</param>
        /// <returns>Dictionairy containing weight for each character in a string</returns>
        private Dictionary<char, int> cDict(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                    dict[c] += 1;
                else
                    dict[c] = 1;
            }

            return dict;
        }
    }
}
