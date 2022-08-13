using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dogukan_Kisecuklu_Hafta_1.Controllers
{
    public class Interest // interest class'ını oluşturuldu
    {
        [Required(ErrorMessage = "Please enter a number")] // Değer girilmesi istendi
        [Range(0,double.MaxValue,ErrorMessage ="Invalid number please do not enter negative number")] //Kullanıcıdan negatif değer girilmemesi istendi
        public double interestRate { get; set; } // Faiz oranı

        [Required(ErrorMessage = "Please enter a number")] // Değer girilmesi istendi
        [Range(0, double.MaxValue, ErrorMessage = "Invalid number please do not enter negative number")] //Kullanıcıdan negatif değer girilmemesi istendi
        public double balance { get; set; } // Para

        [Required(ErrorMessage = "Please enter a number")] // Değer girilmesi istendi
        [Range(0, double.MaxValue, ErrorMessage = "Invalid number please do not enter negative number")]//Kullanıcıdan negatif değer girilmemesi istendi
        public double time { get; set; } // Zaman
    }
    public class Result // Sonucu göstermek için result classı oluşturuldu
    {
      public double InterestAmount { get; set; } // Faizden önce ana para
      public double TotalBalance { get; set; } // Faizden sonra ana para 
    }
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundRateController : ControllerBase
    {
        

        public CompoundRateController()
        {
            //Boş bir constructor oluşturdum.
        }

        [HttpGet("GetCompoundRate")]
        public ActionResult<Result> Get([FromQuery] Interest input)// Interest tipinde input alınarak para,faiz,zaman alındı
        {
            Result result = new(); // Yeni bir result oluşturuldu
            result.TotalBalance = input.balance * Math.Pow((1 + input.interestRate), input.time); // Formül uygulanarak bileşik faiz hesaplandı
            result.InterestAmount = result.TotalBalance-input.balance;// Faizden önceki ana para
            return result; // Response'da faiz sonucu döndürüldü.
        }
        

    }
}
