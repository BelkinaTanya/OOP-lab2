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
            try
            {
                ApplicationMenu(store, products, basket);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ApplicationMenu(Store store, List<Product> products, Basket basket)
        {
            Console.WriteLine("Меню:\n1. Поиск товаров\n2.Корзина\n3.Выход из приложения");
            Console.Write("Ваш выбор: ");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    ProductSearch(store, products, basket);
                    break;
                case "2":
                    ViewBasket(store, products, basket);
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Такого пункта меню нет!");
                    break;     
            } 
        }
        static void ProductSearch(Store store, List<Product> products, Basket basket)
        {
            Console.WriteLine("Для поиска товара выберете по номеру соответствующий отдел:");
            store.PrintDepartments();
            Console.Write("Ваш выбор: ");
            int departmentSelection = int.Parse(Console.ReadLine());
            Console.WriteLine($"Отдел \"{store.GetListDepartments().ElementAt(departmentSelection - 1)}\" включает следующие категории:");
            store.GetListDepartments().ElementAt(departmentSelection - 1).PrintCategories();
            Console.WriteLine("Выберете номер категории товара:");
            Console.Write("Ваш выбор: ");
            int categorySelection = int.Parse(Console.ReadLine());
            var rezult = products.Where(product => product.Category == store.GetListDepartments().ElementAt(departmentSelection - 1).GetListCategories().ElementAt(categorySelection - 1).Title);
            Console.WriteLine($"Категория \"{store.GetListDepartments().ElementAt(departmentSelection - 1).GetListCategories().ElementAt(categorySelection - 1)}\" включает следующие товары:");
            int index = 1;
            foreach (Product product in rezult)
            {
                Console.WriteLine($"{index++}. {product}");
            }
            Console.WriteLine();
            Console.WriteLine("0. Меню");
            Console.WriteLine();
            Console.WriteLine("Добавьте по номеру интересующие товары в корзину или нажмине ноль для возврата в главное меню.");
            Console.Write("Ваш выбор: ");
            int productSelection = int.Parse(Console.ReadLine());
            while (productSelection != 0)
            {
                basket.AddItem(rezult.ElementAt(productSelection - 1));
                Console.Write("Ваш выбор: ");
                productSelection = int.Parse(Console.ReadLine());
            }
            ApplicationMenu(store, products, basket);
        }
        static void ViewBasket(Store store, List<Product> products, Basket basket)
        {
            Console.WriteLine("Меню корзины:\n1. Просмотр корзины\n2.Увеличить количество товара\n3.Удалить товар из списка\n4.Очистить корзину\n5.Оформить заказ\n6.Вернуться в меню");
            Console.Write("Ваш выбор: ");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    basket.PrintBasket();
                    Console.WriteLine();
                    ViewBasket(store, products, basket);
                    break;
                case "2":
                    if (!CheckTheAvailabilityOfGoodsInTheBasket(basket))
                    {
                        Console.WriteLine();
                        ApplicationMenu(store, products, basket);
                        break;
                    }
                    Console.WriteLine("Выберете номер товара из списка.");
                    Console.Write("Ваш выбор: ");
                    int productSelection1 = int.Parse(Console.ReadLine());
                    basket.AddItem(basket.lines.ElementAt(productSelection1 - 1).Product);
                    ViewBasket(store, products, basket);
                    break;
                case "3":
                    if (!CheckTheAvailabilityOfGoodsInTheBasket(basket))
                    {
                        Console.WriteLine();
                        ApplicationMenu(store, products, basket);
                        break;
                    }
                    Console.WriteLine("Выберете номер товара для удаления.");
                    Console.Write("Ваш выбор: ");
                    int productSelection2 = int.Parse(Console.ReadLine());
                    basket.RemoveLine(basket.lines.ElementAt(productSelection2 - 1).Product);
                    ViewBasket(store, products, basket);
                    break;
                case "4":
                    basket.Clear();
                    ViewBasket(store, products, basket);
                    break;
                case "5":
                    GoToCheckout(basket);
                    break;
                case "6":
                    Console.WriteLine();
                    ApplicationMenu(store, products, basket);
                    break;
                default:
                    Console.WriteLine("Такого пункта меню нет!");
                    break;
            }
        }
        static void GoToCheckout(Basket basket)
        {
            Console.WriteLine("Введите данные обязательные для заполнения:");
            Console.Write("Имя:");
            string nameCustomer = Console.ReadLine();
            while (string.IsNullOrEmpty(nameCustomer))
            {
                Console.Write("Данное поле обязательно для заполнения!");
                Console.Write("\nИмя:");
                nameCustomer = Console.ReadLine();
            }
            Console.Write("Адрес доставки:");
            var addressCustomer = Console.ReadLine();
            while (string.IsNullOrEmpty(addressCustomer))
            {
                Console.Write("Данное поле обязательно для заполнения!");
                Console.Write("\nАдрес доставки:");
                addressCustomer = Console.ReadLine();
            }
            Checkout checkout = new Checkout();
            checkout.AddCustomer(new Customer(nameCustomer, addressCustomer));
            checkout.AddPaymentList(basket);
            checkout.PrintPaymentList();
            Console.WriteLine();
            Console.WriteLine("Оплатить {0:f2} руб.", checkout.GetPaymentAmount());
            Console.WriteLine("Спасибо что выбрали наш магазин!");
        }
        static bool CheckTheAvailabilityOfGoodsInTheBasket (Basket basket)
        {
            if (basket.lines.FirstOrDefault() != null)
                return true;
            else
            {
                Console.WriteLine("Товаров в корзине нет!");
                return false;
            }
        }
        static void FileLoadStore(Store store)
        {
            using (StreamReader listDepartments = new StreamReader("Department.txt", Encoding.Default))
            {
                string str = listDepartments.ReadLine();
                while (str != null)
                {
                    store.AddDepartment(new Department(str));
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
                    store.GetListDepartments().Find(x => x.Title.Contains(elements[1])).AddCategory(new Category(elements[0]));
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
