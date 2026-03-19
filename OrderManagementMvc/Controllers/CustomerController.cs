using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementMvc.Data;
using OrderManagementMvc.Models;

namespace OrderManagementMvc.Controllers
{
    public class CustomerController : Controller
    {
        // Campo privado e readonly para armazenar o DbContext
        // Ele será injetado automaticamente pelo ASP.NET
        private readonly AppDbContext _context;

        // Construtor responsável por receber o DbContext via Injeção de Dependência
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // Action responsável por listar os clientes
        public IActionResult Index()
        {
            // Busca todos os clientes no banco de dados
            // AsNoTracking melhora performance para leitura
            var customers = _context.Customers.AsNoTracking().ToList();

            // Envia a lista para a View
            return View(customers);
        }

        // Action GET → apenas exibe o formulário
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Action POST → recebe os dados do formulário
        [HttpPost]
        [ValidateAntiForgeryToken] // Proteção contra CSRF
        public IActionResult Create(Customer customer)
        {
            // Verifica se os dados recebidos são válidos
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            // Adiciona o cliente no contexto (memória)
            _context.Customers.Add(customer);

            // Salva no banco de dados
            _context.SaveChanges();

            // Redireciona para a lista de clientes
            return RedirectToAction("Index");
        }

        // Busca o cliente pelo ID e envia para a View
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Busca o cliente no banco
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            // Se não encontrar, retorna erro 404
            if (customer == null)
            {
                return NotFound();
            }

            // Envia o cliente para preencher o formulário
            return View(customer);
        }

        // Atualiza os dados do cliente
        [HttpPost]
        [ValidateAntiForgeryToken]// Proteção contra CSRF
        public IActionResult Edit(int id, Customer customer)
        {
            // Garante que o ID da URL é o mesmo do objeto
            if (id != customer.Id)
            {
                return BadRequest();
            }

            // Valida os dados
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            // Busca o cliente no banco
            var customerDb = _context.Customers.FirstOrDefault(c => c.Id == id);

            // Se não encontrar, retorna 404
            if (customerDb == null)
            {
                return NotFound();
            }

            // Atualiza apenas os campos necessários (evita overposting)
            customerDb.Name = customer.Name;
            customerDb.Email = customer.Email;
            customerDb.Telefone = customer.Telefone;
            customerDb.Cpf = customer.Cpf;

            // Salva alterações
            _context.SaveChanges();

            // Redireciona para a listagem
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        // Confirma a exclusão
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            
            if (customer == null)
            {
                return NotFound();
            }

            //Remove o cliente
            _context.Customers.Remove(customer);

            //Salva no Banco de Dados
            _context.SaveChanges();

            // Redireciona para a listagem
            return RedirectToAction("Index");
        }




    }
}