# Blazor-Server-JsRuntimeStream

JsRuntimeStream for Blazor Server applications


### Installing

You can install from NuGet using the following command:

`Install-Package Blazor-Server-JsRuntimeStream`

Or via the Visual Studio package manger.

### Setup
Blazor Server applications will need to include the following JS files in their `Pages\_Host.cshtml`.

Add the JS script at the bottom of the page using the following script tag.

```html
<script src="_content/Blazor-Server-JsRuntimeStream/js-interop-stream-functions.js" type="text/javascript"></script>
```

## Usage

**Register Services**

Add registration of service to Startup.cs

```cs
services.AddJsRuntimeStream();
```

**Basic Example**
```cs
@using JsRuntimeStream
@using System.IO

@code {
    [Inject] private IJsRuntimeStream jsRuntimeStream { get; set; }

    public async Task<string> GetLargeString(CancellationTokenSource cts = default)
    {
	using var stream = await jsRuntimeStream.InvokeReadStream("window.getLargeString", cts.Token);
	using var memoryStream = new MemoryStream();
	await stream.CopyToAsync(memoryStream);

	return System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
    }
    
    public async Task<string> GetLargeStringWithProgressReport(IProgress<double> progress, CancellationTokenSource cts = default)
    {
	var buffer = new byte[4 * 1096];
	int bytesRead;
	double totalRead = 0;

	using var stream = await jsRuntimeStream.InvokeReadStream("window.getLargeString", cts.Token);
	using var memoryStream = new MemoryStream();

	while ((bytesRead = await stream.ReadAsync(buffer, cts.Token)) != 0)
        {
          totalRead += bytesRead;
          await memoryStream.WriteAsync(buffer, cts.Token);

          progress.Report((totalRead / stream.Length) * 100);
        }
        
	return System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
    }
}
```
