using System;
using MyPost;
using MyGuestbook;

class Program
{
    static void Main()
    {
         Guestbook guestbook = new Guestbook();
        const string fileName = "guestbook.json";

        // Ladda inlägg från fil om filen finns
        guestbook.LoadFromFile(fileName);

        Console.WriteLine("Cecilias gästbok");

        while (true)
        {
            // Visa menyn
            Console.WriteLine("\n1. Skriv i gästboken");
            Console.WriteLine("2. Ta bort inlägg");
            Console.WriteLine("3. Visa alla inlägg i gästboken");

            // MELLANRUM
            Console.WriteLine();

            Console.WriteLine("X. Avsluta");

            // MELLANRUM
            Console.WriteLine();

            Console.Write("Vad vill du göra?: ");
            string choice = Console.ReadLine()?.ToUpper() ?? string.Empty;


            switch (choice.ToUpper())
            {
                case "1":
                    while (true)
                    {
                        Console.Write("Ditt namn: ");
                        string authorName = Console.ReadLine() ?? string.Empty;

                        // Kolla om authorName är ogiltigt
                        if (string.IsNullOrEmpty(authorName))
                        {
                            Console.WriteLine("Du måste ange ett namn. Försök igen.");
                            // Fortsätt loopa för att börja om med författaren
                            continue;
                        }

                        Console.Write("Inlägget: ");
                       string content = Console.ReadLine() ?? string.Empty;

                        // Kolla efter ogiltigt värde innan inlägget läggs till
                        if (!string.IsNullOrEmpty(content))
                        {
                            // Skapa en ny post och lägg till i gästboken
                            guestbook.AddPost(new Post(authorName, content ?? string.Empty));

                            break; // Bryt ut ur loopen om inlägget är giltigt
                        }
                        else
                        {
                            Console.WriteLine("Du måste skriva ett innehåll till inlägget. Försök igen.");
                        }
                    }
                    break;

                case "2":
                    // Visa inlägg i gästboken
                    Console.WriteLine("Inlägg i gästboken:");
                    guestbook.ShowAllPosts();

                    // Välj inlägg att ta bort
                    Console.Write("\nVälj inlägg att ta bort (ange nummer på inlägget): ");
                    if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < guestbook.Posts.Count)
                    {
                        // Ta bort inlägget
                        guestbook.RemovePost(guestbook.Posts[index]);
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt index.");
                    }
                    break;

                case "3":
                    // Visa inlägg i gästboken
                    Console.WriteLine("Inlägg i gästboken:");
                    guestbook.ShowAllPosts();
                    break;

                case "X":
                    // Avsluta programmet
                  guestbook.SaveToFile(fileName);
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }
}
