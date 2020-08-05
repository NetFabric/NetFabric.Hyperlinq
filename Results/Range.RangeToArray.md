## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ForLoop |     0 |   100 |  80.46 ns | 0.312 ns | 0.261 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           Linq |     0 |   100 |  83.38 ns | 0.694 ns | 0.649 ns |  1.04 |    0.01 | 0.2218 |     - |     - |     464 B |
|     LinqFaster |     0 |   100 |  68.70 ns | 0.617 ns | 0.547 ns |  0.85 |    0.01 | 0.2027 |     - |     - |     424 B |
|     StructLinq |     0 |   100 | 368.54 ns | 2.402 ns | 1.876 ns |  4.58 |    0.03 | 0.2141 |     - |     - |     448 B |
|      Hyperlinq |     0 |   100 |  81.17 ns | 0.709 ns | 0.663 ns |  1.01 |    0.01 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Pool |     0 |   100 | 123.24 ns | 0.752 ns | 0.667 ns |  1.53 |    0.01 | 0.0267 |     - |     - |      56 B |
