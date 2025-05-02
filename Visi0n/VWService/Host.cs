using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
//using CoreWCfDemoServer;

namespace VWS
{
    public class Host
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add WSDL support
            builder.Services.AddServiceModelServices().AddServiceModelMetadata();
            builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

            var app = builder.Build();

            // Configure an explicit none credential type for WSHttpBinding as it defaults to Windows which requires extra configuration in ASP.NET
            var myWSHttpBinding = new WSHttpBinding(SecurityMode.Transport);
            myWSHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

            app.UseServiceModel(builder =>
            {
                builder.AddService<VisionService>((serviceOptions) => { })
                // Add a BasicHttpBinding at a specific endpoint
                .AddServiceEndpoint<VisionService, IVisionService>(new BasicHttpBinding(), "/VisionService/basichttp")
                // Add a WSHttpBinding with Transport Security for TLS
                .AddServiceEndpoint<VisionService, IVisionService>(myWSHttpBinding, "/VisionService/WSHttps");
            });

            var serviceMetadataBehavior = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
            serviceMetadataBehavior.HttpGetEnabled = true;

            app.Run();
        }
    }
}