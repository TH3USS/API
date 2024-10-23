using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context){
            _context = context; //falando que o _context é o banco
        }

        [HttpPost]
        public IActionResult Create(Contato contato){
            _context.Add(contato); //adicionando um contato no banco
            _context.SaveChanges(); //salvando
            return CreatedAtAction(nameof(ObterPorId), new {id = contato.Id}, contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id){
            var contato = _context.Contatos.Find(id); //encontrando um contato pelo id

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome){
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome)); //encontrando um contato pelo id
            return Ok(contatos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato){
            var contatoBanco = _context.Contatos.Find(id); //encontrando um contato pelo id
            
            if (contatoBanco == null)
                return NotFound();
            
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco); //atualizando um contato
            _context.SaveChanges();

            return Ok(contato);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){
            var contatoBanco = _context.Contatos.Find(id); //encontrando um contato pelo id
            
            if (contatoBanco == null)
                return NotFound();
            
            _context.Contatos.Remove(contatoBanco); //deleta um contato
            _context.SaveChanges();
            return NoContent(); //diz que não precisa de retorno
        }
    }
}