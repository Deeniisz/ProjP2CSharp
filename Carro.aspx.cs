using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjGaragem
{
    public partial class Carro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            string valor = Request.QueryString["idItem"];
            string idItem = "";
            TB_CARRO carro = new TB_CARRO();
            GaragemDBEntities1 context = new GaragemDBEntities1();
            List<TB_CARRO> lstCarro = context.TB_CARRO.ToList<TB_CARRO>();
            GVCarro.DataSource = lstCarro;
            GVCarro.DataBind();

            if (!String.IsNullOrEmpty(valor))
            {
                idItem = valor;
                carro = context.TB_CARRO.First(c => c.Id == idItem);

                txtMarca.Text = carro.Marca;
                txtModelo.Text = carro.Modelo;
                txtRenavam.Text = carro.Renavam;
            }
        }
        protected void GVCarro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string idItem = e.CommandArgument.ToString();
            GaragemDBEntities1 contextCliente = new GaragemDBEntities1();
            TB_CARRO carro = new TB_CARRO();

            carro = contextCliente.TB_CARRO.First(c => c.Id == idItem);

            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Carro.aspx?idItem=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                contextCliente.TB_CARRO.Remove(carro);
                contextCliente.SaveChanges();
                CarregarDados();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String Id = c.Text;
            string Marca = txtMarca.Text;
            string Modelo = txtModelo.Text;
            string Renavam = txtRenavam.Text;
            TB_CARRO v = new TB_CARRO() { Id = Id, Marca = Marca, Modelo = Modelo, Renavam = Renavam };
            GaragemDBEntities1 context = new GaragemDBEntities1();
            string valor = Request.QueryString["idItem"];
            if (String.IsNullOrEmpty(valor))
            {
                context.TB_CARRO.Add(v);
                CarregarDados();
            }
            else
            {
                string id = valor;
                TB_CARRO carro = context.TB_CARRO.First(c => c.Id == id);
                carro.Marca = v.Marca;
                carro.Modelo = v.Modelo;
                carro.Renavam = v.Renavam;
            }
            context.SaveChanges();
            CarregarDados();
            Clear();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        private void Clear()
        {
            c.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtRenavam.Text = "";
        }
    }
}
