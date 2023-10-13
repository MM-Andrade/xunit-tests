namespace calculadora.tests
{
    public class ClaculadoraTest
    {

        /*Para criar um teste, é necessário criar um método público que retorne void.
         * Para que o teste seja reconhecido, é necessário adicionar o atributo [Fact] acima do método. 
         * O nome do método deve ser descritivo, para que seja fácil identificar o que está sendo testado. 
         * O método deve ser criado dentro de uma classe pública.*/

        [Fact]
        public void Soma_DeveRetornarOValorCorreto()
        {
            Calculadora c = new Calculadora();
            var resultado = c.Soma(10, 20);

            //verifica se o resultado é 30
            Assert.Equal(30, resultado);

        }

        /*Também é possível criar teorias dentro dos testes. A teoria executa o mesmo teste com diversos parâmetros.
         * Caso algum dos parâmetros gere um resultado inesperado, ela é considerada falha */

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]

        public void RestoDivisao_DeveRetornarZero(int value)
        {
            Calculadora c = new Calculadora();
            var resultado = c.RestoDivisao(12, value);

            //verifica se o resto da divisão é 0
            Assert.Equal(0, resultado.resto);
        }

        [Fact]
        public void RestoDivisao_DeveRetornarOValorExato()
        {
            Calculadora c = new Calculadora();
            var resultado = c.RestoDivisao(10, 3);

            Assert.Equal(3, resultado.quociente);
            Assert.Equal(1,resultado.resto);
        }

        [Fact]
        public void Subtracao_DeveRetornarOValorCorreto()
        {
            Calculadora c = new Calculadora();
            var  resultado = c.Subtracao(20, 10);

            Assert.Equal(10, resultado);

        }

        [Fact]
        public void Multiplicacao_DeveRetornarOValorCorreto()
        {
            Calculadora c = new Calculadora();
            var resultado = c.Multiplicao(5, 2);

            Assert.Equal(10, resultado);

        }

    }
}
