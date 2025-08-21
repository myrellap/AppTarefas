using System.Runtime.InteropServices;
using AppTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTarefas.Controllers
{
    public class TarefasController : Controller
    {
        // Lista em memória(grava as informações apenas quando a aplicação esta rodando)

        private static List<Tarefa> _tarefas = new List<Tarefa>();
        private static int _proximoId = 1;

        // Get: Tarefas
        public IActionResult Index()
        {
            return View(_tarefas); // Envia a lista de tarefas como parametro para a pagina Index.
        }

        // Get: Tarefas/Create
        // Get -> metodo para "pegar" a pagina e exibir
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        [HttpPost] // Especifica que este método responde a requisições POST
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                // Atribui ID único para a tarefa
                tarefa.TarefaId = _proximoId++;
                // Adiciona a tarefa à lista de tarefas
                _tarefas.Add(tarefa);
                return RedirectToAction("Index");
            }
            return View(tarefa);

        }

        // Get: Tarefas/Edit/1
        public IActionResult Edit(int id)
        {
            //var tarefa = Tarefas[id]; // Trabalhando com Lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);
        }

        // POST: Tarefas/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tarefa tarefaatualizada)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);

            tarefa.Titulo = tarefaatualizada.Titulo;
            tarefa.Descrição = tarefaatualizada.Descrição;
            tarefa.Concluida = tarefaatualizada.Concluida;

            return RedirectToAction("Index");
        }

        // Get: Tarefas/Details/1
        public IActionResult Details(int id)
        {
            //var tarefa = Tarefas[id]; // Trabalhando com Lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);
        }

        // Get: Tarefas/Delete/1
        public IActionResult Delete(int id)
        {
            //var tarefa = Tarefas[id]; // Trabalhando com Lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);

        }

        // POST:Tarefas/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa);
            }
            return RedirectToAction("Index");
        }


    }


}


