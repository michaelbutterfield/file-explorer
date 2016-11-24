using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace programmingAssignment
{
    class Program
    {
        //METHODS
        //-----------------------------------------------------//
        static void PressEnter()
        {
            Console.Write("Please Press Enter to Continue..."); // Display helpful message for user
            Console.ReadLine(); // Wait for response
            Console.Clear(); // Clears and as used at end of code, returns user to main menu with fresh screen

        }
        static void LineBreak() // Simple, easer to understand, looks cleaner and is easily changable
        {
            Console.WriteLine();
        }
        //MAIN PROGRAM
        //-----------------------------------------------------//
        static void Main(string[] args)
        {
            int userResponse; // Contains response to initial question (e.g. 1-5 integer)
            const int one = 1; // Variable used instead of magic numbers
            const int two = 2; // Variable used instead of magic numbers
            const int three = 3; // Variable used instead of magic numbers
            const int four = 4; // Variable used instead of magic numbers
            const int five = 5; // Variable used instead of magic numbers
            const int six = 6;
            string directory = "C:\\Windows"; // Which folder the .exe looks in to retrieve files

            //Beginning of Do loop
            //-----------------------------------------------------//
            do
            {
                Directory.SetCurrentDirectory(directory); // Uses the above string in order to control the directory
                DirectoryInfo folderInfo = new DirectoryInfo(directory); // Which folder it looks for file information in
                FileInfo[] files = folderInfo.GetFiles(); // Puts files found in the folder into an array

                //Introduction
                //-----------------------------------------------------//
                Console.WriteLine("Welcome to the File Lister!");
                LineBreak();

                Console.WriteLine("You are currently displaying files from {0}", folderInfo); // Displays which folders files are being used
                LineBreak();

                Console.WriteLine("Please choose an option from the list below:"); // Present an option
                LineBreak();
                Console.WriteLine("1. Full File Listing");
                Console.WriteLine("2. Filtered File Listing");
                Console.WriteLine("3. Folder Statistics");
                Console.WriteLine("4. File Specific Size");
                Console.WriteLine("5. Change Folder");
                Console.WriteLine("6. Quit");
                LineBreak();
                bool isNumber = int.TryParse(Console.ReadLine(), out userResponse); // Verifies whether the user has given a number or not by trying to parse it
                                                                                    // Output it into the int userResponse
                                                                                    // Bool then gives another level of authentification to the users response

                //Input Verification - Main Menu
                //-----------------------------------------------------//
                while (isNumber == false || userResponse < one || userResponse > six) // When the bool fails (the user doesn't type a number) OR the user types a number below 1 or above 5
                {
                    LineBreak();
                    Console.WriteLine("I'm sorry but that's not accepted"); // While loop rejects the response and loops back around
                    Console.WriteLine("Please only enter the values 1-5 as shown below:"); // Allowing the user to try again
                    LineBreak();
                    Console.WriteLine("1. Full File Listing");
                    Console.WriteLine("2. Filtered File Listing");
                    Console.WriteLine("3. Folder Statistics");
                    Console.WriteLine("4. File Specific Size");
                    Console.WriteLine("5. Change Folder");
                    Console.WriteLine("6. Quit");
                    LineBreak();
                    isNumber = int.TryParse(Console.ReadLine(), out userResponse);// Verifies whether the user has given a number or not by trying to parse it
                                                                                  // Output it into the int userResponse
                                                                                  // Bool then gives another level of authentification to the users response
                    LineBreak();
                }

                //1. FULL FILE LISTING
                //-----------------------------------------------------//
                if (isNumber == true && userResponse == one) // Bool verifies number, if its equal to one
                {
                    LineBreak(); // Leave a line
                    for (int index = 0; index < files.Length; index++) // While index is less than the amount of files in the folder, add one to index
                    {
                        Console.Write("{0}. ", index + 1); // Displays the number next to the file for the user - Index + 1 due to arrays starting at 0
                        Console.WriteLine("{0} <{1}>", files[index].Name, files[index].Length); // While less than index, display files name and how big it is
                    }
                    //User selects specific file
                    //-----------------------------------------------------//
                    LineBreak();
                    Console.WriteLine("Would you like to select a specific file?"); // Helpful message
                    Console.WriteLine("Type the number next to the file.");         // Helpful message
                    Console.WriteLine("Alternatively, you can type 0 to skip");     // Helpful message
                    LineBreak();        // Method - Blank line
                    int numberResponse; // Create a new variable to hold user response
                    bool isaNumber = int.TryParse(Console.ReadLine(), out numberResponse); // Input verification - Using a new bool as to not interfere with previous menu bool
                    LineBreak();        // Method - Blank line

                    //Validation
                    while (isaNumber == false) // While bool = false - its not a number, therefore can not be related to the files
                    {
                        Console.WriteLine("Sorry, this is invalid, please only enter one of the numbers specified"); // Helpful message as to whats gone wrong
                        LineBreak(); // Method - Blank line
                        isaNumber = int.TryParse(Console.ReadLine(), out numberResponse); // Give the user chance to try the input again
                    }
                    //Skip
                    if (isaNumber == true && numberResponse == 0) // If the response is a number and is equal to 0
                    {
                        Console.Write("You have chosen to skip..."); // Helpul message - they've skipped
                        Console.Write(" Skipping...");               // Skips the rest of code and returns them to main menu
                        LineBreak();
                    }
                    //Display File
                    if (isaNumber == true && numberResponse != 0 && numberResponse <= files.Length) // If the response is true and is not equal to 0 but is within range of the amount of files within the array
                    {
                        numberResponse--; // -1 from the response in order for it to correspond correctly with the array
                        Console.WriteLine("File Name: {0}", files[numberResponse].Name);                // Uses the users response to get the file name from the array
                        Console.WriteLine("Full File Name: {0}", files[numberResponse].FullName);       // Uses the users response to get the file location
                        Console.WriteLine("File Size: {0} bytes", files[numberResponse].Length);        // Uses the users response to get the size of the file
                        Console.WriteLine("Created: {0}", files[numberResponse].CreationTime);          // Uses the users response to get the files creation time
                        Console.WriteLine("Last Accessed: {0}", files[numberResponse].LastAccessTime);  // Uses the users response to get the last access time of the corresponding file

                        LineBreak();

                        Console.WriteLine("Do you want to execute the file? Y/N"); // Helpful message
                        string executeYN = Console.ReadLine().ToUpper();           // Converts text to upper case to keep everything uniform -- user doesn't have to worry about text formatting

                        LineBreak();

                        while (executeYN != "Y" && executeYN != "N")               // Everything that isn't Y or N
                        {
                            Console.WriteLine("I'm sorry that's an invalid response...");           // Invalid response
                            Console.WriteLine("Please only answer Y or N in upper or lower case."); // Helpful message
                            LineBreak();
                            executeYN = Console.ReadLine().ToUpper(); // User retry
                        }
                        if (executeYN == "N") // If no, it continues with the code and returns the user to the main menu
                        {
                            Console.WriteLine("Returning you to the main menu...");
                        }
                        if (executeYN == "Y") // If yes it puts the files full directory path into a string and executes it though system.diagnostic processes
                        {
                            string fileExecute = files[numberResponse].FullName; // Uses the users response to get the file location
                            System.Diagnostics.Process.Start(fileExecute);
                        }

                    }
                    LineBreak();
                    PressEnter(); // Method - Waits for enter, clears and returns to main menu thanks to do-while loop
                }

                //2. FILTERED FILE LISTING
                //-----------------------------------------------------//
                else if (isNumber == true && userResponse == two)      // Bool verifies number, if its equal to two
                {
                    LineBreak();
                    Console.WriteLine("What type of file would you only like to display?"); // Helpful message
                    Console.WriteLine("For example *.exe");            // Formatting help/example
                    LineBreak();
                    string fileExemption = Console.ReadLine();         // Places user response into string
                    LineBreak();

                    files = folderInfo.GetFiles(fileExemption);        // Applies users exception to the files by placing their string response in the brackets

                    for (int index = 0; index < files.Length; index++) // While index is less than the amount of files in the folder, add one to index
                    {
                        Console.Write("{0}. ", index + 1);             // Displays the number next to the file for the user - Index + 1 due to arrays starting at 0
                        Console.WriteLine("{0} <{1}>", files[index].Name, files[index].Length); // While less than index, display files name and how big it is
                    }

                    //User selects specific file
                    //-----------------------------------------------------//
                    LineBreak();
                    Console.WriteLine("Would you like to select a specific file?"); // Helpful message
                    Console.WriteLine("Type the number next to the file.");         // Helpful message
                    Console.WriteLine("Alternatively, you can type 0 to skip");     // Helpful message
                    LineBreak();        // Method - Blank line
                    int numberResponse; // Create a new variable to hold user response
                    bool isaNumber = int.TryParse(Console.ReadLine(), out numberResponse); // Input verification - Using a new bool as to not interfere with previous menu bool
                    LineBreak();        // Method - Blank line

                    //Input Valid
                    while (isaNumber == false) // While bool = false - its not a number, therefore can not be related to the files
                    {
                        Console.WriteLine("Sorry, this is invalid, please only enter one of the numbers specified"); // Helpful message as to whats gone wrong
                        LineBreak();   // Method - Blank line
                        isaNumber = int.TryParse(Console.ReadLine(), out numberResponse); // Give the user chance to try the input again
                    }
                    //Skip
                    if (isaNumber == true && numberResponse == 0)    // If the response is a number and is equal to 0
                    {
                        Console.Write("You have chosen to skip..."); // Helpul message - they've skipped
                        Console.Write(" Skipping...");               // Skips the rest of code and returns them to main menu
                        LineBreak();
                    }
                    if (isaNumber == true && numberResponse != 0 && numberResponse <= files.Length) // If the response is true and is not equal to 0 but is within range of the amount of files within the array
                    {
                        numberResponse--; // -1 from the response in order for it to correspond correctly with the array
                        Console.WriteLine("File Name: {0}", files[numberResponse].Name);               // Uses the users response to get the file name from the array
                        Console.WriteLine("Full File Name: {0}", files[numberResponse].FullName);      // Uses the users response to get the file location
                        Console.WriteLine("File Size: {0} bytes", files[numberResponse].Length);       // Uses the users response to get the size of the file
                        Console.WriteLine("Created: {0}", files[numberResponse].CreationTime);         // Uses the users response to get the files creation time
                        Console.WriteLine("Last Accessed: {0}", files[numberResponse].LastAccessTime); // Uses the users response to get the last access time of the corresponding file

                        LineBreak(); // Formatting

                        //EXECUTING THE FILE
                        //-----------------------------------------------------//
                        Console.WriteLine("Do you want to execute the file? Y/N"); // Extra functionality - if they want to execute the file from the console
                        string executeYN = Console.ReadLine().ToUpper();           // Changes response to upper case to keep everything in uniform -- user doesn't have to worry about formatting of text

                        LineBreak(); // Formatting

                        //Invalid response
                        while (executeYN != "Y" && executeYN != "N") // Anything that isn't Y or N
                        {
                            Console.WriteLine("I'm sorry that's an invalid response...");               // Helpful message
                            Console.WriteLine("Please only answer Y or N in upper or lower case.");     // Helpful message
                            LineBreak();
                            executeYN = Console.ReadLine().ToUpper();                                   // User retry
                        }
                        if (executeYN == "N") // If no continues with the code and returns the user to the main menu
                        {
                            Console.WriteLine("Returning you to the main menu...");
                        }
                        if (executeYN == "Y") // If yes the program puts the file directory into a string and runs it through system.diagnostic processes
                        {
                            string fileExecute = files[numberResponse].FullName; // Uses the users response to get the file location
                            System.Diagnostics.Process.Start(fileExecute);
                        }
                    }


                    files = folderInfo.GetFiles(); // After displaying all files with the exception, resets ready for displaying all files or applying another exception
                    LineBreak();
                    PressEnter();                  // Method - Waits for enter, clears and returns to main menu thanks to do-while loop
                }

                //3. FOLDER STATISTICS
                //-----------------------------------------------------//
                else if (isNumber == true && userResponse == three) // Bool verifies number, if its equal to three
                {
                    //Short scope variables
                    int numberofFiles = 0;       // Initialise to 0 for the folder to write the data in
                    double totalSize = 0;        // Initialise to 0 for the folder to write the data in
                    string largestFileName = ""; // Initialise to nothing for the folder to write the data in
                    double largestFileSize = 0;  // Initialise to 0 for the folder to write the data in

                    LineBreak();
                    for (int index = 0; index < files.Length; index++) // While index is less than the amount of files in the folder, add one to index
                    {
                        numberofFiles = index + 1;                   // Number of files within the folder will always be the same as the array +1 due to the array starting at 0
                        totalSize = totalSize + files[index].Length; // Every new file found is added on to the already existing total, creating the total size
                        if (files[index].Length > largestFileSize)   // If a file already found is bigger than the largest file already found, overwrite it
                        {
                            largestFileSize = files[index].Length;   // Overwrite the files size
                            largestFileName = files[index].Name;     // Overwrite the files name as well to be displayed
                        }
                    }

                    Console.WriteLine("Files in: {0}", folderInfo);  // Display all the information catalogued above
                    Console.WriteLine("Total files: {0}", numberofFiles);
                    Console.WriteLine("Total size of all files in the folder: <{0}>", totalSize);
                    Console.WriteLine("Largest file in the folder: {0} <{1}>", largestFileName, largestFileSize);
                    Console.WriteLine("Average size of all files in the folder: <{0}>", totalSize / numberofFiles);

                    LineBreak(); // Aesthetics
                    PressEnter();
                }

                //4. FILE SPECIFIC SIZE
                //-----------------------------------------------------//

                else if (isNumber == true && userResponse == four) // Bool verifies number, if its equal to four
                {
                    LineBreak(); // Aesthetics
                    Console.WriteLine("Type a number, the program will then display all files 1MB bigger and smaller than that number."); // Helpful message
                    Console.WriteLine("Please type a size");    // Helpful message
                    Console.WriteLine("HINT: a MB is 1000000"); // Hint used in order to give user a clue as to how big a MB is
                    LineBreak();                                // Aesthetics
                    int filesizeNumber;                         // Place user response in int
                    bool isitaNumber = int.TryParse(Console.ReadLine(), out filesizeNumber); // Input Verification
                    LineBreak();

                    int filesizenumberMax = filesizeNumber + 1000000;   // User number then added to by 1MB to create a boundary to compare the files against
                    int filesizenumberMin = filesizeNumber - 1000000;   // User number then subtracted by 1MB to create a boundary to compare the files against

                    //Verification
                    while (isitaNumber == false)                         // Again, input verification, if its not a number, error and allow them to retry
                    {
                        Console.WriteLine("I'm sorry, this is invalid, please try again within the range stated above."); // Helpful message
                        isitaNumber = int.TryParse(Console.ReadLine(), out filesizeNumber); // Retry
                    }
                    for (int index = 0; index < files.Length; index++) // While index is less than the amount of files in the folder, add one to index
                    {
                        if (files[index].Length > filesizenumberMin && files[index].Length < filesizenumberMax) // Comparing the files to the boundaries -- If the file is bigger than the minimum AND smaller than the maximum, display it
                        {
                            Console.Write("{0}. ", index + 1); // Displays the number next to the file for the user - Index + 1 due to arrays starting at 0
                            Console.WriteLine("{0} <{1}>", files[index].Name, files[index].Length); // While less than index, display files name and how big it is
                        }
                    }

                    LineBreak();
                    Console.WriteLine("Would you like to select a specific file?"); // Helpful message
                    Console.WriteLine("Type the number next to the file.");         // Helpful message
                    Console.WriteLine("Alternatively, you can type 0 to skip");     // Helpful message
                    LineBreak();        // Method - Blank line
                    int numberResponse; // Create a new variable to hold user response
                    bool isaNumber = int.TryParse(Console.ReadLine(), out numberResponse); // Input verification - Using a new bool as to not interfere with previous menu bool
                    LineBreak();        // Method - Blank line

                    //Input Valid
                    while (isaNumber == false) // While bool = false - its not a number, therefore can not be related to the files
                    {
                        Console.WriteLine("Sorry, this is invalid, please only enter one of the numbers specified"); // Helpful message as to whats gone wrong
                        LineBreak();   // Method - Blank line
                        isaNumber = int.TryParse(Console.ReadLine(), out numberResponse); // Give the user chance to try the input again
                    }
                    //Skip
                    if (isaNumber == true && numberResponse == 0)    // If the response is a number and is equal to 0
                    {
                        Console.Write("You have chosen to skip..."); // Helpul message - they've skipped
                        Console.Write(" Skipping...");               // Skips the rest of code and returns them to main menu
                        PressEnter();
                    }
                    if (isaNumber == true && numberResponse != 0 && numberResponse <= files.Length) // If the response is true and is not equal to 0 but is within range of the amount of files within the array
                    {
                        numberResponse--; // -1 from the response in order for it to correspond correctly with the array
                        Console.WriteLine("File Name: {0}", files[numberResponse].Name);               // Uses the users response to get the file name from the array
                        Console.WriteLine("Full File Name: {0}", files[numberResponse].FullName);      // Uses the users response to get the file location
                        Console.WriteLine("File Size: {0} bytes", files[numberResponse].Length);       // Uses the users response to get the size of the file
                        Console.WriteLine("Created: {0}", files[numberResponse].CreationTime);         // Uses the users response to get the files creation time
                        Console.WriteLine("Last Accessed: {0}", files[numberResponse].LastAccessTime); // Uses the users response to get the last access time of the corresponding file

                        LineBreak(); // Formatting

                        //EXECUTING THE FILE
                        //-----------------------------------------------------//
                        Console.WriteLine("Do you want to execute the file? Y/N"); // Extra functionality - if they want to execute the file from the console
                        string executeYN = Console.ReadLine().ToUpper();           // Changes response to upper case to keep everything in uniform -- user doesn't have to worry about formatting of text

                        LineBreak(); // Formatting

                        //Invalid response
                        while (executeYN != "Y" && executeYN != "N") // Anything that isn't Y or N
                        {
                            Console.WriteLine("I'm sorry that's an invalid response...");               // Helpful message
                            Console.WriteLine("Please only answer Y or N in upper or lower case.");     // Helpful message
                            LineBreak();
                            executeYN = Console.ReadLine().ToUpper();                                   // User retry
                        }
                        if (executeYN == "N") // If no continues with the code and returns the user to the main menu
                        {
                            Console.WriteLine("Returning you to the main menu...");
                        }
                        if (executeYN == "Y") // If yes the program puts the file directory into a string and runs it through system.diagnostic processes
                        {
                            string fileExecute = files[numberResponse].FullName; // Uses the users response to get the file location
                            System.Diagnostics.Process.Start(fileExecute);
                        }


                        LineBreak();    // Padding
                        PressEnter();   // Return the user back to the main menu
                    }
                }

                //5. FOLDER CHOICE
                //-----------------------------------------------------//
                else if (isNumber == true && userResponse == five) // Bool verifies number, if its equal to five
                {
                    LineBreak();
                    Console.WriteLine("Which folder would you like to display files from?");                // Helpful question to guide user
                    Console.WriteLine("Please write it in the format: C:\\Windows - with two backslashes"); // Helpful formatting question to guide user
                    LineBreak();
                    try
                    {
                        directory = Console.ReadLine().ToUpper(); // Changes all text to upper case - personal preference
                    }
                    catch (DirectoryNotFoundException dirEx)
                    {
                        directory = "C:\\Windows";
                        LineBreak();
                        Console.WriteLine("Sorry, directory not found");
                        Console.WriteLine("Reverting dircetory back to default");
                        Console.WriteLine(dirEx.Message);
                        LineBreak();
                        PressEnter();
                    }
                    LineBreak();
                    PressEnter();
                } 
            } while (userResponse != six); // If six is entered, program ends.
            {
                return;
            }
        }
    }
}

