using System;

namespace CaseBackend.Models
{
    public class Processo
    {
        public Guid Id { get; set; }  // Identificador único (UUID)
        public string Name { get; set; } = string.Empty;  // Nome do processo
        public string? Description { get; set; }  // Descrição do processo (Opcional)
        public string Tools { get; set; } = string.Empty;  // Ferramentas usadas no processo
        public string Responsables { get; set; } = string.Empty;  // Responsáveis pelo processo
        public string Documentation { get; set; } = string.Empty;  // Documentação relacionada
        public Guid? ProcessoParentId { get; set; }  // ID do processo pai (UUID, nullable)

        public Guid AreaId { get; set; }  // ID da área (obrigatório)
        public virtual Area? Area { get; set; }
    }
}
