using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiQwen25vl.Aplicacao.Dto
{
    [Table("Tenant")]
    public class TenantDto
    {
        //[Key]
        //[Column("Id")]
        //[Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        //[Column("Nome")]
        //[MaxLength(150)]
        //[Required]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        //[Column("Dominio")]
        //[MaxLength(100)]
        //[Required]
        [Required(ErrorMessage = "O campo Domínio é obrigatório.")]
        public string Dominio { get; set; } = string.Empty;

        //[Column("Ativo")]
        //[Required]
        public bool Ativo { get; set; } = true;

        public ICollection<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();
    }
}
