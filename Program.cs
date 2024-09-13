namespace Coffee_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string correctUsername = "Uviwe";
            string correctPassword = "12345";
            int attempts = 0;
            bool Authorised = false;


            while (attempts < 3 && !Authorised)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (username == correctUsername && password == correctPassword)
                {
                    Authorised = true;
                }
                //else if (username != correctUsername )
                //{
                //    Console.WriteLine(" Username is not correct. Try again");
                //}
                //else if ( password != correctPassword)
                //{
                //    Console.WriteLine(" Password is not correct. Try again");
                //}

                attempts++;
                Console.WriteLine($"Credentials are not correct!. Attempts left: {3 - attempts}");
               
                //else {
                //    Console.WriteLine(" Credentials are not correct!"); attempts ++; 
                //    //break;
                //}
            }

            if (!Authorised)
            {
                Console.WriteLine("You have been logged out.");
                return;
            }

            List<string> previousOrders = new List<string>();
            double ordersTotalCost = 0.0;
            bool RunningApp = true;

            while (RunningApp)
            {
                Console.WriteLine("1. Order Coffee");
                Console.WriteLine("2. View Previous Orders");
                Console.WriteLine("3. Logout");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    bool CreateOrder = true;
                    double totalCost = 0.0;


                    while (CreateOrder)
                    {
                        Console.WriteLine("Select coffee type:");
                        Console.WriteLine("1. Espresso - R25.00");
                        Console.WriteLine("2. Latte - R35.00");
                        Console.WriteLine("3. Cappuccino - R40.00");
                        Console.Write("Choose an option: ");
                        string coffeeOption = Console.ReadLine();

                        double basePrice = 0.0;
                        string coffeeType = "";

                        if (coffeeOption == "1")
                        {
                            basePrice = 25.00;
                            coffeeType = "Espresso";
                        }
                        else if (coffeeOption == "2")
                        {
                            basePrice = 35.00;
                            coffeeType = "Latte";
                        }
                        else if (coffeeOption == "3")
                        {
                            basePrice = 40.00;
                            coffeeType = "Cappuccino";
                        }

                        Console.WriteLine("Select size:");
                        Console.WriteLine("1. Small");
                        Console.WriteLine("2. Medium (+R5.00)");
                        Console.WriteLine("3. Large (+R10.00)");
                        Console.Write("Choose an option: ");
                        string sizeOption = Console.ReadLine();

                        double sizeCost = 0.0;
                        string size = "";

                        if (sizeOption == "1")
                        {
                            size = "Small";
                        }
                        else if (sizeOption == "2")
                        {
                            sizeCost = 5.00;
                            size = "Medium";
                        }
                        else if (sizeOption == "3")
                        {
                            sizeCost = 10.00;
                            size = "Large";
                        }

                        double coffeeCost = basePrice + sizeCost;
                        totalCost += coffeeCost;
                        ordersTotalCost += coffeeCost;
                        previousOrders.Add($"{size} {coffeeType} - R{coffeeCost:F2}");

                        Console.Write("Do you want to order another coffee? (yes/no): ");
                        string anotherCoffee = Console.ReadLine().ToLower();

                        if (anotherCoffee != "yes")
                        {
                            CreateOrder = false;
                            Console.WriteLine($"Total cost: R{totalCost:F2}");
                        }
                    }
                }
                else if (option == "2")
                {
                    if (previousOrders.Count == 0)
                    {
                        Console.WriteLine("No previous orders.");
                    }
                    else
                    {
                        Console.WriteLine("Previous Orders:");
                        foreach (string order in previousOrders)
                        {
                            Console.WriteLine(order);
                        }
                        Console.WriteLine($" Total cost of orders: R{ordersTotalCost:F2}");
                    }
                }
                else if (option == "3")
                {
                    RunningApp = false;
                    Console.WriteLine("You have been logged out.");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}

    
