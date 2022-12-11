using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop1.Data.Models;

namespace Shop1.Data
{
    public class DBObjects
    {
        public static void Initial(AppDbContent content)
        {


            if (content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));


            if (!content.Car.Any())
            {
                content.AddRange(

                    new Car()
                    {
                        name = "Запорожець",
                        shortDesc = "Не машина - легенда",
                        longDesc = "Мотор як бензопили, їде трохи швидше",
                        img = "/img/Zapor.jpg",
                        price = 900,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Класичні автомобілі"]
                    },

            new Car()
            {
                name = "Tesla",
                shortDesc = "Сучасний електромобіль",
                longDesc = "Заряду батареї вистачає на 1000 км, максимальна швидеість - 300 км/год. Купуйте!",
                img = "/img/Tesla.jpg",
                price = 50000,
                isFavourite = true,
                available = true,
                Category = Categories["Електромобілі"]
            },

            new Car()
            {
                name = "Mercedes",
                shortDesc = "Автомобіль для понтів",
                longDesc = "Бак для соляри, максимальна швидеість - 400 км/год. Один на все село!",
                img = "/img/Mercedes.jpg",
                price = 99000,
                isFavourite = true,
                available = true,
                Category = Categories["Класичні автомобілі"]
            },

            new Car()
            {
                name = "Lamborghini",
                shortDesc = "Чисто бульбу з села привезти. Не бита",
                longDesc = "Їде краще любого трактора",
                img = "/img/Lambo.jpg",
                price = 999000,
                isFavourite = true,
                available = true,
                Category = Categories["Класичні автомобілі"]
            },

            new Car()
            {
                name = "Таврія",
                shortDesc = "Чисто для душі та морального відпочинку",
                longDesc = "Не їде, максимальна швидеість - 000 км/год. Безцінні емоції!",
                img = "/img/Tavriia.jpg",
                price = 900,
                isFavourite = true,
                available = true,
                Category = Categories["Класичні автомобілі"]
            }


                    );
            }

            content.SaveChanges();



        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Електромобілі", desc = "Сучасний вид транспорту" },
                        new Category { categoryName = "Класичні автомобілі", desc = "Автомобілі з двигуном внутрішнього згорання" }
                    };

                category = new Dictionary<string, Category>();

                foreach (Category el in list)
                    category.Add(el.categoryName, el);
                }
                return category;
            }
        }
    }
}
