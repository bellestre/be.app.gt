using System;
using Xunit;
using Logic.gra;
using Models.gra;

namespace MyTests
{
    public class LogicAutorTest
    {
        /// <summary>
        /// Metodo de prueba de fallo donde el valor de entrada CREDITOS APROBADOS es 150
        /// </summary>
        [Fact]
        public void Fail_EquivalencePartitioning()
        {
            var agregar = new LogicAutor();
            var myAutor = new Autor() {CreditosAprobados = 150, GradoAcademico = "Bachiller" };

            var result = agregar.RulesForAdd(myAutor);

            Assert.False(result);
        }
        /// <summary>
        /// Metodo de prueba de exito donde el valor de entrada CREDITOS APROBADOS es 184
        /// </summary>
        [Fact]
        public void Success_EquivalencePartitioning()
        {
            var agregar = new LogicAutor();
            var myAutor = new Autor() { CreditosAprobados = 184, GradoAcademico = "Pregrado" };

            var result = agregar.RulesForAdd(myAutor);

            Assert.True(result);
        }

        /// <summary>
        /// Metodo de prueba de exito donde el valor de entrada CREDITOS APROBADOS es 159
        /// </summary>
        [Fact]
        public void FailBoundaryValue()
        {
            var agregar = new LogicAutor();
            var myAutor = new Autor() { CreditosAprobados = 159, GradoAcademico = "Bachiller" };

            var result = agregar.RulesForAdd(myAutor);

            Assert.False(result);
        }
        /// <summary>
        /// Metodo de prueba de exito donde el valor de entrada CREDITOS APROBADOS es 160
        /// </summary>
        [Fact]
        public void SuccessBoundaryValue()
        {
            var agregar = new LogicAutor();
            var myAutor = new Autor() { CreditosAprobados = 160, GradoAcademico = "Pregrado" };

            var result = agregar.RulesForAdd(myAutor);

            Assert.True(result);
        }

    }
}
