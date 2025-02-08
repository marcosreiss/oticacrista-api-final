using System.ComponentModel.DataAnnotations;
using OticaCrista.Models.Enums;
using OticaCrista.Models.Sale;

namespace OticaCrista.Models
{
    public class ClientModel
    {
        #region Identification
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Cpf { get; set; } = string.Empty;

        public string? Rg { get; set; }
        #endregion

        #region Contact Information
        public string PhoneNumber1 { get; set; } = string.Empty;
        public string PhoneNumber2 { get; set; } = string.Empty;
        public string PhoneNumber3 { get; set; } = string.Empty;

        public string? EmailAddress { get; set; }
        #endregion

        #region References
        public string ReferenceName1 { get; set; } = string.Empty;
        public string ReferencePhone1 { get; set; } = string.Empty;

        public string ReferenceName2 { get; set; } = string.Empty;
        public string ReferencePhone2 { get; set; } = string.Empty;

        public string ReferenceName3 { get; set; } = string.Empty;
        public string ReferencePhone3 { get; set; } = string.Empty;
        #endregion

        #region Personal Information
        public DateOnly BornDate { get; set; }
        public Gender Gender { get; set; }

        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? SpouseName { get; set; }
        #endregion

        #region Employment Information
        public string? Company { get; set; }
        public string? Ocupation { get; set; }
        #endregion

        #region Address
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? Uf { get; set; }
        public string? Cep { get; set; }
        public string? AddressComplement { get; set; }
        #endregion

        #region Status and Observations
        public bool Negativated { get; set; }
        public string? Observation { get; set; }
        #endregion

        #region Relations
        public ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();
        #endregion
    }
}