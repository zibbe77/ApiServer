using System.Text.Json;
WebApplication app = WebApplication.Create();

app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://*:3000");

MangaPro manga = new();

//läser in data 
//List<MangaPro> mangaList = new();

string contents = File.ReadAllText(@"Manga copy.json");
List<MangaPro> mangaList = JsonSerializer.Deserialize<List<MangaPro>>(contents);


//mangaList.Add(new() { Manga = "sss" });
//mangaList.Add(new() { Manga = "bbb" });


app.MapGet("/", Answer);
app.MapGet("/manga", () =>
{
    return mangaList;
});

app.MapGet("/manga/{num}", (int num) =>
{
    try
    {
        return Results.Ok(mangaList[num]);
    }
    catch
    {
        return Results.NotFound();
    }
});

app.Run();


static string Answer()
{
    return "sss";
}