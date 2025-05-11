using System.ComponentModel.DataAnnotations;

namespace Demo.persentationLayer.viewModels
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
