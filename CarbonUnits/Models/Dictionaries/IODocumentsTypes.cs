﻿using System.ComponentModel.DataAnnotations;
namespace CarbonUnits.Models.Dictionaries
{
    public class IODocumentsTypes
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(4000)]
        public string Name { get; set; }
        public bool isIn { get; set; }//true входящий документ, false исходящий
        [MaxLength(20)]
        public string Process { get; set; }//Процесс исполнения документа.Код инициируемого процесса по исполнению входящего документа.
    }
}
