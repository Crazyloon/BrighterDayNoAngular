using BrighterDayBouquet.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Models
{
    public class BrighterDaySeedData
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public BrighterDaySeedData(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            // Give us a new user for testing login and cart functionality
            if (await _userManager.FindByEmailAsync("rdow@brighterday.com") == null)
            {
                var user = new ApplicationUser();
                user.Email = "rdow@brighterday.com";
                user.UserName = user.Email;
                user.FirstName = "Russell";
                user.LastName = "Dow";

                var created = await _userManager.CreateAsync(user, "Password11!");

                var user2 = new ApplicationUser();
                user2.Email = "yuliazhuk@brighterday.com";
                user2.UserName = user2.Email;
                user2.FirstName = "Yulia";
                user2.LastName = "Zhuk";

                await _userManager.CreateAsync(user2, "Password11!");
            }

            // Create product categories
            if (!_context.ProductCategories.Any())
            {
                ProductCategory birthday = new ProductCategory();
                birthday.CategoryName = "Birthday";

                _context.ProductCategories.Add(birthday);

                ProductCategory justBecause = new ProductCategory();
                justBecause.CategoryName = "Just Because";

                _context.ProductCategories.Add(justBecause);

                ProductCategory party = new ProductCategory();
                party.CategoryName = "Party";

                _context.ProductCategories.Add(party);

                ProductCategory romantic = new ProductCategory();
                romantic.CategoryName = "Romantic";

                _context.ProductCategories.Add(romantic);

                ProductCategory sympathy = new ProductCategory();
                sympathy.CategoryName = "Sympathy";

                _context.ProductCategories.Add(sympathy);

                ProductCategory wedding = new ProductCategory();
                wedding.CategoryName = "Wedding";

                _context.ProductCategories.Add(wedding);


                _context.SaveChanges();
            }

            // Create Products if they're not in the DB yet
            if (!_context.Products.Any())
            {
                Product pinkExpression = new Product();
                pinkExpression.ProductName = "Pink Expressions";
                pinkExpression.ProductCode = "1701AAAA24";
                pinkExpression.CategoryID = 1;
                pinkExpression.MainImage = "images/pinkexpression.jpg";
                pinkExpression.MainImageAltText = "A delicate mix of roses.";
                pinkExpression.ProductDescription = "A delicate mix of roses, lilies and carnations in various shades of pink.";
                pinkExpression.UnitPrice = 40.00m;
                pinkExpression.Rating = 4; // Raiting will eventually come from a query on user reviews for each product. Raitings will be updated once per day.

                _context.Products.Add(pinkExpression);

                Product redBloom = new Product();
                redBloom.ProductName = "Red Bloom";
                redBloom.ProductCode = "1701AAAB24";
                redBloom.CategoryID = 4;
                redBloom.MainImage = "images/redbloom.jpg";
                redBloom.MainImageAltText = "Two dozen red roses.";
                redBloom.ProductDescription = "Two dozen brilliant, sweet scented red roses to brighten your day.";
                redBloom.UnitPrice = 45.00m;
                redBloom.Rating = 5;

                _context.Products.Add(redBloom);

                Product multiColor = new Product();
                multiColor.ProductName = "Expression of colors";
                multiColor.ProductCode = "1701AAAC24";
                multiColor.CategoryID = 3;
                multiColor.MainImage = "images/multicolor.jpg";
                multiColor.MainImageAltText = "Two dozen multi-colored roses.";
                multiColor.ProductDescription = "Two dozen bright multi-colored roses. Shades of red green and blue fused together to provide an unimaginable beauty.";
                multiColor.UnitPrice = 65.00m;
                multiColor.Rating = 5;

                _context.Products.Add(multiColor);

                Product smile = new Product();
                smile.ProductName = "Sending Smiles";
                smile.ProductCode = "1701AAAD24";
                smile.CategoryID = 2;
                smile.MainImage = "images/sendingsmiles.jpg";
                smile.MainImageAltText = "Friendly colors mix.";
                smile.ProductDescription = "Friendly colors, bursting with happieness. A brilliant bouquet in a cute mug that is sure to make someone smile!";
                smile.UnitPrice = 45.00m;
                smile.Rating = 4;

                _context.Products.Add(smile);

                _context.SaveChanges();
            }

            // No package styles? Add some.
            if (!_context.PackageStyles.Any())
            {
                PackageStyle ps = new PackageStyle();
                ps.Style = "None";

                _context.PackageStyles.Add(ps);

                PackageStyle ps2 = new PackageStyle();
                ps2.Style = "Wrapping";

                _context.PackageStyles.Add(ps2);

                PackageStyle ps3 = new PackageStyle();
                ps3.Style = "Vase";

                _context.PackageStyles.Add(ps3);

                _context.SaveChanges();
            }

            // Create a pretend cart for Russell Dow. We will try to create a cart for Yulia with the website
            if (!_context.ShoppingCarts.Any())
            {
                ShoppingCart sc = new ShoppingCart();
                sc.CreatedDate = DateTime.Now;
                ApplicationUser user = await _userManager.FindByEmailAsync("rdow@brighterday.com");
                sc.UserID = user.Id;
                sc.CheckoutDate = null;

                _context.ShoppingCarts.Add(sc);

                ShoppingCart sc2 = new ShoppingCart();
                sc.CreatedDate = DateTime.Now;
                ApplicationUser user2 = await _userManager.FindByEmailAsync("yuliazhuk@brighterday.com");
                sc.UserID = user2.Id;
                sc.CheckoutDate = null;

                _context.ShoppingCarts.Add(sc2);

                _context.SaveChanges();
            }


            // Cart Items for Russell's shopping cart
            if (!_context.CartItems.Any())
            {
                CartItem ci = new CartItem();
                ci.CartID = 1;
                ci.PackageStyleID = 1;
                ci.ProductID = 1;
                ci.Quantity = 2;
                ci.isCheckedOut = false;

                _context.CartItems.Add(ci);

                CartItem ci2 = new CartItem();
                ci2.CartID = 1;
                ci2.PackageStyleID = 2;
                ci2.ProductID = 1;
                ci2.Quantity = 2;
                ci2.isCheckedOut = false;

                _context.CartItems.Add(ci2);

                _context.SaveChanges();
            }

        }
    }
}
