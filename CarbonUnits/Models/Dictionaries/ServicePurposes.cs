﻿using System.ComponentModel.DataAnnotations;
namespace CarbonUnits.Models.Dictionaries
{
    public class ServicePurposes
    {
        public int Id { get; set; }
        public ServiceCodes ServiceCodes { get; set; }
        public int ServiceCodesId { get; set; }//Ссылка на родительский код услуги

        [MaxLength(20)]
        public string ServicePurposeCode { get; set; }//Код цели услуги
        [MaxLength(4000)]
        public string Description { get; set; }//Описание цели услуги
        public IODocumentsTypes IODocumentsTypes { get; set; }//
        public int? IODocumentsTypesID { get; set; }//Ссылка на справочник типов документов
    }
}
