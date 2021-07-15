using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TesteMvcCoreEF.Data;
using TesteMvcCoreEF.Models;

namespace TesteMvcCoreEF.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IConfiguration _configuration;

        public PacienteController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: Paciente
        public IActionResult Index()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("PacienteViewAll", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dtbl);
            }

            return View(dtbl);
        }

        // GET: Paciente/Create
        public IActionResult Create()
        {
            return View();
        }

        

        // GET: Paciente/AddOrEdit/5
        public IActionResult AddOrEdit(int? id)
        {
            PacienteViewModel pacienteViewModel = new PacienteViewModel();
            if(id > 0)
            {
                pacienteViewModel = FetchPacienteByID(id);
            }
            return View(pacienteViewModel);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("ProntuarioId,Nome,Sobrenome,DataNascimento,Genero,CPF,RG,Email,Celular,TelefoneFixo,Convenio,CarterinhaConvenio,ValidadeCarterinha")] PacienteViewModel pacienteViewModel)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("PacienteAddOrEdit", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("ProntuarioId", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("Nome", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("Sobrenome", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("DataNascimento", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("Genero", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("CPF", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("RG", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("Email", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("Celular", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("TelefoneFixo", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("Convenio", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("CarterinhaConvenio", pacienteViewModel.ProntuarioId);
                    sqlCmd.Parameters.AddWithValue("ValidadeCarterinha", pacienteViewModel.ProntuarioId);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteViewModel);
        }

        // GET: Paciente/Delete/5
        public IActionResult Delete(int? id)
        {
            PacienteViewModel pacienteViewModel = FetchPacienteByID(id);
            return View(pacienteViewModel);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("PacienteDeleteByID", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("ProntuarioId", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public PacienteViewModel FetchPacienteByID(int? id)
        {
            PacienteViewModel pacienteViewModel = new PacienteViewModel();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                DataTable dtbl = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("PacienteViewByID", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("ProntuarioID", id);
                sqlDa.Fill(dtbl);
                if(dtbl.Rows.Count == 1)
                {
                    pacienteViewModel.ProntuarioId = Convert.ToInt32(dtbl.Rows[0]["ProntuarioID"].ToString());
                    pacienteViewModel.Nome = dtbl.Rows[0]["Nome"].ToString();
                    pacienteViewModel.Sobrenome = dtbl.Rows[0]["Sobrenome"].ToString();
                    pacienteViewModel.DataNascimento = Convert.ToDateTime(dtbl.Rows[0]["DataNascimento"].ToString());
                    pacienteViewModel.Genero = dtbl.Rows[0]["Genero"].ToString();
                    pacienteViewModel.CPF = dtbl.Rows[0]["CPF"].ToString();
                    pacienteViewModel.RG = dtbl.Rows[0]["RG"].ToString();
                    pacienteViewModel.Email = dtbl.Rows[0]["Email"].ToString();
                    pacienteViewModel.Celular = dtbl.Rows[0]["Celular"].ToString();
                    pacienteViewModel.TelefoneFixo = dtbl.Rows[0]["TelefoneFixo"].ToString();
                    pacienteViewModel.Convenio = dtbl.Rows[0]["Convenio"].ToString();
                    pacienteViewModel.ValidadeCarterinha = Convert.ToDateTime(dtbl.Rows[0]["ValidadeCarterinha"].ToString());
                }
                return pacienteViewModel;
            }
        }
    }
}
