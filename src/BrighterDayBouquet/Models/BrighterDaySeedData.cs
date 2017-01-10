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
                user.FirstName = "Russell";
                user.LastName = "Dow";

                var created = await _userManager.CreateAsync(user, "Password11!");

                var user2 = new ApplicationUser();
                user2.Email = "yuliazhuk@brighterday.com";
                user2.FirstName = "Yulia";
                user2.LastName = "Zhuk";

                await _userManager.CreateAsync(user2, "Password11!");
            }

            // Create Products if they're not in the DB yet
            if (!_context.Products.Any())
            {
                Product pinkExpression = new Product();
                pinkExpression.ProductName = "Pink Expressions";
                
                pinkExpression.MainImage = "~/images/pinkexpression.jpg";
                pinkExpression.ProductDescription = "A delicate mix of roses, lilies and carnations in various shades of pink.";
                pinkExpression.UnitPrice = 40.00d;
                pinkExpression.Rating = 4;

                _context.Products.Add(pinkExpression);

                Product redBloom = new Product();
                redBloom.ProductName = "Red Bloom";
                redBloom.MainImage = "~/images/redbloom.jpg";
                redBloom.ProductDescription = "Two dozen brilliant, sweet scented red roses to brighten your day.";
                redBloom.UnitPrice = 45.00d;
                redBloom.Rating = 5;

                _context.Products.Add(redBloom);

                Product multiColor = new Product();
                multiColor.ProductName = "Expression of colors";
                multiColor.MainImage = "~/images/multicolor.jpg";
                multiColor.ProductDescription = "Two dozen bright multi-colored roses. Shades of red green and blue fused together to provide an unimaginable beauty.";
                multiColor.UnitPrice = 65.00d;
                multiColor.Rating = 5;

                _context.Products.Add(multiColor);

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
