using Crud.Dao;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {

        //Página inicial com a lista de cliente
        public ActionResult Index()
        {
            List<Cliente> clientes = ClienteDao.ListarClientes();

            return View(clientes);
        }
        //-----------------------------------------------------------------------------------


        // Incluir ---------------------------------------------------------------------------
        //GET
        public ActionResult IncluirCliente()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IncluirCliente(Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                return View(cliente); // Campos com preechimento inválido. Retorna para o formulário
            }
            else
            {

                ClienteDao.CadastrarCliente(cliente); // insere no banco de dados os campos do formulário
                return RedirectToAction("Index", "Home"); // redireciona para a index
            }

        }
        //---------------------------------------------------------------------------------------

        //  CONSULTAR ----------------------------------------------------------------------------------     
        public ActionResult ConsultarCliente(int id)
        {

            Cliente cliente = ClienteDao.ConsultarClientePorId(id);

            return View(cliente);
        }
        // -----------------------------------------------------------------------------------------------

        //Alterar --------------------------------------------------------------------------------------
        //GET
        public ActionResult AlterarCliente(int id)
        {

            Cliente cliente = ClienteDao.ConsultarClientePorId(id);

            return View(cliente);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarCliente(Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                return View(cliente); // Campos com preechimento inválido. Retorna para o formulário
            }
            else
            {

                ClienteDao.AtualizarCliente(cliente); // atualiza no banco de dados os campos do formulário
                return RedirectToAction("Index", "Home"); // redireciona para a index
            }

        }
        public ActionResult ExcluirCliente(int id)
        {

            Cliente cliente = ClienteDao.ConsultarClientePorId(id);

            return View(cliente);
        }

        //POST
        [HttpPost]
        public ActionResult ExcluirCliente(Cliente cliente)
        {
            ClienteDao.ExcluirCliente(cliente.IdCliente); // exclui no banco de dados 
            return RedirectToAction("Index", "Home"); // redireciona para a index


        }
    }
}