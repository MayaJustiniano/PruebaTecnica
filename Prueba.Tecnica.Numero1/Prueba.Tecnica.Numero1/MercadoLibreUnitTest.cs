using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Prueba.Tecnica.Numero1
{
    [TestClass]
    public class MercadoLibreUnitTest
    {
        #region Variables Privadas
        private readonly string rutaSelenium = "C:\\Selenium";
        private readonly string direccionWeb = "https://mercadolibre.com/";

        #endregion
        [TestMethod]
        public void BuscarPorFiltroNuevo()
        {
            IWebDriver driverGH = new ChromeDriver(rutaSelenium);

            driverGH.Manage().Window.Maximize();

            driverGH.Navigate().GoToUrl(direccionWeb);

            driverGH.FindElement(By.Id("BO")).SendKeys(Keys.Enter);
            driverGH.FindElement(By.Name("as_word")).SendKeys("Iphone");
            driverGH.FindElement(By.Name("as_word")).SendKeys(Keys.Enter);

            #region Buscando el filtro llamado nuevo
            var contenedorPrincipal = driverGH.FindElement(By.ClassName("ui-search-filter-groups"));
            var filtrosDentroDeContenedor = contenedorPrincipal.FindElements(By.ClassName("ui-search-filter-dl"));
            var filtroLlamadoCondicion = filtrosDentroDeContenedor[3];

            var tagUl = filtroLlamadoCondicion.FindElement(By.TagName("ul"));
            var filtroLlamadoNuevo = tagUl.FindElements(By.TagName("li"))[0];

            filtroLlamadoNuevo.FindElement(By.ClassName("ui-search-button-link")).SendKeys(Keys.Enter);
            #endregion

            #region Comprobando la cantidad de listado
            var contenedorPrincipalSearch = driverGH.FindElement(By.ClassName("ui-search-results"));
            var contenedorResultados = contenedorPrincipalSearch.FindElement(By.TagName("ol"));
            var listaResultados = contenedorResultados.FindElements(By.TagName("li"));
            #endregion

            Assert.IsTrue(listaResultados.Count >= 3);
        }

        [TestMethod]
        public void BuscarPorFiltroUsado()
        {
            IWebDriver driverGH = new ChromeDriver(rutaSelenium);

            driverGH.Manage().Window.Maximize();

            driverGH.Navigate().GoToUrl(direccionWeb);

            driverGH.FindElement(By.Id("BO")).SendKeys(Keys.Enter);
            driverGH.FindElement(By.Name("as_word")).SendKeys("Iphone");
            driverGH.FindElement(By.Name("as_word")).SendKeys(Keys.Enter);

            #region Buscando el filtro llamado usado
            var contenedorPrincipal = driverGH.FindElement(By.ClassName("ui-search-filter-groups"));
            var filtrosDentroDeContenedor = contenedorPrincipal.FindElements(By.ClassName("ui-search-filter-dl"));
            var filtroLlamadoCondicion = filtrosDentroDeContenedor[3];

            var tagUl = filtroLlamadoCondicion.FindElement(By.TagName("ul"));
            var filtroLlamadoUsado = tagUl.FindElements(By.TagName("li"))[1];

            filtroLlamadoUsado.FindElement(By.ClassName("ui-search-button-link")).SendKeys(Keys.Enter);
            #endregion

            #region Comprobando la cantidad de listado
            var contenedorPrincipalSearch = driverGH.FindElement(By.ClassName("ui-search-results"));
            var contenedorResultados = contenedorPrincipalSearch.FindElement(By.TagName("ol"));
            var listaResultados = contenedorResultados.FindElements(By.TagName("li"));
            #endregion

            Assert.IsTrue(listaResultados.Count >= 3);
        }

    }
}
