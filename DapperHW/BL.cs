using System;

namespace DapperHW
{
    class BL
    {
        Data data = new Data();
        private const string head = "Marker\t   Model\t Type\t\n";

        public void GetCase()
        {       
            Console.Clear();
            Console.WriteLine("1 - get all products\n" +
                              "2 - get one product\n" +
                              "3 - back");
                                      
            int action = 0;

                try
                {
                    action = int.Parse(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            var products = data.GetProducts();
                            Console.WriteLine(head);
                            foreach (var product in products)
                            {
                                Print(product);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the product model: ");
                            int model = int.Parse(Console.ReadLine());
                            var one = data.Get(model);
                            if (one != null)
                            {
                                Console.WriteLine(head);
                                Print(one);
                            }
                            else
                            {
                                Console.WriteLine("This item doesn't exist.");
                            }

                            break;
                        case 3:
                            break;
                        default: 
                            break;

                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

        }

        public void CreateCase()
        {
            Console.Clear();

            Console.WriteLine("Enter the product model: ");
            try
            {
                int model = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the product marker: ");
                char marker = char.Parse(Console.ReadLine());
                Console.WriteLine("Enter the product type: ");
                string type = Console.ReadLine();
                data.Create(new Product()
                {
                    Maker = marker,
                    Model = model,
                    Type = type
                });
                Console.WriteLine("Success");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateCase()
        {
            Console.Clear();

            Console.WriteLine("Enter the product model: ");
            try
            {
                int model = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the product marker: ");
                char marker = char.Parse(Console.ReadLine());
                Console.WriteLine("Enter the product type: ");
                string type = Console.ReadLine();
                data.Update(new Product()
                {
                    Maker = marker,
                    Model = model,
                    Type = type
                });
                Console.WriteLine("Success");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteCase()
        {
            Console.Clear();
            Console.WriteLine("Enter the product model: ");

                try
                {
                    int model = int.Parse(Console.ReadLine());
                    data.Delete(model);
                    Console.WriteLine("Success");
                    Console.ReadKey();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        private static void Print(Product product)
        {
            Console.WriteLine($"  {product.Maker}\t  {product.Model}\t      {product.Type}\t\n");
        }
    }
}
