using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POS.Application.Dtos.Category.Request;

using POS.Application.Interfaces;
using POS.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Test.Category
{
    [TestClass]
    public class CategoryApplicationTest
    {
        //interfaces para la inyecciond e dependecias
        private static WebApplicationFactory<Program>? _factory = null;

        private static IServiceScopeFactory? _scopeFactory = null;

        //metodo que se deb de inicializar antes de todo
        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();   
        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingNullValuesOrEmpty_ValidationErrros()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoryApplication>();

            //PASOS A SEGUIR PARA EL TEST
            //Arrange -> ORGANIZAR O PEPARAR UNA SOLUCION
            var name = "";
            var description = "";
            var state = 1;

            var expected = ReplyMessage.MESSAGE_VALIDATE; /*"otro mensaje";*/

            //Act --> Acturar envio y respuesta de la solicitud
            var result = await context!.RegisterCategory(new CategoryRequestDto()
            {
                Name = name,
                Description = description,
                State = state
            });

            var current = result.Message;
            //Assertt -> Validar la respuesta final como validado o no validado

            Assert.AreEqual(expected, current);      
        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingCorrectValues_RegisteredSuccessfully()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoryApplication>();

            //PASOS A SEGUIR PARA EL TEST
            //Arrange -> ORGANIZAR O PEPARAR UNA SOLUCION
            var name = "Nuevo Registro";
            var description = "Nueva Descripcion";
            var state = 1; 

            var expected = ReplyMessage.MESSAGE_SAVE; /*"otro mensaje";*/

            //Act --> Acturar envio y respuesta de la solicitud
            var result = await context!.RegisterCategory(new CategoryRequestDto()
            {
                Name = name,
                Description = description,
                State = state
            });

            var current = result.Message;
            //Assertt -> Validar la respuesta final como validado o no validado

            Assert.AreEqual(expected, current);
        }
    }
}
