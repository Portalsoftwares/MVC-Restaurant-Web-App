using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCRestaurantApp;
using MVCRestaurantApp.Controllers;
using Moq;
using MVCRestaurantApp.Models;

namespace MVCRestaurantApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestClass]
        public class MenusControllerTest
        {
            Mock<MenuMock> mock;
            List<Menu> menus;
            MenusController controller;

            [TestInitialize]
            public void TestInitialize()
            {
                // arrange mock data for all unit tests
                mock = new Mock<MenuMock>();

                menus = new List<Menu>
            {
                new Menu { Menu_Id=100, Meal_Name="Burger", Meal_Type="FastFood", Calories=2000,Price=20
                },
                new Menu { Menu_Id=200, Meal_Name="Pizza", Meal_Type="FastFood", Calories=3000,Price=30
                },
                new Menu { Menu_Id=300, Meal_Name="Fries", Meal_Type="UltraFastFood", Calories=1000,Price=10
                }
            };

                // populate interface from mock data
                mock.Setup(m => m.Menus).Returns(menus.AsQueryable());

                controller = new MenusController(mock.Object);
            }


            #region
            [TestMethod]
            public void IndexReturnsView()
            {
                // act
                ViewResult result = controller.Index() as ViewResult;

                // assert
                Assert.AreEqual("Index", result.ViewName);
            }

            [TestMethod]
            public void IndexReturnsAlbums()
            {
                // act - does the viewresults Model equal a list of albums?
                var actual = (List<Menu>)((ViewResult)controller.Index()).Model;

                // assert
                CollectionAssert.AreEqual(menus.ToList(), actual);
            }
            #endregion

            // GET: Albums/Details/100
            #region
            [TestMethod]
            public void DetailsNoId()
            {
                // act
                var result = (ViewResult)controller.Details(null);

                // assert
                Assert.AreEqual("Error", result.ViewName);
            }

            [TestMethod]
            public void DetailsInvalidId()
            {
                // act
                var result = (ViewResult)controller.Details(67830);

                // assert
                Assert.AreEqual("Error", result.ViewName);
            }

            [TestMethod]
            public void DetailsValidId()
            {
                // act - cast the model as an Album object
                Menu actual = (Menu)((ViewResult)controller.Details(300)).Model;

                // assert - is this the first mock album in our array?
                Assert.AreEqual(menus[2], actual);
            }

            [TestMethod]
            public void DetailsViewLoads()
            {
                // act
                ViewResult result = (ViewResult)controller.Details(300);

                // assert
                Assert.AreEqual("Details", result.ViewName);
            }
            #endregion

            // GET: Albums/Edit/5
            #region
            [TestMethod]
            public void EditNoId()
            {
                // arrange
                int? id = null;

                // act 
                var result = (ViewResult)controller.Edit(id);

                // assert
                Assert.AreEqual("Error", result.ViewName);
            }

            [TestMethod]
            public void EditInvalidId()
            {
                // act
                var result = (ViewResult)controller.Edit(8983);

                // assert
                Assert.AreEqual("Error", result.ViewName);
            }

 

            [TestMethod]
            public void EditViewLoads()
            {
                // act
                ViewResult actual = (ViewResult)controller.Edit(100);

                // assert
                Assert.AreEqual("Edit", actual.ViewName);
            }

            [TestMethod]
            public void EditLoadsAlbum()
            {
                // act
                Menu actual = (Menu)((ViewResult)controller.Edit(100)).Model;

                // assert
                Assert.AreEqual(menus[0], actual);
            }
            #endregion

            // GET: Albums/Create
            #region

            [TestMethod]
            public void CreateViewLoads()
            {
                // act
                var result = (ViewResult)controller.Create();

                // assert
                Assert.AreEqual("Create", result.ViewName);
            }

            #endregion

            // GET: Albums/Delete
            #region

            [TestMethod]
            public void DeleteNoId()
            {
                // act
                var result = (ViewResult)controller.Delete(null);

                // assert
                Assert.AreEqual("Error", result.ViewName);
            }

            [TestMethod]
            public void DeleteInvalidId()
            {
                // act
                var result = (ViewResult)controller.Delete(3739);

                // assert
                Assert.AreEqual("Error", result.ViewName);
            }

            [TestMethod]
            public void DeleteValidIdLoadsView()
            {
                // act
                var result = (ViewResult)controller.Delete(100);

                // assert
                Assert.AreEqual("Delete", result.ViewName);
            }

            [TestMethod]
            public void DeleteValidIdLoadsMenu()
            {
                // act
                Menu result = (Menu)((ViewResult)controller.Delete(100)).Model;

                // assert
                Assert.AreEqual(menus[0], result);
            }

            #endregion

            // POST: Albums/Edit
            #region

            [TestMethod]
            public void EditPostLoadsIndex()
            {
                // act
                RedirectToRouteResult result = (RedirectToRouteResult)controller.Edit(menus[0]);

                // assert
                Assert.AreEqual("Index", result.RouteValues["action"]);
            }

            
            [TestMethod]
            public void EditPostInvalidLoadsView()
            {
                // arrange
                Menu invalid = new Menu { Menu_Id = 27 };
                controller.ModelState.AddModelError("Error", "Won't Save");

                // act
                ViewResult result = (ViewResult)controller.Edit(invalid);

                // assert
                Assert.AreEqual("Edit", result.ViewName);
            }

            [TestMethod]
            public void EditPostInvalidLoadsMenu()
            {
                // arrange
                Menu invalid = new Menu { Menu_Id = 100 };
                controller.ModelState.AddModelError("Error", "Won't Save");

                // act
                Menu result = (Menu)((ViewResult)controller.Edit(invalid)).Model;

                // assert
                Assert.AreEqual(invalid, result);
            }

            #endregion

            // POST: Albums/Create
            #region
            [TestMethod]
            public void CreateValidMenu()
            {
                // arrange
                Menu newMenu = new Menu
                {
                    Menu_Id = 400,
                    Meal_Name = "Donner",
                    Meal_Type = "FastFood",
                    Calories = 5000,
                    Price = 15
                };

                // act
                RedirectToRouteResult result = (RedirectToRouteResult)controller.Create(newMenu);

                // assert
                Assert.AreEqual("Index", result.RouteValues["action"]);
            }

            [TestMethod]
            public void CreateInvalidMenu()
            {
                // arrange
                Menu invalid = new Menu();

                // act
                controller.ModelState.AddModelError("Cannot create", "create exception");
                ViewResult result = (ViewResult)controller.Create(invalid);

                // assert
                Assert.AreEqual("Create", result.ViewName);
            }


            #endregion

            // POST: Albums/DeleteConfirmed/100
            #region
            [TestMethod]
            public void DeleteConfirmedNoId()
            {
                // act
                ViewResult result = (ViewResult)controller.DeleteConfirmed(null);

                // assert
                Assert.AreEqual("Error", result.ViewName);
            }

            [TestMethod]
            public void DeleteConfirmedInvalidId()
            {
                // act
                ViewResult result = (ViewResult)controller.DeleteConfirmed(3972);

                // assert
                Assert.AreEqual("Error", result.ViewName);
            }

            [TestMethod]
            public void DeleteConfirmedValidId()
            {
                // act
                RedirectToRouteResult result = (RedirectToRouteResult)controller.DeleteConfirmed(100);

                // assert
                Assert.AreEqual("Index", result.RouteValues["action"]);
            }
            #endregion
        }
    }
}
