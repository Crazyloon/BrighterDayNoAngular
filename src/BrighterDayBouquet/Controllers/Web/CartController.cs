using BrighterDayBouquet.Data.Repositories;
using BrighterDayBouquet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighterDayBouquet.Controllers.Web
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private CartItemRepository _cartItemRepository;
        private ILogger<CartController> _logger;
        private ProductRepository _productRepository;
        private ShoppingCartRepository _shoppingCartRepository;
        private UserManager<ApplicationUser> _userManager;

        public CartController(CartItemRepository cartItemRepo, ShoppingCartRepository cartRepo, ProductRepository productRepo, ILogger<CartController> logger, UserManager<ApplicationUser> userManager)
        {
            this._productRepository = productRepo;
            this._cartItemRepository = cartItemRepo;
            this._shoppingCartRepository = cartRepo;
            this._logger = logger;
            this._userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ViewCart()
        {
            // get user
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // get/create user's cart
            try
            {
                // get cart
                ShoppingCart userCart = await this.GetUserCart(currentUser);
                // TODO
                // GO TO CART VIEW AND POPULATE W/ USERS CART DATA
                
            }
            catch (Exception)
            {

                throw;
            }

            // display new view with users cart info


            return BadRequest("User cart does not exist.");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string productCode)
        {

            // Get the user attemping to AddToCart
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get the users's shopping cart, or create one if it does not exist
            try
            {
                // get cart
                ShoppingCart userCart = _shoppingCartRepository.GetByUserID(currentUser.Id);
                if (userCart == null) // create if one can't be found
                {
                    userCart = new ShoppingCart();
                    userCart.UserID = currentUser.Id;
                    userCart.CreatedDate = DateTime.Now;
                    _shoppingCartRepository.Add(userCart);

                    if (!await _shoppingCartRepository.SaveChangesAsync()) // If the new cart couldn't be saved
                    {
                        return BadRequest("System Error: Unable to create cart");
                    }
                }

                // this DB read can be eliminated if we simply choose to pass the ID around in the View
                Product product = _productRepository.GetByProductCode(productCode);

                // Create the cart item and add it to the cart
                CartItem cartItem = new CartItem();
                cartItem.CartID = userCart.Id;
                cartItem.ProductID = product.Id;
                cartItem.PackageStyleID = 1;
                cartItem.Quantity = 1;
                cartItem.isCheckedOut = false;

                _cartItemRepository.Add(cartItem);

                // Commit to database
                if (await _cartItemRepository.SaveChangesAsync())
                {
                    return RedirectToAction("Browse", "Products");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to find or create the user's cart.");
            }

            return BadRequest("Unable to add item to cart.");
        }

        private async Task<ShoppingCart> GetUserCart(ApplicationUser currentUser)
        {
            // get cart
            ShoppingCart userCart = _shoppingCartRepository.GetByUserID(currentUser.Id);
            if (userCart == null) // create if one can't be found
            {
                userCart = new ShoppingCart();
                userCart.UserID = currentUser.Id;
                userCart.CreatedDate = DateTime.Now;
                _shoppingCartRepository.Add(userCart);

                if (!await _shoppingCartRepository.SaveChangesAsync()) // If the new cart couldn't be saved
                {
                    return null;
                }
            }
            return userCart;
        }
    }
}
