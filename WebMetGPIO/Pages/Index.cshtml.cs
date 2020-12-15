using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Device.Gpio;

namespace WebMetGPIO.Pages
{
    public class IndexModel : PageModel
    {
        

         private GpioController controller;
         public IndexModel(GpioController controller)
         {
                this.controller=controller;
     
                // Hier ga je de werkelijke output pinnen gaan aansturen           
                this.controller.Write(22, Output22?PinValue.High:PinValue.Low);
                this.controller.Write(25, Output25?PinValue.High:PinValue.Low);

                // Inputs
                this.Input17 = (controller.Read(17) == PinValue.High);
                this.Input27 = (controller.Read(27) == PinValue.Low);
         }


        public void OnGet()
        {
        }

        [BindProperty]
        public bool Output22 { get; set; }

        [BindProperty]
        public bool Output25 { get; set; }

        // Inputs
        public bool Input17 { get; set; }
        public bool Input27 { get; set; }

        public string styleInput17 { get; set; }
        public string styleInput27 { get; set; }

        public void OnPost()
        {  
                // Write naar console
                this.controller.Write(22, Output22?PinValue.High:PinValue.Low);
                this.controller.Write(25, Output25?PinValue.High:PinValue.Low);
                this.Input17 = (controller.Read(17) == PinValue.High);
                this.Input27 = (controller.Read(27) == PinValue.High);
               
                Console.WriteLine($"Output 22 is {Output22}");
                Console.WriteLine($"Output 25 is {Output25}");
                Console.WriteLine($"Input 17 is {Input17}");
                Console.WriteLine($"Input 27 is {Input27}");
        }
    }
}
