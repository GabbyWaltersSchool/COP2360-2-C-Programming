using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Creates a dictionary to store the keys and their associated list of values
        Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();
        bool keepRunning = true;

        // Main loop to display menu and process the user's choices
        while (keepRunning)
        {
            // Display menu options to the user
            Console.WriteLine("Choose an option:");
            Console.WriteLine("a. Populate the Dictionary");
            Console.WriteLine("b. Display Dictionary Contents");
            Console.WriteLine("c. Remove a Key");
            Console.WriteLine("d. Add a New Key and Value");
            Console.WriteLine("e. Add a Value to an Existing Key");
            Console.WriteLine("f. Sort the Keys");
            Console.WriteLine("g. Exit");

            // Read and process user input
            char choice;
            if (char.TryParse(Console.ReadLine()?.ToLower(), out choice))
            {
                Console.WriteLine($"You chose: {choice}"); // Debugging output
                
                // Performs action based on user choice
                switch (choice)
                {
                    case 'a':
                        PopulateDictionary(myDictionary);
                        break;
                    case 'b':
                        DisplayDictionaryContents(myDictionary);
                        break;
                    case 'c':
                        RemoveKey(myDictionary);
                        break;
                    case 'd':
                        AddNewKeyAndValue(myDictionary);
                        break;
                    case 'e':
                        AddValueToExistingKey(myDictionary);
                        break;
                    case 'f':
                        SortKeys(myDictionary);
                        break;
                    case 'g':
                        keepRunning = false;
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
            }
        }
    }

    // Populates the dictionary with predefined values
    static void PopulateDictionary(Dictionary<string, List<string>> dict)
    {
        Console.WriteLine("Entering PopulateDictionary method...");
        dict["Apple"] = new List<string> { "Red", "Green" };
        dict["Banana"] = new List<string> { "Yellow", "Green" };
        dict["Cherry"] = new List<string> { "Magenta" };
        Console.WriteLine("Dictionary populated.");
    }

    // Displays the contents of the dictionary
    static void DisplayDictionaryContents(Dictionary<string, List<string>> dict)
    {
        Console.WriteLine("Displaying dictionary contents...");
        foreach (var item in dict)
        {
            // Prints each key and the associated values
            Console.WriteLine($"Key: {item.Key}, Values: {string.Join(", ", item.Value)}");
        }
    }
    // Removes a key from the dictionary
    static void RemoveKey(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter the key to remove: ");
        string key = Console.ReadLine();
        if (dict.ContainsKey(key))
        {
            dict.Remove(key);
            Console.WriteLine($"Key '{key}' removed.");
        }
        else
        {
            Console.WriteLine($"Key '{key}' not found.");
        }
    }
    // Adds a new key and value to the dictionary
    static void AddNewKeyAndValue(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter the new key: ");
        string key = Console.ReadLine();
        Console.Write("Enter the value: ");
        string value = Console.ReadLine();

        if (!dict.ContainsKey(key))
        {
            dict[key] = new List<string> { value };
            Console.WriteLine($"Added key '{key}' with value '{value}'.");
        }
        else
        {
            Console.WriteLine($"Key '{key}' already exists. Use option 'e' to add a value to an existing key.");
        }
    }
    // Adds a value to an existing key in the dictionary
    static void AddValueToExistingKey(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter the key: ");
        string key = Console.ReadLine();
        if (dict.ContainsKey(key))
        {
            Console.Write("Enter the value to add: ");
            string value = Console.ReadLine();
            dict[key].Add(value);
            Console.WriteLine($"Added value '{value}' to key '{key}'.");
        }
        else
        {
            Console.WriteLine($"Key '{key}' not found.");
        }
    }
    // Sorts the dictionary by its keys and display the sorted dictionary
    static void SortKeys(Dictionary<string, List<string>> dict)
    {
        Console.WriteLine("Sorting the keys...");
        var sortedDict = dict.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        Console.WriteLine("Keys sorted:");
        foreach (var item in sortedDict)
        {
            // Print each key and its associated values in sorted order
            Console.WriteLine($"Key: {item.Key}, Values: {string.Join(", ", item.Value)}");
        }
    }
}
