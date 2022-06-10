using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAuthors.validations;

namespace WebApiAuthors.Controllers.entities
{
    public class Author: IValidatableObject
    {
        public int id { get; set; }

        [Required (ErrorMessage ="el campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "el nombre debe tener como maximo {1} caracteres")]
        public string name { get; set; }

        //[Range(18,120)]
        //[NotMapped]
        //public int age { get; set; }

        //[CreditCard]
        //[NotMapped]
        //public string creditCard { get; set; }

        //[Url]
        //[NotMapped]
        //public string URL { get; set; }

        public List<book> books { get; set; }

        //public int lesser { get; set; }

        //public int bigger { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if(!string.IsNullOrEmpty(name))
            {
                var firstLetter = name[0].ToString();
                if (firstLetter != firstLetter.ToUpper()) yield return new ValidationResult("La primera letra deber ser mayuscula",
                    new string[] {nameof(name)});

                //if (lesser > bigger) yield return new ValidationResult("este valor no puede ser mas alto que el campo mayor",
                //    new string[] { nameof(lesser) });
            }
        }
    }
}
