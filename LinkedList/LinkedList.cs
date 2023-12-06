using System;
using System.Windows.Forms;
using LinkedListVisualizer;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    public partial class LinkedListForm : Form
    {
        public LinkedListForm()
        {
            try
            {
                ModifyRegistryKey();
            }
            catch (Exception ex)
            {
                // Handle or log the exception appropriately
                Console.WriteLine($"Exception: {ex.Message}");
            }

            InitializeComponent();

            // Attach event handlers
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            button6.Click += Button6_Click;
        }


        /* Linked List Examples        

    1. Create a Linked List of strings
   LinkedList<string> sentence = new LinkedList<string>();

    2. Create a Linked List from an array of strings
   string[] words =
       { "the", "red", "car", "speeds", "away" };
   LinkedList<string> sentence = new LinkedList<string>(words);

    3. Add new strings to the end of the Linked List
   sentence.AddLast("word");

    4. Add the word 'today' to the beginning of the linked list.
   sentence.AddFirst("today");

    5. Move the first node to be the last node.
   LinkedListNode<string> firstNode = sentence.First;
   sentence.RemoveFirst();
   sentence.AddLast(firstNode);

    6. Change the last node to 'yesterday'
   sentence.RemoveLast();
   sentence.AddLast("yesterday");

    7. Move the last node to be the first node.
   LinkedListNode<string> lastNode = sentence.Last;
   sentence.RemoveLast();
   sentence.AddFirst(lastNode);

    8. Find the last occurence of 'the'.
   LinkedListNode<string> target = sentence.FindLast("the");
   if (target == null)
   {
       // "the" is not found
   }
   else
   {
       // Add 'bright' and 'red' after 'the' (the LinkedListNode named target).
       sentence.AddAfter(target, "bright");
       sentence.AddAfter(target, "red");
   }

    9. Find the 'car' node
   LinkedListNode<string> target = sentence.Find("car");

    10. Add 'sporty' and 'red' before 'car':
   sentence.AddBefore(target, "sporty");
   sentence.AddBefore(target, "red");

    11. Keep a reference to the 'car' node
    and to the previous node in the list
   carNode = sentence.Find("car");
   LinkedListNode<string> current = carNode.Previous;

    12. The AddBefore method throws an InvalidOperationException
    if you try to add a node that already belongs to a list.
    try
    {
       // try to add carNode before current
       sentence.AddBefore(current, carNode);
    }
    catch (InvalidOperationException ex)
    {
       Console.WriteLine("Exception message: {0}", ex.Message);
    }


    13. Remove the node referred to by carNode, and then add it
    before the node referred to by current.
    sentence.Remove(carNode);
    sentence.AddBefore(current, carNode);


    14. Add the 'current' node after the node referred to by mark2
    sentence.AddAfter(mark2, current);

    15. The Remove method finds and removes the
    first node that that has the specified value.
     sentence.Remove("red");

    16. Create an array with the same number of
    elements as the linked list.
    string[] sArray = new string[sentence.Count];
    sentence.CopyTo(sArray, 0);

    17. Walk through a Linked List in forward order
    LinkedListNode<object> linkedListNode = linkedList.First;

    while( linkedListNode != null )
    {
       linkedListNode = linkedListNode.Next;
    }

    18. Walk through a Linked List in reverse order
    LinkedListNode<object> linkedListNode = linkedList.Last;

     while( linkedListNode != null )
     {
       linkedListNode = linkedListNode.Previous;
    }

    19. Change the Value of a node
    linkedListNode.Value = "new value";

    20. Release all the nodes.
    sentence.Clear();

    */


        private void ModifyRegistryKey()
        {
            try
            {
                // Modify the registry key related to Internet Explorer emulation
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);

                if (key != null)
                {
                    string executableName = System.IO.Path.GetFileName(Application.ExecutablePath);
                    key.SetValue(executableName, 11001, Microsoft.Win32.RegistryValueKind.DWord);
                    key.Close();
                }
                else
                {
                    Console.WriteLine("Registry key not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception appropriately
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the digits 1 through 10
            LinkedList<object> linkedList = new LinkedList<object>();

            // 2. Your code here to add elements to linkedList
            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddLast(i);
            }

            // 3. then call the visualizer
            VisualizeLinkedList(linkedList);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // 1. using Button1_Click() create a LinkedList which contains the digits 1 through 10
            LinkedList<object> linkedList = new LinkedList<object>();

            // 2. Your code here to add elements to linkedList
            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddLast(i);
            }

            // 3. using example #18, copy the linkedList to reverseLinkedList in reverse order
            // so that reverseLinkedList goes from 10 to 1
            LinkedList<object> reverseLinkedList = new LinkedList<object>(linkedList);

            // 4. Your code here to reverse reverseLinkedList
            reverseLinkedList = new LinkedList<object>(reverseLinkedList.Reverse());

            // 5. then call the visualizer
            VisualizeLinkedList(reverseLinkedList);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the words

            LinkedList<object> linkedList = new LinkedList<object>(new[] { "the", "fox", "jumped", "over", "the", "dog" });



            // 3. add "quick" and "brown" before "fox"
            LinkedListNode<object> foxNode = linkedList.Find("fox");
            linkedList.AddBefore(foxNode, "brown");
            linkedList.AddBefore(foxNode, "quick");


            // 5. using example #8, add "lazy" after the last "the"
            LinkedListNode<object> lastTheNode = linkedList.FindLast("the");
            linkedList.AddAfter(lastTheNode, "lazy");

            // 7. then call the visualizer
            VisualizeLinkedList(linkedList);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the words

            LinkedList<object> linkedList = new LinkedList<object>(new[]
            {
                "Because", "I'm", "sad", "Clap", "along", "if", "you", "feel", "like", "a", "room", "without", "a", "roof",
                "Because", "I'm", "sad", "Clap", "along", "if", "you", "feel", "like", "sadness", "is", "the", "truth", "sad"
            });


            // 3. replace "sad" with "happy" and "sadness with "happiness"
            foreach (LinkedListNode<object> node in linkedList)
            {
                if ((string)node.Value == "sad")
                {
                    node.Value = "happy";
                }
                else if ((string)node.Value == "sadness")
                {
                    node.Value = "happiness";
                }
            }



            // 5. then call the visualizer
            VisualizeLinkedList(linkedList);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the following words
            // The Spain in rain falls plain on the mainly
            LinkedList<object> linkedList = new LinkedList<object>(new[]
            {
                "The", "Spain", "in", "rain", "falls", "plain", "on", "the", "mainly"
            });



            // 3. manipulate the list using Find(), Remove(), AddBefore(), and/or AddAfter()
            // to result in "The rain in Spain falls mainly on the plain"
            LinkedListNode<object> inNode = linkedList.Find("in");
            LinkedListNode<object> plainNode = linkedList.Find("plain");

            linkedList.Remove("The");
            linkedList.Remove("mainly");
            linkedList.AddBefore(inNode, "The");
            linkedList.AddAfter(inNode, "rain");
            linkedList.AddAfter(inNode, "Spain");
            linkedList.AddAfter(plainNode, "on");
            linkedList.AddAfter(plainNode, "the");
            linkedList.AddAfter(plainNode, "plain");


            // 5. then call the visualizer
            VisualizeLinkedList(linkedList);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string[] letters = { "D", "O", "R", "M", "I", "T", "O", "R", "Y" };
            LinkedList<object> anagram = new LinkedList<object>(letters);

            // rearrange the Nodes to spell "DIRTYROOM"
            LinkedListNode<object> rNode = anagram.Find("R");
            LinkedListNode<object> yNode = anagram.Find("Y");

            anagram.Remove("D");
            anagram.Remove("I");
            anagram.Remove("T");
            anagram.Remove("O");

            anagram.AddBefore(rNode, "D");
            anagram.AddAfter(rNode, "I");
            anagram.AddAfter(yNode, "T");
            anagram.AddAfter(yNode, "O");

            // then call the visualizer
            VisualizeLinkedList(anagram);
        }

        private void VisualizeLinkedList(LinkedList<object> linkedList)
        {
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }
    }
}
