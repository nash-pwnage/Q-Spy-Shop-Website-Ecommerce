using System.Collections.Generic;
using System.Data.Entity;

namespace QsSpyShop.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 9,
                    CategoryName = "Tools"
                },
                new Category
                {
                    CategoryID = 9,
                    CategoryName = "Weapons"
                },
                new Category
                {
                    CategoryID = 10,
                    CategoryName = "Vehicles"
                },
                new Category
                {
                    CategoryID = 11,
                    CategoryName = "Apparel"
                },
                new Category
                {
                    CategoryID = 12,
                    CategoryName = "Miscellaneous"
                },
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 8,
                    ProductName = "Geiger counter",
                    Description = "Bond has to request one from Britain before using it to determine the radioactivity of Crab Key, suggesting they were an uncommon piece of equipment.", 
                    ImagePath="220px-Geiger_counter.jpg",
                    UnitPrice = 14999,
                    CategoryID = 8
               },
                new Product 
                {
                    ProductID = 9,
                    ProductName = "Self-destructor bag ",
                    Description = "M tells Bond that the case notes will be sent to him at the airport in one of these.",
                    ImagePath="self_destruct.jpg",
                    UnitPrice = 299,
                     CategoryID = 8
               },
                new Product
                {
                    ProductID = 10,
                    ProductName = "Rolex Submariner",
                    Description = "on plain leather strap",
                    ImagePath="rolex.jpg",
                    UnitPrice = 32999.99,
                    CategoryID = 8
                },
                new Product
                {
                    ProductID = 11,
                    ProductName = "Pager ",
                    Description = "Bond had one to notify him if he ever needed to contact MI6. It is worth noting that Bond also had a radio phone installed in his car as well.",
                    ImagePath="pager.jpg",
                    UnitPrice = 800.95,
                    CategoryID = 8
                },
                new Product
                {
                    ProductID = 12,
                    ProductName = "Bug detector",
                    Description = "A small device that is designed to detect the presence of a phone tap device in a regular telephone.",
                    ImagePath="bugdetector.jpg",
                    UnitPrice = 3400.95,
                    CategoryID = 8
                },
                new Product
                {
                    ProductID = 14,
                    ProductName = "Walther PPK 7.65mm",
                    Description = "The first appearance of James Bond's signature firearm.",
                    ImagePath="WaltherPPK.jpg",
                    UnitPrice = 9500.00,
                    CategoryID = 9
                },
                new Product
                {
                    ProductID = 15,
                    ProductName = "Dagger shoe ",
                    Description = "A shoe with a poisoned blade concealed within worn by SPECTRE agents, including Rosa Klebb. The blade would pop out of the front of the shoe, making kicks extremely dangerous. One pair was used by Morzeny to kill Kronsteen after his plan failed. ",
                    ImagePath="dagger.jpg",
                    UnitPrice = 4999.95,
                    CategoryID = 9
                },
                new Product
                {
                    ProductID = 16,
                    ProductName = "Industrial Laser ",
                    Description = "Powerful enough to put a laser dot on the moon, but at very close range able to cut through steel. This laser was later used to cut open the vault of Fort Knox. ",
                    ImagePath="laser.jpg",
                    UnitPrice = 29999.95,
                    CategoryID = 9
                },
                new Product
                {
                    ProductID = 17,
                    ProductName = "Atomic Bomb ",
                    Description = "Used to contaminate the Fort Knox gold supply utilizing optimum lethal radiation, but with as least amount of explosive force.",
                    ImagePath="atomic.jpg",
                    UnitPrice = 320000.95,
                    CategoryID = 9
                },
                new Product
                {
                    ProductID = 18,
                    ProductName = "Aston Martin DB5 ",
                    Description = "the same car used in Goldfinger with a slight modification; rearward spraying water jets.",
                    ImagePath="aston.jpg",
                    UnitPrice = 150000.00,
                    CategoryID = 10
                },
                new Product
                {
                    ProductID = 19,
                    ProductName = "Underwater Jet Pack",
                    Description = "During the final undersea battle, Bond is equipped with a bulky scuba tank that not only propels him through the water faster than anyone can swim; it is equipped with two explosive-tipped spear guns.",
                    ImagePath="jetpack.jpg",
                    UnitPrice = 260000.00,
                    CategoryID = 10
                },
                new Product
                {
                    ProductID = 20,
                    ProductName = "Skyhook ",
                    Description = "Comes as a grappling suspender attached to a weather balloon that Bond can attach to his utility harness. With the aid of a specialised aircraft (B-17) installed with specialised braces, Bond and Domino are hoisted up into the air and out of the area.",
                    ImagePath="sky.jpg",
                    UnitPrice = 299999.00,
                    CategoryID = 10
                },
                new Product
                {
                    ProductID = 21,
                    ProductName = "Kevlar 500 x-shell",
                    Description = "Virtually indestructible choice for the tough",

                    ImagePath="kevlar.jpg",
                    UnitPrice = 95000.00,
                    CategoryID = 11
                },
                new Product
                {
                    ProductID = 22,
                    ProductName = "Invisi-suite",
                    Description = "Imparts unparalleled invisibility abilities to a bleeding edge spy",
                    ImagePath="invisible.jpg",
                    UnitPrice = 40000.95,
                    CategoryID = 11
                },
                new Product
                {
                    ProductID = 23,
                    ProductName = "Mech Warrior III",
                    Description = "Ultimate War machine. Rpgs, Turrets, Jetpacks. Period.",
                    ImagePath="mech.jpg",
                    UnitPrice = 4200000.95,
                    CategoryID = 11
                },
                new Product
                {
                    ProductID = 24,
                    ProductName = "Cloning Facility ",
                    Description = "Can produce 1000 copies of an organism an hour at full power.",
                    ImagePath="clone.jpg",
                    UnitPrice = 122000000.95,
                    CategoryID = 12
                }
            };

            return products;
        }
    }
}