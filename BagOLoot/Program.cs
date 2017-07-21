using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChildRegister registry = new ChildRegister();
            Dictionary<string, int> _children  = registry.GetChildren();
            Dictionary<int, string> referenceList = new Dictionary<int, string>();
            var db = new DatabaseInterface();
            db.Check();

            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Add a child");
            Console.WriteLine ("2. Assign toy to a child");
            Console.WriteLine ("3. Revoke toy from child");
            Console.WriteLine ("4. Review child's toy list");
            Console.WriteLine ("5. Child toy delivery complete");
            Console.WriteLine ("6. Yuletime Delivery Report");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            if (choice == 1)
            {
                Console.WriteLine ("Enter child name");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                
                int childId = registry.AddChild(childName);
                Console.WriteLine(childId);
            }
            else if(choice == 2)
            {
                Console.WriteLine ("Assign toy to which child?");
                int i = 1;
                foreach(var child in _children)
                {
                    Console.WriteLine($"{i} {child.Key}");
                    referenceList.Add(i, child.Key);
                    i++;
                }
                Console.Write ("> ");
                int choosenNumber = Int32.Parse(Console.ReadLine());
                Console.WriteLine("");
                var result = _children.FirstOrDefault(x => x.Key == referenceList[choosenNumber]);

                Console.WriteLine($"Enter toy to add to {result.Key}'s Bag o' Loot");
                string toyName = Console.ReadLine();
                SantaHelper addToy = new SantaHelper();
                addToy.AddToyToBag(toyName, result.Value);
            }
            else if (choice == 3)
            {
                
                Dictionary<string, int> kids = new Dictionary<string, int>();
                
                kids = registry.GetChildren();
                Console.WriteLine ("Remove toy from which child?");
                int i = 1;
                foreach(var child in kids)
                {
                    Console.WriteLine($"{i} {child.Key}");
                    referenceList.Add(i, child.Key);
                    i++;
                }
                Console.Write ("> ");
                int choosenNumber = Int32.Parse(Console.ReadLine());
                SantaHelperRemove remove = new SantaHelperRemove();
                var result = _children.FirstOrDefault(y => y.Key == referenceList[choosenNumber]);
                List<string> childsToys = remove.GetChildsToys(result.Value);

                int x = 1;
                foreach (var item in childsToys)
                {
                    Console.WriteLine($"{x++} {item}");
                }
                Console.Write ("> ");
                // Console.WriteLine(childsToys[1]);
                // Console.WriteLine(result.Value);
                int choosenToy = Int32.Parse(Console.ReadLine());
                remove.RemoveToyFromChild(childsToys[choosenToy - 1], result.Value);
            }
            else if (choice == 4)
            {
                Dictionary<string, int> _child = new Dictionary<string, int>();
                _child = registry.GetChildren();
                Console.WriteLine("View Bag o' Loot for which child?");
                int i = 1;
                foreach (var child in _child)
                {
                    Console.WriteLine($"{i} {child.Key}");
                    referenceList.Add(i, child.Key);
                    i++;
                }
                Console.Write ("> ");
                int choosenNumber = Int32.Parse(Console.ReadLine());
                var result = _children.FirstOrDefault(y => y.Key == referenceList[choosenNumber]);
                
                SantaHelperRemove remove = new SantaHelperRemove();
                List<string> childsToys = remove.GetChildsToys(result.Value);

                foreach (var item in childsToys)
                {
                    Console.WriteLine($" {item}");
                }
            }
            else if (choice == 5)
            {
                ReviewWhoIsGettingToy whoGotToy = new ReviewWhoIsGettingToy();
                Dictionary<string, int> kids = new Dictionary<string, int>();
                
                kids = whoGotToy.GetChildrenWithToy();
                Console.WriteLine("Which child had all of their toys delivered?");
                int i = 1;
                foreach(var child in kids)
                {
                    Console.WriteLine($"{i}. {child.Key}");
                    referenceList.Add(i, child.Key);
                    i++;
                }
                Console.Write ("> ");
                int choosenNumber = Int32.Parse(Console.ReadLine());
                var result = kids.FirstOrDefault(y => y.Key == referenceList[choosenNumber]);
                CheckDelivered checkdelivered = new CheckDelivered();
                checkdelivered.IsToyDelivered(result.Value);
    
            }
            else if (choice == 6)
            {
                Console.WriteLine("Yuletime Delivery Report \n%%%%%%%%%%%%%%%%%%%%%%%%");
                ReviewChildsToyList review = new ReviewChildsToyList();
                SantaHelperRemove toyList = new SantaHelperRemove();
                var allChildWithToy = review.GetChildsToyList();
                foreach (var child in allChildWithToy)
                {
                    Console.WriteLine($"{child.Value}");
                    Console.WriteLine(child.Key);
                    List<string> childToys = toyList.GetChildsToys(child.Key);
                    int counter = 1;
                    foreach(var toy in childToys)
                    {
                        Console.WriteLine($"{counter}. {toy}");
                        counter++;
                    }
                }

            }
        }
    }
}
