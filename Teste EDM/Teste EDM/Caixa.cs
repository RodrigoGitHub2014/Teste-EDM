using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teste_EDM
{
    public class Caixa
    {        
        private List<Nota> notasCadastradas = new List<Nota>();
        private List<Nota> notasSeraoSacadas = new List<Nota>();
        private List<Nota> notasCadastradasClone = null;
        private List<Nota> notasSeraoSacadasClone = null;

        private bool valorAbaixoOuIgualA100 = false;
        private int valorClone = 0;
        private int contadorAnterior = 0;
        private int contador = 0;

        public int[] notasValores = { 100, 50, 20, 10 };
        public const string MensagemQuandoNaoEncontrarNotaSuficiente = "O Caixa não tem notas suficiente para realizar o saque";

        public string SacarDinheiro(int valorSaque)
        {            
            var nota = notasCadastradas.FirstOrDefault(n => valorSaque >= n.Valor && n.Quantidade >= 1);
           
            if (nota == null)
                return MensagemQuandoNaoEncontrarNotaSuficiente;

            var valor = valorSaque;            

            while(contador < notasValores.Length)
            {
                var notaCadastrada = notasCadastradas.Find(n => n.Valor == notasValores[contador] && n.Quantidade >= 1);

                if (valor <= 100 && !valorAbaixoOuIgualA100)
                    GuardarEstadoAtual(contador, valor);

                if (notaCadastrada != null && notaCadastrada.Valor <= valor)                                    
                    valor = Calcular(notaCadastrada, valor);

                if (valor == 0)
                    break;

                if (contador == notasValores.Length - 1 && valor > 0)
                {
                    if (contadorAnterior + 1 >= notasValores.Length) break;

                    var dados = RetornarProximoPasso();
                    valor =  dados.Valor;
                    contador = dados.Contador;
                }
                else
                {
                    contador++;
                }
            }

            return valor != 0 ? MensagemQuandoNaoEncontrarNotaSuficiente : RetornarMensagem(valorSaque);
        }        

        private void GuardarEstadoAtual(int contador, int valor)
        {
            notasCadastradasClone = notasCadastradas.ConvertAll(x => x.Clone());
            notasSeraoSacadasClone = notasSeraoSacadas.ConvertAll(x => x.Clone());                       
            valorAbaixoOuIgualA100 = true;
            contadorAnterior = contador;
            valorClone = valor;
        }

        private (int Contador, int Valor) RetornarProximoPasso()
        {            
            notasCadastradas = notasCadastradasClone;
            notasSeraoSacadas = notasSeraoSacadasClone;            
            contador = contadorAnterior + 1;
            valorAbaixoOuIgualA100 = false;
            return (contador, valorClone);
        }

        private string RetornarMensagem(int valorSaque)
        {
            var msg = new StringBuilder($"Valor do Saque: R${valorSaque.ToString("N2")} - Resultado Esperado: Entregar ");

            var agrupamento = notasSeraoSacadas.GroupBy(x => x.Valor);

            int posicaoInicial = 1;
            int posicaoFinal = agrupamento.Count();

            foreach (var item in agrupamento)
            {
                var mensagem = $"{item.Count()} nota(s) de R${item.Key.ToString("N2")}";                               
                msg.Append(FormatarMensagem(mensagem, posicaoInicial, posicaoFinal));
                posicaoInicial++;
            }

            return msg.ToString();
        }

        private string FormatarMensagem(string mensagem, int posicaoInicial, int posicaoFinal)
        {
            if (posicaoInicial == posicaoFinal)
                mensagem += ".";
            else if (posicaoInicial == posicaoFinal - 1)
                mensagem += " e ";
            else
                mensagem += ", ";

            return mensagem;
        }

        private int Calcular(Nota nota, int valor)
        {
            do
            {
                if (valor >= nota.Valor)
                {
                    nota.SacarNota();
                    valor = valor - nota.Valor;
                    notasSeraoSacadas.Add(nota);
                }

            } while (valor > 0 && valor >= nota.Valor && nota.Quantidade > 0);

            return valor;
        }

        public bool CadastrarNota(int valor, int quantidade)
        {
            if (!notasValores.Contains(valor))
                return false;

            var nota = new Nota() 
            { 
                Valor = valor, 
                Quantidade = quantidade 
            };
            
            notasCadastradas.Add(nota);

            return true;
        }
    }
}
