using aspnetcrud8.Data;
using aspnetcrud8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetcrud8.Controllers
{
    public class PessoaController : Controller
    {
        private readonly Tessoacontexto _context;
        private readonly ILogger<PessoaController> _logger;
        public PessoaController(Tessoacontexto context, ILogger<PessoaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Pessoa
        public async Task<IActionResult> Index()
        {
            var pessoas = await _context.pessoas.ToListAsync();
            return View(pessoas); // Certifique-se de ter uma View associada a essa ação.
        }

        // GET: Pessoa/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var pessoa = await _context.pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoa/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // GET: Pessoa/Create
        [HttpGet]


        // POST: Pessoa/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            //if (!ModelState.IsValid)
            //{
            //    // Retorna erro de validação com status 400 (Bad Request)
            //    return BadRequest(new
            //    {
            //        success = false,
            //        message = "Falha ao criar pessoa. Dados inválidos.",
            //        errors = ModelState.Values
            //            .SelectMany(v => v.Errors)
            //            .Select(e => e.ErrorMessage)
            //    });
            //}

            try
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                //Retorna sucesso com status 201(Created)
                return CreatedAtAction(nameof(Details), new { id = pessoa.Id }, new
                {
                    success = true,
                    message = "Pessoa criada com sucesso!",
                    data = pessoa
                });
            }
            catch (DbUpdateException dbEx)
            {
                // Loga o erro relacionado ao banco (use um logger real em vez de Console)
                Console.Error.WriteLine($"Erro ao salvar pessoa no banco de dados: {dbEx.Message}");

                // Retorna erro relacionado ao banco com status 500 (Internal Server Error)
                return StatusCode(500, new
                {
                    success = false,
                    message = "Erro ao salvar dados no banco. Por favor, tente novamente."
                });
            }
            catch (Exception ex)
            {
                // Loga o erro geral
                Console.Error.WriteLine($"Erro ao criar pessoa: {ex.Message}");

                // Retorna erro interno do servidor com status 500
                return StatusCode(500, new
                {
                    success = false,
                    message = "Falha ao criar pessoa. Por favor, tente novamente mais tarde."
                });
            }
        }
        // GET: Pessoa/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pessoa = await _context.pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }


        [HttpPost]
        public IActionResult Editar(Pessoa pessoa)
        {
            var pessoaDb = _context.pessoas.Find(pessoa.Id);
            if (pessoaDb != null)
            {
                pessoaDb.Name = pessoa.Name;
                _context.SaveChanges();
                return Json(new { success = true }); // Retorna sucesso 
            }
            return Json(new { success = false, redirectUrl = Url.Action("Index", "Pessoa") }); // Redireciona para a página principal após sucesso
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Excluir(int id)
        {
            var pessoa = _context.pessoas.Find(id);
            if (pessoa != null)
            {
                _context.pessoas.Remove(pessoa);
                _context.SaveChanges();
                return Json(new { success = true }); // Retorna sucesso
            }
            return Json(new { success = false, message = "Pessoa não encontrada" });
        }


    }
}
