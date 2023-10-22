using Filantroplanta.Views.Componentizacao.Botao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filantroplanta.Controle
{
    public class ControleComponentizacao
    {
        public string NomeBotaoSalvar   = "btnCadastrarSalvar";
        public string NomeBotaoCancelar = "btnCancelarVoltar";
        public string NomeBotaoExcluirRecusar = "btnExcluirRecusar";
        public BotoesCancelarSalvar btnCancelarSalvar = new BotoesCancelarSalvar();
        public BotaoExcluirRecusar  btnExcluirRecusar = new BotaoExcluirRecusar();
        public ControleComponentizacao() { }

        public Button BuscarBotaoCancelarOuSalvar(string botao)
        {
            if(botao.Equals("Salvar"))
                return btnCancelarSalvar.FindByName<Button>(this.NomeBotaoSalvar);
            else
                return btnCancelarSalvar.FindByName<Button>(this.NomeBotaoCancelar);
        }
    }
}
