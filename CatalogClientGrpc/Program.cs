using Grpc.Net.Client;
using CatalogClientGrpc.Protos;

var words = new List<string>() { "red", "yellow", "green" };

using var channel = GrpcChannel.ForAddress("https://localhost:7240");

var client = new Translator.TranslatorClient(channel);

foreach (var word in words)
{
    Request request = new Request { Word = word };
    Response response = await client.TranslateAsync(request);
    Console.WriteLine($"{response.Word} : {response.Translation}");
}

