using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        //    List<Pizza> pizzasList = new List<Pizza>();

        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {

            using (PizzaContext context = new PizzaContext())
            {
                List<Pizza> pizzas = context.pizzasList.ToList<Pizza>();
                return View("Index", pizzas);
            }
            //List<Pizza> pizzasList = new List<Pizza>();

            //Pizza Margherita = new Pizza("Margherita", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "pizza-margherita.jpg", 3);
            //Pizza Marinara = new Pizza("Marinara", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "marinara.jpg", 3);
            //Pizza Mortadella = new Pizza("Mortadella pistacchio e stracciatella", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "mortadella.jpg", 7);
            //Pizza QuattroFormaggi = new Pizza("Quattro Formaggi", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "formaggi.jpg", 5);
            //Pizza Crudaiola = new Pizza("Crudaiola", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "crudaiola.jpg", 5);


            //pizzasList.Add(Margherita);
            //pizzasList.Add(Marinara);
            //pizzasList.Add(Mortadella);
            //pizzasList.Add(QuattroFormaggi);
            //pizzasList.Add(Crudaiola);



            //return View(pizzasList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }

            using (PizzaContext context = new PizzaContext())
            {
                Pizza pizza = new Pizza();
                pizza.Name = formData.Name;
                pizza.Description = formData.Description;
                pizza.Photo = formData.Photo;
                pizza.Price = formData.Price;

                context.pizzasList.Add(pizza);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public IActionResult Show(int id)
        {
            //List<Pizza> pizzasList = new List<Pizza>();

            //Pizza Margherita = new Pizza(0, "Margherita", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "pizza-margherita.jpg", "3,99");
            //Pizza Marinara = new Pizza(1, "Marinara", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "marinara.jpg", "3,00");
            //Pizza Mortadella = new Pizza(2, "Mortadella pistacchio e stracciatella", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "mortadella.jpg", "7,99");
            //Pizza QuattroFormaggi = new Pizza(3, "Quattro Formaggi", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "formaggi.jpg", "5,99");
            //Pizza Crudaiola = new Pizza(4, "Crudaiola", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed", "crudaiola.jpg", "5,99");


            //pizzasList.Add(Margherita);
            //pizzasList.Add(Marinara);
            //pizzasList.Add(Mortadella);
            //pizzasList.Add(QuattroFormaggi);
            //pizzasList.Add(Crudaiola);

            using (PizzaContext context = new PizzaContext())
            {
                List<Pizza> pizzas = context.pizzasList.ToList<Pizza>();

                if (id >= pizzas.Count)
                {
                    return View("Error");
                }

                return View("Show", pizzas[id]);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }

}