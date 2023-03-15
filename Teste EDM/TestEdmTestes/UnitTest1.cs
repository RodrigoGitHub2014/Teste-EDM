using Teste_EDM;
using Xunit;

namespace TestEdmTestes
{
    public class Tests
    {
        [Fact]
        public void Deve_Retornar_Mensagem_De_Erro_Por_Nao_Ter_Nota_No_Caixa()
        {
            //Arrange
            var caixa = new Caixa();

            //Act
            var retorno = caixa.SacarDinheiro(20);

            //Asset
            Assert.Equal(retorno, Caixa.MensagemQuandoNaoEncontrarNotaSuficiente);
        }

        [Fact]
        public void Deve_Retornar_Mensagem_De_Sucesso_Com_Saque_20()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(20, 1);

            //Act
            var retorno = caixa.SacarDinheiro(20);

            //Asset
            var msg = "Valor do Saque: R$20,00 - Resultado Esperado: Entregar 1 nota(s) de R$20,00.";
            Assert.Equal(msg, retorno);
        }

        [Fact]
        public void Deve_Retornar_Mensagem_De_Erro_Por_Nao_Ter_Nota_Mesmo_Tendo_Saldo()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(20, 1);

            //Act
            var retorno = caixa.SacarDinheiro(10);

            //Asset
            Assert.Equal(retorno, Caixa.MensagemQuandoNaoEncontrarNotaSuficiente);
        }


        [Fact]
        public void Deve_Retornar_Mensagem_De_Erro_Por_Valor_Saque_Ser_Maior_Que_O_Valor_Do_Caixa()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(100, 1);

            //Act
            var retorno = caixa.SacarDinheiro(150);

            //Asset
            Assert.Equal(retorno, Caixa.MensagemQuandoNaoEncontrarNotaSuficiente);
        }

        [Fact]
        public void Deve_Retornar_Mensagem_De_Erro_Valor_Acima_Disponivel_Com_Varias_Notas()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(100, 2);

            //Act
            var retorno = caixa.SacarDinheiro(250);

            //Asset
            Assert.Equal(retorno, Caixa.MensagemQuandoNaoEncontrarNotaSuficiente);
        }

        [Fact]
        public void Deve_Retorna_Mensagem_De_Erro_Valor_Acima_Do_Caixa_Com_Duas_Notas()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(100, 2);
            caixa.CadastrarNota(10, 2);

            //Act
            var retorno = caixa.SacarDinheiro(250);

            //Asset
            Assert.Equal(retorno, Caixa.MensagemQuandoNaoEncontrarNotaSuficiente);
        }

        [Fact]
        public void Deve_Retorna_Mensagem_De_Sucesso_Com_Saque_Com_Varias_Notas()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(100, 2);
            caixa.CadastrarNota(50, 2);
            caixa.CadastrarNota(20, 2);
            caixa.CadastrarNota(10, 2);

            //Act
            var retorno = caixa.SacarDinheiro(360);

            //Asset
            var msg = "Valor do Saque: R$360,00 - Resultado Esperado: Entregar 2 nota(s) de R$100,00, 2 nota(s) de R$50,00, 2 nota(s) de R$20,00 e 2 nota(s) de R$10,00.";
            Assert.Equal(msg, retorno);
        }


        [Fact]
        public void Deve_Retorna_Mensagem_De_Sucesso_Com_Saque_Somente_Notas_De_Vinte()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(50, 1);
            caixa.CadastrarNota(20, 4);

            //Act
            var retorno = caixa.SacarDinheiro(80);

            //Asset
            var msg = "Valor do Saque: R$80,00 - Resultado Esperado: Entregar 4 nota(s) de R$20,00.";
            Assert.Equal(msg, retorno);
        }

        [Fact]
        public void Deve_Retorna_Mensagem_De_Sucesso_Com_Saque_Somente_Notas_De_Vinte_E_Dez()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(50, 1);
            caixa.CadastrarNota(20, 1);
            caixa.CadastrarNota(10, 3);

            //Act
            var retorno = caixa.SacarDinheiro(90);

            //Asset
            var msg = "Valor do Saque: R$90,00 - Resultado Esperado: Entregar 1 nota(s) de R$50,00, 1 nota(s) de R$20,00 e 2 nota(s) de R$10,00.";
            Assert.Equal(msg, retorno);
        }

        [Fact]
        public void Deve_Retorna_Mensagem_De_Sucesso_Com_Saque_Valor_Alto()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(100, 8);
            caixa.CadastrarNota(50, 100);
            caixa.CadastrarNota(20, 100);
            caixa.CadastrarNota(10, 100);

            //Act
            var retorno = caixa.SacarDinheiro(1240);

            //Asset
            var msg = "Valor do Saque: R$1.240,00 - Resultado Esperado: Entregar 8 nota(s) de R$100,00, 8 nota(s) de R$50,00 e 2 nota(s) de R$20,00.";
            Assert.Equal(msg, retorno);
        }

        [Fact]
        public void Deve_Retorna_Mensagem_De_Sucesso_Com_Notas_Altas_E_De_Baixo_Valor()
        {
            //Arrange
            var caixa = new Caixa();
            caixa.CadastrarNota(100, 3);
            caixa.CadastrarNota(10, 2);

            //Act
            var retorno = caixa.SacarDinheiro(210);

            //Asset
            var msg = "Valor do Saque: R$210,00 - Resultado Esperado: Entregar 2 nota(s) de R$100,00 e 1 nota(s) de R$10,00.";
            Assert.Equal(msg, retorno);
        }
    }
}