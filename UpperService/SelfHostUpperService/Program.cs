using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using UpperServiceLibrary;

namespace SelfHostUpperService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceSelfHostUpperLibrary = null;

            try
            {
                #region main_implementation

                Uri baseAddress = new Uri("http://localhost:4444/UpperService");
                serviceSelfHostUpperLibrary = new ServiceHost(typeof(UpperService), baseAddress);


                //serviceSelfHostUpperLibrary.AddServiceEndpoint(
                //    typeof(IUpperService),
                //    new BasicHttpBinding(),
                //    "http://localhost:2222/MathService");

                //serviceSelfHostCalcLibrary.AddServiceEndpoint(
                //    typeof(ICalcService),
                //    new BasicHttpBinding(),
                //    "http://localhost:5555/CalcService");

                
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                serviceSelfHostUpperLibrary.Description.Behaviors.Add(smb);
                serviceSelfHostUpperLibrary.Open();
                
                

                Console.WriteLine("Hosting serwisów został uruchomiony.");
                Console.WriteLine("Serwisy nasłuchują żądań klientów na poniższych adresach: ");
                Console.WriteLine();

                foreach (var serviceSelfHostEndpoint in serviceSelfHostUpperLibrary.Description.Endpoints)
                {
                    Console.WriteLine(
                        $"Adres: {serviceSelfHostEndpoint.Address} Wiązanie {serviceSelfHostEndpoint.Binding.Name}");
                }

               

                Console.WriteLine();
                Console.WriteLine("Naciśnięcie dowolnego klawisza zakończy pracę programu");
                Console.ReadKey();

                serviceSelfHostUpperLibrary.Close();
                #endregion
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            finally
            {
                if (serviceSelfHostUpperLibrary != null && serviceSelfHostUpperLibrary.State == CommunicationState.Opened)
                    serviceSelfHostUpperLibrary.Close();
 
            }

        }
    }
}
