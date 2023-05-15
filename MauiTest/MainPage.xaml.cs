using Android.Net.Http;
using Grpc.Net.Client;
using GrpcClient;

namespace MauiTest;

public partial class MainPage : ContentPage
{
	const string testUrl = "https://YOURAPP.azurewebsites.net";

	public MainPage()
	{
		InitializeComponent();
	}

	async void GrpcTest_Clicked(object sender, EventArgs e)
	{
		var channel = GrpcChannel.ForAddress(testUrl);
		var client = new Greeter.GreeterClient(channel);
		try
		{
			var response = await client.SayHelloAsync(new HelloRequest() { Name = "TEST" });
			await DisplayAlert("RESPONSE", response.Message, "OK");
		}
		catch (Exception ex)
		{
			await DisplayAlert("EXCEPTION", ex.ToString(), "OK");
		}
	}

	async void Http2Test_Clicked(object sender, EventArgs e)
	{
		var client = new HttpClient();
		try
		{
			string? response = await client.GetStringAsync(testUrl+"/test");
			await DisplayAlert("RESPONSE", response ?? "", "OK");

		}
		catch (Exception ex)
		{
			await DisplayAlert("EXCEPTION", ex.ToString(), "OK");
		}
	}
}