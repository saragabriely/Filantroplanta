using Filantroplanta.Mock;
using Filantroplanta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filantroplanta.Controle.Produtor
{
    public class ControleProduto
    {
        public ControleProduto()
        {

        }

        public List<Produto> MockListaProdutos()
        {
            var mock = new MockGeral();
            var listaProdutos = new List<Produto>();

            listaProdutos.Add(mock.MockProduto01());
            listaProdutos.Add(mock.MockProduto02());

            return listaProdutos;
        }

        public void CadastrarProduto(Produto produto)
        {
            
        }

        public void SalvarProduto(Produto produto)
        {

        }
    }
}
