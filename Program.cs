using Grpc.Net.Client;
using GrpcGreeterClient;
using System.Security.Cryptography.X509Certificates;

class Program
{
	public static async Task Main()
	{
		Console.WriteLine("grpc server");

		Console.WriteLine("chanel");
/*
		var cert = new X509Certificate2("grpccon.pfx", "ssl-2000");
		var handler = new HttpClientHandler();
		handler.ServerCertificateCustomValidationCallback =
	HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
		handler.ClientCertificates.Add(cert);
		var httpClient = new HttpClient(handler);
*/

		var chanel = GrpcChannel.ForAddress("http://localhost:5000");
		Console.WriteLine("client");
		var client = new Greeter.GreeterClient(chanel);
		
		Console.WriteLine("call service");
		var answer = await client.SayHelloAsync(new HelloRequest() { Name = "Client" });
		Console.WriteLine("answer: " + answer.Message);
	}
}