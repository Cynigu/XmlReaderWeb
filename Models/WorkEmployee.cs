namespace Models
{
    /// <summary>
    /// Рабочая среда - у одного сотрудника может быть несколько работ
    /// </summary>
    public class WorkEmployee
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float BetForObject { get; set; }// Ставка за объект
        public ushort CountFactObject { get; set; }// Количество размеченных объектов
        public ushort CountFactFiles { get; set; } // Кол-во размеченных файлов
        public ushort CountPlanFiles { get; set; } // Кол-во запланируемых для разметки фалйов
        public DateTime DateStart { get; set; } // Дата начала 
        public DateTime DateEnd { get; set; } // Дата окончания
        public float SalaryFact => BetForObject * CountFactObject; // Зарплата фактическая
        public bool IsGetSalary { get; set; }
        public bool IsEnd { get; set; }
        public ICollection<Folder> Folders { get; set; }
    }
}
