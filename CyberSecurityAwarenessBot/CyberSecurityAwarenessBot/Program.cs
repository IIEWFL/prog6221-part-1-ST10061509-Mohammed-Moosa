using System;
using System.Media;
using System.Threading;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Set the console title and enable Unicode characters
        Console.Title = "Cybersecurity Awareness Assistant";
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Play voice greeting from a WAV file
        SoundPlayer player = new SoundPlayer("Assets/greeting.wav");
        player.PlaySync();

        // Display ASCII art inside a red bordered box
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        string asciiArt = File.ReadAllText("Assets/ascii_art.txt");
        PrintBorderedBox(asciiArt);
        Console.ResetColor();

        // Ask for the user's name
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nWhat's your name? ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string name = Console.ReadLine();
        Console.ResetColor();

        // Display personalized welcome message with border and typing effect
        Console.ForegroundColor = ConsoleColor.DarkRed;
        TypeBorderedMessage($"\nWelcome, {name}! I'm your Cybersecurity Awareness Assistant.");
        Console.ResetColor();

        // Main chatbot loop
        while (true)
        {
            // Prompt user for a question
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nAsk me a question: ");
            Console.ForegroundColor = ConsoleColor.Green; // User input color
            string input = Console.ReadLine().ToLower();
            Console.ResetColor();

            // Handle empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                TypeBorderedMessage("Please type something!");
                continue;
            }

            // Respond to specific keywords with typing effect and bordered messages
            if (input.Contains("how are you"))
            {
                TypeBorderedMessage("I'm secure and ready to assist!");
            }
            else if (input.Contains("purpose"))
            {
                TypeBorderedMessage("I help you learn how to stay safe online.");
            }
            else if (input.Contains("what can i ask you about"))
            {
                TypeBorderedMessage("I can provide information on passwords, phishing, safe browsing, online scams, and general digital safety.");
            }
            else if (input.Contains("password"))
            {
                TypeBorderedMessage("Strong password tip: Use a mix of uppercase, lowercase, numbers, and special characters.");
                TypeBorderedMessage("Avoid reusing the same password across multiple platforms.");
                TypeBorderedMessage("Consider using a password manager to safely store your credentials.");
            }
            else if (input.Contains("phishing"))
            {
                TypeBorderedMessage("Phishing tip: Never click on suspicious links or open unknown email attachments.");
                TypeBorderedMessage("Verify the sender's email address before responding.");
                TypeBorderedMessage("When in doubt, go directly to the official website rather than clicking a link.");
            }
            else if (input.Contains("browsing"))
            {
                TypeBorderedMessage("Browsing tip: Always check for HTTPS in the URL before entering sensitive information.");
                TypeBorderedMessage("Use a secure and up-to-date browser.");
                TypeBorderedMessage("Avoid downloading files from unknown or untrusted websites.");
            }
            else if (input.Contains("scam") || input.Contains("scams") || input.Contains("fraud"))
            {
                TypeBorderedMessage("Online scams are everywhere. Stay alert!");
                TypeBorderedMessage("Never share your personal info unless you're sure who you're talking to.");
                TypeBorderedMessage("If it sounds too good to be true, it probably is.");
            }
            else if (input.Contains("safe") && input.Contains("online"))
            {
                TypeBorderedMessage("General safety tip: Keep your software updated and enable two-factor authentication wherever possible.");
            }
            else
            {
                TypeBorderedMessage("I didn’t quite understand that. Could you rephrase or ask about passwords, phishing, browsing, or scams?");
            }

        }
    }

    // Displays ASCII art or large text inside a decorative border
    static void PrintBorderedBox(string content)
    {
        string[] lines = content.Trim().Split('\n');
        int maxLength = 0;
        foreach (var line in lines)
        {
            int length = line.TrimEnd().Length;
            if (length > maxLength) maxLength = length;
        }

        // Top border
        string border = new string('═', maxLength + 4);
        Console.WriteLine($"╔{border}╗");

        // Each line padded and wrapped with side borders
        foreach (var line in lines)
        {
            string paddedLine = line.PadRight(maxLength);
            Console.WriteLine($"║  {paddedLine}  ║");
        }

        // Bottom border
        Console.WriteLine($"╚{border}╝");
    }

    // Simulates typing effect for any message
    static void TypeWrite(string message, int delay = 30)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay); // Delay between each character
        }
        Console.WriteLine();
    }

    // Displays a message inside a border with typing effect
    static void TypeBorderedMessage(string message)
    {
        string border = new string('═', message.Length + 4);
        Console.ForegroundColor = ConsoleColor.Magenta;

        // Top border
        Console.WriteLine($"╔{border}╗");

        // Message with typing effect inside side borders
        Console.Write("║  ");
        Console.ForegroundColor = ConsoleColor.Gray; // Bot message color
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  ║");

        // Bottom border
        Console.WriteLine($"╚{border}╝");
        Console.ResetColor();
    }
}
