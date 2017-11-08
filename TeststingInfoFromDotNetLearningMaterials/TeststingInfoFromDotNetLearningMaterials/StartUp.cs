namespace TeststingInfoFromDotNetLearningMaterials
{
    using BinaryTreeFolder;
    using HashTableProject;
    using MergeSortProject;
    using Graph;
    using GraphsProject;
    using RLEAlgorithm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TreeProject;

    public class StartUp
    {
        // To create vertex connection using matrix use the MatrixCreator method which expects string
        // To create a HashTable and check if it works use the HardCodedHashTable method below
        // To create a tree and search in it use the CreateATree method below
        // To create a non binary tree use the method HardCodedNonBinaryTree below
        // The graph is hardcoded in order to be tested easier. it expects string a letter between a-f to find the shortest path from this point to any available point on the graph
        // To merge sort use the MergeSort method below, it expects list of elements to search and if it is TopUp or BottomDown true or false value. (TopDownMergeSort/BottomUpMergeSort it is generic)

        public static void Main()
        {
            Converter converter = new Converter();

            converter.FromString();
            converter.Insert();
            converter.Remove();
            converter.FromCode();
        }

        private static void SimpleGraphTest(string fromPoint)
        {
            Vertex a = new Vertex()
            {
                Name = "a"
            };

            Vertex b = new Vertex()
            {
                Name = "b"
            };

            Vertex c = new Vertex()
            {
                Name = "c"
            };

            Vertex d = new Vertex()
            {
                Name = "d"
            };

            Vertex e = new Vertex()
            {
                Name = "e"
            };

            Vertex f = new Vertex()
            {
                Name = "f"
            };

            Vertex g = new Vertex()
            {
                Name = "g"
            };

            Vertex h = new Vertex()
            {
                Name = "h"
            };

            Vertex i = new Vertex()
            {
                Name = "i"
            };

            Vertex j = new Vertex()
            {
                Name = "j"
            };

            Vertex k = new Vertex()
            {
                Name = "k"
            };

            Vertex l = new Vertex()
            {
                Name = "l"
            };

            Vertex m = new Vertex()
            {
                Name = "m"
            };

            Vertex n = new Vertex()
            {
                Name = "n"
            };

            Vertex o = new Vertex()
            {
                Name = "o"
            };

            Vertex p = new Vertex()
            {
                Name = "p"
            };

            Vertex q = new Vertex()
            {
                Name = "q"
            };

            Vertex r = new Vertex()
            {
                Name = "r"
            };

            SimpleGraph graph = new SimpleGraph();

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);
            graph.AddVertex(g);
            graph.AddVertex(h);
            graph.AddVertex(i);
            graph.AddVertex(j);
            graph.AddVertex(k);
            graph.AddVertex(l);
            graph.AddVertex(m);
            graph.AddVertex(n);
            graph.AddVertex(o);
            graph.AddVertex(p);
            graph.AddVertex(q);
            graph.AddVertex(r);

            graph.AddEdge("a", "b", 1);
            graph.AddEdge("a", "c", 4);
            graph.AddEdge("a", "d", 5);
            graph.AddEdge("b", "d", 3);
            graph.AddEdge("c", "d", 6);
            graph.AddEdge("d", "e", 2);
            graph.AddEdge("d", "f", 3);
            graph.AddEdge("e", "c", 10);
            graph.AddEdge("e", "g", 7);
            graph.AddEdge("f", "e", 2);
            graph.AddEdge("f", "g", 4);
            graph.AddEdge("f", "h", 2);
            graph.AddEdge("g", "h", 5);
            graph.AddEdge("g", "i", 3);
            graph.AddEdge("i", "h", 3);
            graph.AddEdge("h", "l", 1);
            graph.AddEdge("l", "j", 2);
            graph.AddEdge("j", "k", 1);
            graph.AddEdge("j", "n", 4);
            graph.AddEdge("j", "m", 3);
            graph.AddEdge("k", "n", 2);
            graph.AddEdge("m", "o", 6);
            graph.AddEdge("n", "m", 4);
            graph.AddEdge("n", "p", 8);
            graph.AddEdge("o", "p", 2);
            graph.AddEdge("p", "q", 20);
            graph.AddEdge("q", "r", 2);

            var smt = graph.FindShortestPaths(fromPoint);

            foreach (var item in smt)
            {
                if (item.Value == int.MaxValue)
                {
                    Console.WriteLine($"No available path was found between {fromPoint} and {item.Key.Name}");
                }
                else
                {
                    Console.WriteLine($"shortest path to vertex {item.Key.Name} from vertex {fromPoint} is {item.Value}");
                }
            }
        }

        /// <summary>
        /// Merge sorts list of elements. Can be chosen if topDown or BottomUp by passing true or false value as argument to the method. By default it is topDown
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">List of elements</param>
        /// <param name="isTopDown">true or false whether is top down or bottom up</param>
        private static void MergeSort<T>(IList<T> collection, bool isTopDown = true)
            where T : IComparable
        {
            MergeSorter sorter = new MergeSorter();

            var returned = sorter.SplitThenSort(collection, isTopDown);

            PrintCollection(returned);
        }

        /// <summary>
        /// Creates adjacency matrix from the passed string by splitting it to char array
        /// </summary>
        /// <param name="vertecies">string which will be converted to char array</param>
        private static void MatrixCreator(string vertecies)
        {
            CreateMatrix matrix = new CreateMatrix();

            matrix.CreateMatrixVertex(vertecies);
        }

        /// <summary>
        /// Creates simple tree, makes DFS and BFS traverse and prints them on the console 
        /// </summary>
        private static void HardCodedNonBinaryTree()
        {
            Tree<int> tree = new Tree<int>(7,
                                    new Tree<int>(19,
                                        new Tree<int>(1),
                                        new Tree<int>(12),
                                        new Tree<int>(31)),
                                    new Tree<int>(21),
                                    new Tree<int>(14,
                                        new Tree<int>(23),
                                        new Tree<int>(6)));

            Console.WriteLine("--------------BFS traverse--------------");
            Console.WriteLine();

            Queue<Node<int>> nodes = tree.BFSTraverse(tree.Root);

            PrintCollection(nodes.Select(n => n.Value));

            Console.WriteLine();
            Console.WriteLine("--------------DFS traverse--------------");
            Console.WriteLine();

            tree.PrintDFSTraverse(tree.Root, "  ");

            Console.WriteLine();
            Console.WriteLine("--------------DFS traverse with stack--------------");
            Console.WriteLine();

            Stack<Node<int>> moreNodes = tree.DFSTraverseWithStack(tree.Root);

            PrintCollection(moreNodes.Select(n => n.Value));
        }

        /// <summary>
        /// Prints collection of elements
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="collection">Collection of elements</param>
        private static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Creates a phonebook HashTable. It is Hard coded for easier testing
        /// </summary>
        private static void HardCodedHashTable()
        {
            CustomHashTable<string, string> phoneBook = new CustomHashTable<string, string>();

            // It is 17 in order to check if the phonebook resizes itself after reaching its initial lenght
            const int loopTo = 17;

            string tableKey = "Ivan{0}";
            string tableValue = "0885{0}";

            for (int i = 0; i < loopTo; i++)
            {
                AddElementToTheHashTable(string.Format(tableKey, i), string.Format(tableValue, i), phoneBook);

                Console.WriteLine($"Added: {string.Format(tableKey, i)} - {string.Format(tableValue, i)}");

                // Checks if the phonebook resized itself after adding the 17th element
                if (i == loopTo - 1)
                {
                    Console.WriteLine(phoneBook.Size);
                }
            }

            var searchedItem = phoneBook.Search("Ivan5");

            Console.WriteLine(searchedItem.Key + " - " + searchedItem.Value);

            phoneBook.Remove(new KeyValuePair<string, string>("Ivan5", "12345"));

            // Checks if the phonebook resized itself after removing the 17th element
            Console.WriteLine(phoneBook.Size);

            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    if (input == "Add" || input == "Remove")
                    {
                        Console.WriteLine("Enter key value pair separated by space:");
                        string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        if (tokens.Length != 2)
                        {
                            throw new InvalidOperationException("Invalid arguments count. Arguments passe count should be 2");
                        }

                        if (input == "Add")
                        {
                            AddElementToTheHashTable(tokens[0], tokens[1], phoneBook);
                        }
                        else
                        {
                            RemoveElementsFromTheHashTable(tokens[0], tokens[1], phoneBook);

                            Console.WriteLine("Element removed successfully");
                        }
                    }
                    else if (input == "Search")
                    {
                        Console.WriteLine("Enter key to be found:");
                        string key = Console.ReadLine();

                        if (key.Contains(" "))
                        {
                            throw new InvalidOperationException("Cannot search more than one argument at a time");
                        }

                        var result = phoneBook.Search(key);

                        Console.WriteLine(result);
                    }
                    else if (input == "end")
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void AddElementToTheHashTable(string key, string value, CustomHashTable<string, string> phoneBook)
        {
            phoneBook.Add(key, value);
        }

        private static void RemoveElementsFromTheHashTable(string key, string value, CustomHashTable<string, string> phoneBook)
        {
            phoneBook.Remove(new KeyValuePair<string, string>(key, value));
        }

        private static void CreateATree()
        {
            BinaryTree tree = new BinaryTree();
            Node node = null;
            Random rnd = new Random();

            int size = int.Parse(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                node = tree.InsertNode(rnd.Next(1000), node);
            }

            tree.TraverseDFS(node, "    ");

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int itemToSearch))
                    {
                        break;
                    }

                    int pointAtWhichTheItemWasFound = tree.SearchByValue(itemToSearch, node);

                    Console.WriteLine(pointAtWhichTheItemWasFound);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
