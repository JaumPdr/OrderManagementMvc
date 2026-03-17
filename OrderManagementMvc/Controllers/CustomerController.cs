using Microsoft.AspNetCore.Mvc;
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
            var customers = _context.Customers.ToList();

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
    }
}