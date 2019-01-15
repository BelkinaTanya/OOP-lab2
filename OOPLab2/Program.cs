using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OOPLab2.Model;
//using OOPLab2.Interface;

namespace OOPLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store("Универмаг");
            List<Product> products = new List<Product>();
            Basket basket = new Basket();
            FileLoadStore(store);
            DataBaseFileLoad(products);
            Console.WriteLine("Для поиска товара выберете по номеру соответствующий отдел:");
            store.PrintDepartments();
            try
            {
                int departmentSelection = int.Parse(Console.ReadLine());
                Console.WriteLine($"Отдел \"{store.ElementAt(departmentSelection - 1)}\" включает следующие категории:");
                store.ElementAt(departmentSelection - 1).PrintCategories();
                Console.WriteLine("Выберете номер категории товара:");
                int categorySelection = int.Parse(Console.ReadLine());
                var rezult = products.Where(product => product.Category == store.ElementAt(departmentSelection - 1).ElementAt(categorySelection - 1).Title);
                Console.WriteLine($"Категория \"{store.ElementAt(departmentSelection - 1).ElementAt(categorySelection - 1)}\" включает следующие товары:");
                int index = 1;
                foreach (Product product in rezult)
                {
                    Console.WriteLine($"{index++}. {product}");
                }
                Console.WriteLine();
                Console.WriteLine("Добавьте по номеру интересующие товары в корзину. Для возврата в меню нажмите ноль.");
                int productSelection = int.Parse(Console.ReadLine());
                while (productSelection != 0)
                {
                    basket.AddItem(rezult.ElementAt(productSelection - 1));
                    productSelection = int.Parse(Console.ReadLine());
                }

                basket.PrintBasket();
                basket.RemoveLine(basket.lines.ElementAt(0).Product);
                basket.PrintBasket();
                basket.Clear();
                basket.PrintBasket();
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        
        static void FileLoadStore(Store store)
        {
            using (StreamReader listDepartments = new StreamReader("Department.txt", Encoding.Default))
            {
                string str = listDepartments.ReadLine();
                while (str != null)
                {
                    store.Add(new Department(str));
                    str = listDepartments.ReadLine();
                }
            }
            using (StreamReader listCategories = new StreamReader("Category.txt", Encoding.Default))
            {
                string str = listCategories.ReadLine();
                while (str != null)
                {
                    int numberOfElementsInARow = 2;   // Категория; Отдел
                    string[] elements = new string[numberOfElementsInARow];
                    elements = str.Split(';');
                    store.Find(x => x.Title.Contains(elements[1])).Add(new Category(elements[0]));
                    str = listCategories.ReadLine();
                }
            }
     
        }
        static void DataBaseFileLoad(List<Product> products)
        {
            using (StreamReader listProducts = new StreamReader("Product.txt", Encoding.Default))
            {
                string str = listProducts.ReadLine();
                int number = 4;   // Имя; Категория; Цена; Количество
                string[] fields = new string[number];
                while (str != "")
                {
                    fields = str.Split(';');
                    products.Add(new Product(fields[0], fields[1], decimal.Parse(fields[2]), int.Parse(fields[3])));
                    str = listProducts.ReadLine();
                }
            }
        }
    }
}
