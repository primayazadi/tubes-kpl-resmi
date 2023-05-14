using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using tubesbackuup;

namespace tubesbackuup
{
    public class RuntimeConfig_rafkha_//mengubah nama user
    {
         public string Name { get; set; } 
    } 
    
       
    public class RuntimeConfigu
    {
    public RuntimeConfig_rafkha_ config = new RuntimeConfig_rafkha_();

        public void changeConfiguration()
        {
            Console.WriteLine("Enter your new name: ");
            string name = Console.ReadLine();

            config.Name = name;

            
            Console.WriteLine($"Wellcome {name}");
            
        }
    }

}
