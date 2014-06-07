using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuffmanCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanTree tree = new HuffmanTree();

            tree.createTree("j'aime aller sur le bord de l'eau les jeudis ou les jours impairs");

            return;
        }
    }
}
