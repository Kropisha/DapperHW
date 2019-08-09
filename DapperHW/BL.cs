using System;

namespace DapperHW
{
    class BL
    {
        Data data = new Data();

        public void GetCase()
        {       
            Console.Clear();
            Console.WriteLine("1 - get all products\n" +
                              "2 - get one product\n" +
                              "3 - exit");
                                      
            int action = 0;
            do
            {
                try
                {
                    action = int.Parse(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            var products = data.GetProducts();
                            Console.WriteLine("Marker\t   Model\t Type\t\n");
                            foreach (var product in products)
                            {
                                Console.WriteLine($"  {product.Maker}\t  {product.Model}\t      {product.Type}\t\n");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the product model: ");
                            int model = int.Parse(Console.ReadLine());
                            var one = data.Get(model);
                            Console.WriteLine("Marker\t   Model\t Type\t\n");
                            Console.WriteLine($"  {one.Maker}\t  {one.Model}\t      {one.Type}\t\n");
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default: 
                            break;

                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (action != 3);
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
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }
    }
}
