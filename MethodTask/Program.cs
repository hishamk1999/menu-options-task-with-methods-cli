namespace MethodTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>();
            string userInput;

            do
            {
                DisplayMenu();
                Console.Write("Enter your choice: ");
                userInput = Console.ReadLine();
                HandlUserInput(collection:collection,input:userInput);

            }
            while (userInput != "q" && userInput != "Q");
        }
        static void DisplayMenu()
        {
            Console.WriteLine(
                "P - Print numbers\n" +
                "A - Add a number\n" +
                "M - Display mean of the numbers\n" +
                "S - Display the smallest number\n" +
                "L - Display the largest number\n" +
                "S1 - Sort ASC 'ascending'\n" +
                "S2 - Sort DESC 'descending'\n" +
                "F - Find an index of a number\n" +
                "E - Empty the list\n" +
                "Q - Quit"
                );
        }

        static void HandlUserInput(string input, List<int> collection)
        {
            switch (input)
            {
                case "p": case "P": PrintNumbers(collection); break;
                case "a": case "A": AddNumber(collection); break;
                case "m": case "M": DisplayMean(collection); break;
                case "s": case "S": DisplaySmallestNumber(collection); break;
                case "l": case "L": DisplayLargestNumber(collection); break;
                case "s1": case "S1": SortAscending(collection); break;
                case "s2": case "S2": SortDescending(collection); break;
                case "f": case "F": FindIndex(collection); break;
                case "e": case "E": EmptyList(collection); break;
                case "q": case "Q": Console.WriteLine("\nGoodbye\n"); break;
                default: Console.WriteLine("\nInvalid input\n"); break;
            }
        }

        static void PrintNumbers(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("\n[] - the list is empty\n");
                return;
            }
            Console.Write("\n[");
            for (int i = 0; i < collection.Count; i++)
            {
                Console.Write($" {collection[i]}");
            }
            Console.WriteLine(" ]\n");
        }

        static void AddNumber(List<int> collection)
        {
            int number;
            bool exists = false;

            Console.Write("Enter a number: ");
            number = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] == number)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
                Console.WriteLine($"\nThe number {number} already exists in the list. Duplicate entries are not allowed.\n");
            else
            {
                collection.Add(number);
                Console.WriteLine($"\n{number} added\n");
            }
        }

        static void DisplayMean(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("\nUnable to calculate the mean - no data\n");
                return;
            }

            int sum = 0;

            for (int i = 0; i < collection.Count; i++)
                sum += collection[i];

            double average = sum / collection.Count;

            Console.WriteLine($"\nThe average of the elements is: {average}\n");
        }

        static void DisplaySmallestNumber(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("\nUnable to determine the smallest number - list is empty\n");
                return;
            }

            int min = collection[0];

            for (int i = 1; i < collection.Count; i++)
                if (collection[i] < min)
                    min = collection[i];

            Console.WriteLine($"\nThe smallest number is: {min}\n");
        }

        static void DisplayLargestNumber(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("\nUnable to determine the largest number - list is empty\n");
                return;
            }

            int max = collection[0];

            for (int i = 1; i < collection.Count; i++)
            {
                if (collection[i] > max)
                {
                    max = collection[i];
                }
            }

            Console.WriteLine($"\nThe largest number is: {max}\n");
        }

        static void SortAscending(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("\nThe list is empty. Nothing to sort.\n");
                return;
            }

            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = 0; j < collection.Count - i - 1; j++)
                {
                    if (collection[j] > collection[j + 1])
                    {
                        int value = collection[j];
                        collection[j] = collection[j + 1];
                        collection[j + 1] = value;
                    }
                }
            }
            Console.WriteLine("\nThe list has been sorted in ascending order.\n");
        }

        static void SortDescending(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("\nThe list is empty. Nothing to sort.\n");
                return;
            }

            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = 0; j < collection.Count - i - 1; j++)
                {
                    if (collection[j] < collection[j + 1])
                    {
                        int value = collection[j];
                        collection[j] = collection[j + 1];
                        collection[j + 1] = value;
                    }
                }
            }
            Console.WriteLine("\nThe list has been sorted in descending order.\n");
        }

        static void FindIndex(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("\nUnable to find a number at the list - list is empty [ ]\n");
                return;
            }

            int num;

            Console.Write("Enter the number: ");
            num = Convert.ToInt32(Console.ReadLine());

            int index = -1;

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] == num)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
                Console.WriteLine($"\nFound the number at index: {index}.\n");
            else
                Console.WriteLine($"\nThe number {num} is not in the list.\n");
        }

        static void EmptyList(List<int> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("\nUnable to empty the list - list is alreay empty [ ]\n");
                return;
            }

            collection.Clear();
            Console.WriteLine("\nThe list has been emptied.\n");
        }
    }
}
