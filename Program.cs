using System;
using System.IO;
using System.Text;

namespace HOMEWORK
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;
            //ask user - ticketID, Summary, Status, Priority, Submitter, Assigned, Watching
            // EX Ticket: 1,bug ticket, open, high, Drew, Jane, Drew|John|bill

            do {
                Console.WriteLine("1.) Read data from a file\n2.) Create a file from data\n3.) Exit");
                choice = Console.ReadLine();

                if (choice == "1") {
                    
                    if(File.Exists(file)) {
                        StreamReader sr = new StreamReader(file);

                        while (!sr.EndOfStream) {
                            string line = sr.ReadLine();
                            string[] array = line.Split(',');
                            
                            Console.WriteLine("Ticket ID: {0}, Ticket Summary: {1}, Ticket Status: {2}, Ticket Priority: {3}, Ticket Submitter: {4}, Ticket Assigner: {5}, Ticket Watcher: {6}", array[0], array[1], array[2], array[3], array[4], array[5], array[6]);
                            
                        }
                        sr.Close();
                    } else {
                        Console.WriteLine("File does not exist");
                    }

                } else if (choice == "2") {
                    StreamWriter sw = new StreamWriter(file);

                    for (int i = 0; i < 10; i++) {

                        Console.WriteLine("Do you want to create a ticket? (y or n) ");
                        string response = Console.ReadLine().ToUpper();
                        if (response != "Y"){
                            break;
                        }

                        Console.WriteLine("Enter ticket ID");
                        int ticketID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter ticket summary");
                        string ticketSummary = Console.ReadLine();

                        Console.WriteLine("Enter ticket status");
                        string ticketStatus = Console.ReadLine();

                        Console.WriteLine("Enter ticket priority");
                        string ticketPriority = Console.ReadLine();
                        
                        Console.WriteLine("Enter ticket submitter");
                        string ticketSubmitter = Console.ReadLine();

                        Console.WriteLine("Enter who is assigned for this ticket");
                        string ticketAssigned = Console.ReadLine();

                        string ticketWatched;
                        int totalTicketWatched = 0;
                        
                        Console.WriteLine("How many people are watching this ticket");
                        totalTicketWatched = Convert.ToInt32(Console.ReadLine());

                        StringBuilder sb = new StringBuilder();
                        if (totalTicketWatched != 0) {

                            for (int j = 0; j < totalTicketWatched; j++) {
                                Console.WriteLine("Who is watching this ticket");
                                ticketWatched = Console.ReadLine();
                            }
                        }

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketID, ticketSummary, ticketStatus, ticketPriority, ticketSubmitter, ticketAssigned, ticketWatched);
                    }

                    sw.Close();
                }
            }while (choice == "1" || choice == "2");

        }
    }
}
