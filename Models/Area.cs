using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseBackend.Models;

public class Area
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Garante que o UUID seja gerado automaticamente
    public Guid Id { get; set; }   // Identificador único
    public string Name { get; set; } = string.Empty; // Nome da área
    public string Description { get; set; } = string.Empty; // Descrição da área
}