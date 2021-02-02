using Microsoft.AspNetCore.Mvc;
using Sistema.ServiceDesk.Data;
using Sistema.ServiceDesk.Data.Context;
using Sistema.ServiceDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.ServiceDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentosController : ControllerBase
    {

        [HttpGet("DeltaLog")]
        public ActionResult<TblDeltaLog> DeltaLogSearch([FromQuery] GetDeltaLogModels request)
        {
            if (request.imei <= 0) { return BadRequest($"Imei \"{request.imei}\" invalido !"); }
            if (request.placa == null) { return BadRequest("O campo placa deve ser preenchido !"); }
            if (request.shift == null) { return BadRequest("O campo Shift deve ser preenchido !"); }

            using (var context = new _Context())
            {
                var Search = context.AtendimentosDeltaLog.Where(x => x.shift.Contains(request.shift)).FirstOrDefault();
                if (Search == null)
                {
                    return NotFound("Valores digitado não foram encontrados!");
                }
                return context.AtendimentosDeltaLog.Where(x => x.shift.Contains(request.shift)).FirstOrDefault();
            }
        }


        [HttpGet("Geral")]
        public ActionResult<TblGeral> GeralSearch([FromQuery]GetGeralModels request)
        {
            if (request.analista == null) { return BadRequest("O campo analista não foi preenchido"); }
            if (request.nomeDoUsuario == null) { return BadRequest("O campo nome do Usuario não foi preenchido"); }
            if (request.ticket <= 0) { return BadRequest($"O valor {request.ticket} é inválido"); }

            using (var context = new _Context())
            {
                var Search = context.AtendimentosGerais.Where(x => x.analista.Contains(request.analista)).FirstOrDefault();
                if (Search == null)
                { 
                    return NotFound("Valores digitado não foram encontrados!");
                }

                return context.AtendimentosGerais.Where(x => x.analista.Contains(request.analista)).FirstOrDefault();
            }
            
        }


        [HttpPost("DeltaLog")]
        public ActionResult<TblDeltaLog> DeltaLogIncluir(PostDeltaLogModels request)
        {
            if (string.IsNullOrEmpty(request.motorista)) { return BadRequest("Campo Obrigatório, Favor digitar o nome do Motorista: "); }
            if (string.IsNullOrEmpty(request.shift)) { return BadRequest("Campo Obrigatório, Favor digitar o Numero da Shift: "); }
            if (string.IsNullOrEmpty(request.placa)) { return BadRequest("Campo Obrigatório, Favor digitar a Placa: "); }
            if (request.imei <= 0) { return BadRequest("Imei Invalido, Digte um Imei Válido para prosseguir:"); }
            if (string.IsNullOrEmpty(request.analista)) { return BadRequest("Campo Obrigatório, Favor digitar o nome do Analista em atadimento: "); }
            if (string.IsNullOrEmpty(request.problema)) { return BadRequest("Campo Obrigatório, Favor digitar o problema atual no App: "); }

            using (var context = new _Context())
            {
                var Save = new TblDeltaLog();

                Save.imei = request.imei;
                Save.motorista = request.motorista;
                Save.placa = request.placa;
                Save.problema = request.problema;
                Save.shift = request.shift;
                Save.acao = request.acao;
                Save.analista = request.analista;

                context.Add(Save);
                context.SaveChanges();
            }
            return Ok("Inclusão de dados salvo com Sucesso!");
        }

        [HttpPost("Geral")]
        public ActionResult<TblGeral> GeralIncluir(PostGeralModels request)
        {

            using (var context = new _Context())
            {
                if (string.IsNullOrEmpty(request.analista)) { return BadRequest("O campo \"Analista\" é obrigatório, favor preencher !"); }
                if (string.IsNullOrEmpty(request.nomeDoUsuario)) { return BadRequest("o campo \"Nome do usuario\" é obrigatório, Favor preencher !"); }
                if (string.IsNullOrEmpty(request.descricao)) { return BadRequest("o campo \"Descrição\" é obrigatório, Favor preencher !"); }

                var Validator = context.Filiais.Where(x => x.filial == request.filial).FirstOrDefault();
                if(Validator == null) {return NotFound($"Filial \"{request.filial}\" não encontrada !");}

                var Save = new TblGeral();

                Save.analista = request.analista;
                Save.descricao = request.descricao;
                Save.nomeDoUsuario = request.nomeDoUsuario;
                Save.filial = request.filial;
                Save.ticket = request.ticket;

                context.Add(Save);
                context.SaveChanges();
            }
            return Ok("Inclusão de dados salvo com Sucesso!");
        }


        [HttpPut("Geral")]
        public ActionResult <TblGeral> GeralPut(PutGeralModels request)
        {
            using(var context = new _Context())
            {
                var Validator = context.Filiais.Where(x => x.filial == request.filial).FirstOrDefault();
                if (Validator == null) { return NotFound($"Filial \"{request.filial}\" não encontrada !"); }

                var Update = context.AtendimentosGerais.Where(x => x.id == request.id).FirstOrDefault();
                if(Update == null){return NotFound($"O id \"{request.id}\" digitado, não foi encontrado!");}

                Update.analista = request.analista;
                Update.nomeDoUsuario = request.nomeDoUsuario;
                Update.filial = request.filial;
                Update.ticket = request.ticket;
                Update.descricao = request.descricao;

                context.SaveChanges();
            }
            return Ok($"Os dados do id \"{request.id}\" foram substituidos com sucesso !");
        }


        [HttpPut("DeltaLog")]
        public ActionResult<TblDeltaLog> DeltaLogPut(PutDeltaLogModels request)
        {
            using (var context = new _Context())
            {
                var Update = context.AtendimentosDeltaLog.Where(x => x.id == request.id).FirstOrDefault();
                if (Update == null)
                {
                    return NotFound($"O id \"{request.id}\" digitado, não foi encontrado!");
                }
                Update.motorista = request.motorista;
                Update.shift = request.shift;
                Update.placa = request.placa;
                Update.imei = request.imei;
                Update.analista = request.analista;
                Update.problema = request.problema;
                Update.acao = request.acao;

                context.SaveChanges();
            }
            return Ok($"Os dados do id \"{request.id}\" foram substituidos com sucesso !");
        }


        [HttpDelete("DeltaLog")]
        public ActionResult<TblDeltaLog> DeltaLogDelete(DeleteDeltaLogModels request)
        {
            using (var context = new _Context())
            {
                var Delete = context.AtendimentosDeltaLog.Where(x => x.id == request.id).FirstOrDefault();
                if (Delete == null)
                {
                    return NotFound($"Id \"{request.id}\" Não foi encontrado!");
                }
                context.Remove(Delete);
                context.SaveChanges();
            }
            return Ok($"Os dados do id \"{request.id}\" foram deletados com sucesso !" );
        }

        [HttpDelete("Geral")]
        public ActionResult<TblGeral> GeralDelete(DeleteGeralModels request)
        {
            using (var context = new _Context())
            {
                var Delete = context.AtendimentosGerais.Where(x => x.id == request.id).FirstOrDefault();
                if(Delete == null)
                {
                    return NotFound($"Id \"{request.id}\" Não foi encontrado!");
                }
                context.Remove(Delete);
                context.SaveChanges();
            }
            return Ok($"Os dados do id \"{request.id}\" foram deletados com sucesso !");
        }
    }
}
