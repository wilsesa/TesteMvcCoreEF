using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteMvcCoreEF.Models
{
    public class PacienteViewModel
    {
        [Key]
        public int ProntuarioId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatorio")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo data de nascimento é obrigatorio")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatorio")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatorio")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatorio")]
        [EmailAddress(ErrorMessage = "Formato do email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo celular é obrigatorio")]
        public string Celular { get; set; }

        public string TelefoneFixo { get; set; }

        [Required(ErrorMessage = "O campo convenio é obrigatorio")]
        public string Convenio { get; set; }

        [Required(ErrorMessage = "O campo carterinha convenio é obrigatorio")]
        public string CarterinhaConvenio { get; set; }

        [Required(ErrorMessage = "O campo valide da carterinha é obrigatorio")]
        [DataType(DataType.Date)]
        public DateTime ValidadeCarterinha { get; set; }
    }
}
